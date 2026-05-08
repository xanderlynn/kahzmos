using Azure.Identity;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using SpaceExplorer.Models;

namespace SpaceExplorer.Services;

public class CosmosService
{
    private readonly CosmosClient _client;
    private readonly string _databaseName;

    public CosmosService(IConfiguration config)
    {
        var endpoint = config["COSMOSDB_ENDPOINT"]
            ?? throw new InvalidOperationException("COSMOSDB_ENDPOINT is not configured.");
        _databaseName = config["COSMOSDB_DATABASE"] ?? "SpaceExplorer";

        _client = new CosmosClient(endpoint, new DefaultAzureCredential(), new CosmosClientOptions
        {
            SerializerOptions = new CosmosSerializationOptions
            {
                PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
            }
        });
    }

    private Container GetContainer(string name) =>
        _client.GetContainer(_databaseName, name);

    public async Task<List<T>> GetAllAsync<T>(string containerName)
    {
        var container = GetContainer(containerName);
        var query = container.GetItemLinqQueryable<T>().ToFeedIterator();
        var results = new List<T>();

        while (query.HasMoreResults)
        {
            var page = await query.ReadNextAsync();
            results.AddRange(page);
        }

        return results;
    }

    public async Task<T?> GetByIdAsync<T>(string containerName, string id, string partitionKey)
    {
        var container = GetContainer(containerName);
        try
        {
            var response = await container.ReadItemAsync<T>(id, new PartitionKey(partitionKey));
            return response.Resource;
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return default;
        }
    }

    public async Task UpsertAsync<T>(string containerName, T item)
    {
        var container = GetContainer(containerName);
        await container.UpsertItemAsync(item);
    }

    public async Task<bool> IsDatabaseEmptyAsync(string containerName)
    {
        var container = GetContainer(containerName);
        var query = container.GetItemQueryIterator<dynamic>("SELECT VALUE COUNT(1) FROM c");
        var page = await query.ReadNextAsync();
        return page.FirstOrDefault() == 0;
    }
}
