using SpaceExplorer.Models;
using SpaceExplorer.Services;

namespace SpaceExplorer;

public static class SeedData
{
    public static object Summary => new { planets = Planets.Count, missions = Missions.Count, astronauts = Astronauts.Count };

    public static async Task RunAsync(CosmosService cosmos)
    {
        foreach (var planet in Planets)
            await cosmos.UpsertAsync("planets", planet);
        foreach (var mission in Missions)
            await cosmos.UpsertAsync("missions", mission);
        foreach (var astronaut in Astronauts)
            await cosmos.UpsertAsync("astronauts", astronaut);
    }

    public static readonly List<Planet> Planets =
    [
        new() { Id = "mercury", Name = "Mercury", Type = "rocky", DistanceFromSunAu = 0.39, DiameterKm = 4879, Moons = 0, HasRings = false, AtmosphereComposition = ["Oxygen", "Sodium", "Hydrogen"], FunFact = "A year on Mercury is just 88 Earth days, but a day lasts 59 Earth days." },
        new() { Id = "venus",   Name = "Venus",   Type = "rocky", DistanceFromSunAu = 0.72, DiameterKm = 12104, Moons = 0, HasRings = false, AtmosphereComposition = ["Carbon Dioxide", "Nitrogen"], FunFact = "Venus rotates backwards compared to most planets — the Sun rises in the west." },
        new() { Id = "earth",   Name = "Earth",   Type = "rocky", DistanceFromSunAu = 1.00, DiameterKm = 12756, Moons = 1, HasRings = false, AtmosphereComposition = ["Nitrogen", "Oxygen", "Argon"], FunFact = "Earth is the only known planet with active plate tectonics." },
        new() { Id = "mars",    Name = "Mars",    Type = "rocky", DistanceFromSunAu = 1.52, DiameterKm = 6792, Moons = 2, HasRings = false, AtmosphereComposition = ["Carbon Dioxide", "Nitrogen", "Argon"], FunFact = "Olympus Mons on Mars is the tallest volcano in the solar system at ~22 km high." },
        new() { Id = "jupiter", Name = "Jupiter", Type = "gas-giant", DistanceFromSunAu = 5.20, DiameterKm = 142984, Moons = 95, HasRings = true, AtmosphereComposition = ["Hydrogen", "Helium"], FunFact = "Jupiter's Great Red Spot is a storm that has lasted over 350 years." },
        new() { Id = "saturn",  Name = "Saturn",  Type = "gas-giant", DistanceFromSunAu = 9.58, DiameterKm = 120536, Moons = 146, HasRings = true, AtmosphereComposition = ["Hydrogen", "Helium"], FunFact = "Saturn is the least dense planet — it would float in water." },
        new() { Id = "uranus",  Name = "Uranus",  Type = "ice-giant", DistanceFromSunAu = 19.2, DiameterKm = 51118, Moons = 27, HasRings = true, AtmosphereComposition = ["Hydrogen", "Helium", "Methane"], FunFact = "Uranus rotates on its side with an axial tilt of 98 degrees." },
        new() { Id = "neptune", Name = "Neptune", Type = "ice-giant", DistanceFromSunAu = 30.05, DiameterKm = 49528, Moons = 16, HasRings = true, AtmosphereComposition = ["Hydrogen", "Helium", "Methane"], FunFact = "Neptune has the fastest winds in the solar system — up to 2,100 km/h." },
    ];

    public static readonly List<Mission> Missions =
    [
        new() { Id = "apollo-11",       Name = "Apollo 11",         Agency = "NASA",     LaunchYear = 1969, Destination = "Moon",    Status = "Completed", Crewed = true,  Objective = "First crewed lunar landing",                         NotableAchievement = "Neil Armstrong became the first human to walk on the Moon." },
        new() { Id = "voyager-1",       Name = "Voyager 1",         Agency = "NASA",     LaunchYear = 1977, Destination = "Interstellar", Status = "Active", Crewed = false, Objective = "Outer solar system flyby and beyond",              NotableAchievement = "First human-made object to enter interstellar space (2012)." },
        new() { Id = "voyager-2",       Name = "Voyager 2",         Agency = "NASA",     LaunchYear = 1977, Destination = "Interstellar", Status = "Active", Crewed = false, Objective = "Outer solar system flyby including Uranus & Neptune", NotableAchievement = "Only spacecraft to have visited Uranus and Neptune." },
        new() { Id = "hubble",          Name = "Hubble Space Telescope", Agency = "NASA", LaunchYear = 1990, Destination = "LEO",   Status = "Active", Crewed = false, Objective = "Deep space observation",                               NotableAchievement = "Helped determine the universe is ~13.8 billion years old." },
        new() { Id = "mars-pathfinder", Name = "Mars Pathfinder",   Agency = "NASA",     LaunchYear = 1996, Destination = "Mars",   Status = "Completed", Crewed = false, Objective = "Demonstrate low-cost Mars landing technology",       NotableAchievement = "Deployed Sojourner, the first Mars rover." },
        new() { Id = "iss",             Name = "ISS Program",        Agency = "NASA",     LaunchYear = 1998, Destination = "LEO",    Status = "Active", Crewed = true,  Objective = "Permanent human presence in low Earth orbit",          NotableAchievement = "Continuously inhabited since November 2000." },
        new() { Id = "curiosity",       Name = "Mars Science Lab",  Agency = "NASA",     LaunchYear = 2011, Destination = "Mars",   Status = "Active", Crewed = false, Objective = "Assess Mars habitability for microbial life",           NotableAchievement = "Confirmed ancient Mars had conditions suitable for life." },
        new() { Id = "jwst",            Name = "James Webb Space Telescope", Agency = "NASA", LaunchYear = 2021, Destination = "L2", Status = "Active", Crewed = false, Objective = "Observe universe in infrared",                        NotableAchievement = "Deepest and sharpest infrared images of the distant universe." },
        new() { Id = "artemis-i",       Name = "Artemis I",         Agency = "NASA",     LaunchYear = 2022, Destination = "Moon",   Status = "Completed", Crewed = false, Objective = "Uncrewed test of Orion and SLS",                    NotableAchievement = "Orion flew 432,000 km from Earth — farther than any crewed-capable spacecraft." },
        new() { Id = "rosetta",         Name = "Rosetta",           Agency = "ESA",      LaunchYear = 2004, Destination = "Comet 67P", Status = "Completed", Crewed = false, Objective = "Orbit and land on a comet",                     NotableAchievement = "Philae became the first spacecraft to land on a comet nucleus." },
    ];

    public static readonly List<Astronaut> Astronauts =
    [
        new() { Id = "neil-armstrong",    Name = "Neil Armstrong",    Nationality = "American", Agency = "NASA", TotalSpacewalkHours = 2.5,  FirstMissionYear = 1966, Missions = ["Gemini 8", "Apollo 11"],                     FunFact = "Armstrong almost ran out of fuel landing the Eagle on the Moon." },
        new() { Id = "buzz-aldrin",       Name = "Buzz Aldrin",       Nationality = "American", Agency = "NASA", TotalSpacewalkHours = 7.8,  FirstMissionYear = 1966, Missions = ["Gemini 12", "Apollo 11"],                    FunFact = "Aldrin took communion on the lunar surface before stepping outside." },
        new() { Id = "yuri-gagarin",      Name = "Yuri Gagarin",      Nationality = "Soviet",   Agency = "Roscosmos", TotalSpacewalkHours = 0, FirstMissionYear = 1961, Missions = ["Vostok 1"],                              FunFact = "Gagarin's entire spaceflight lasted only 108 minutes." },
        new() { Id = "valentina-tereshkova", Name = "Valentina Tereshkova", Nationality = "Soviet", Agency = "Roscosmos", TotalSpacewalkHours = 0, FirstMissionYear = 1963, Missions = ["Vostok 6"],                         FunFact = "First woman in space — she orbited Earth 48 times in nearly 3 days." },
        new() { Id = "sally-ride",        Name = "Sally Ride",        Nationality = "American", Agency = "NASA", TotalSpacewalkHours = 0,    FirstMissionYear = 1983, Missions = ["STS-7", "STS-41-G"],                         FunFact = "First American woman in space and youngest American astronaut at 32." },
        new() { Id = "chris-hadfield",    Name = "Chris Hadfield",    Nationality = "Canadian", Agency = "CSA",  TotalSpacewalkHours = 14.5, FirstMissionYear = 1995, Missions = ["STS-74", "STS-100", "Expedition 34/35"],  FunFact = "First Canadian to walk in space and famous for recording 'Space Oddity' aboard the ISS." },
        new() { Id = "peggy-whitson",     Name = "Peggy Whitson",     Nationality = "American", Agency = "NASA", TotalSpacewalkHours = 60.2, FirstMissionYear = 2002, Missions = ["Expedition 5", "Expedition 16", "Expedition 51/52"], FunFact = "Holds the US record for most time in space: 665 days." },
        new() { Id = "scott-kelly",       Name = "Scott Kelly",       Nationality = "American", Agency = "NASA", TotalSpacewalkHours = 48.8, FirstMissionYear = 1999, Missions = ["STS-103", "STS-118", "Expedition 25/26", "Expedition 43/46"], FunFact = "Spent a year on the ISS as part of NASA's Twin Study — his DNA changed." },
        new() { Id = "mae-jemison",       Name = "Mae Jemison",       Nationality = "American", Agency = "NASA", TotalSpacewalkHours = 0,    FirstMissionYear = 1992, Missions = ["STS-47"],                                   FunFact = "First African American woman in space and also a trained physician and dancer." },
        new() { Id = "samantha-cristoforetti", Name = "Samantha Cristoforetti", Nationality = "Italian", Agency = "ESA", TotalSpacewalkHours = 24.1, FirstMissionYear = 2014, Missions = ["Expedition 42/43", "Expedition 67/68"], FunFact = "Holds the record for the longest single spaceflight by a European astronaut." },
        new() { Id = "akihiko-hoshide",   Name = "Akihiko Hoshide",   Nationality = "Japanese", Agency = "JAXA", TotalSpacewalkHours = 38.2, FirstMissionYear = 2008, Missions = ["STS-124", "Expedition 32/33", "Expedition 64/65"], FunFact = "Commanded the ISS and conducted multiple complex spacewalks to repair equipment." },
        new() { Id = "alexei-leonov",     Name = "Alexei Leonov",     Nationality = "Soviet",   Agency = "Roscosmos", TotalSpacewalkHours = 0.4, FirstMissionYear = 1965, Missions = ["Voskhod 2", "Apollo-Soyuz"],         FunFact = "First human to walk in space — his suit inflated so much he could barely get back in." },
    ];
}
