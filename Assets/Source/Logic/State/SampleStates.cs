using Source.Logic.Data;
using Source.Serialization;

namespace Source.Logic.State
{
    public static class SampleStates
    {
        public static readonly GameState TestState1 = new ()
        {
            Level = new LevelData
            {
                Definition = GameResources.BuildDefinitionPath("Levels","Level1")
            },
            Players = new []
            {
                new PlayerData
                {
                    Id = 0,
                    ProcessorStorage = new MemoryStorageData
                    {
                        Length = 1,
                        Items = new[]
                        {
                            new MemoryItemData
                            {
                                Location = 0,
                                Memory = new MemoryData
                                {
                                    OwnerId = 0,
                                    Definition = GameResources.BuildDefinitionPath("Programs","Build"),
                                    Progress = 0
                                }
                            },
                        }
                    },
                    MemoryStorage = new MemoryStorageData
                    {
                        Length = 3,
                        Items = new[]
                        {
                            new MemoryItemData
                            {
                                Location = 0,
                                Memory = new MemoryData
                                {
                                    OwnerId = 0,
                                    Definition = GameResources.BuildDefinitionPath("Programs","Build"),
                                    Progress = 0
                                }
                            },
                            new MemoryItemData
                            {
                                Location = 1,
                                Memory = new MemoryData
                                {
                                    OwnerId = 0,
                                    Definition = GameResources.BuildDefinitionPath("Programs","Research"),
                                    Progress = 0
                                }
                            }
                        }
                    },
                    DiskStorage = new MemoryStorageData
                    {
                        Length = 5,
                        Items = new[]
                        {
                            new MemoryItemData
                            {
                                Location = 0,
                                Memory = new MemoryData
                                {
                                    OwnerId = 0,
                                    Definition = GameResources.BuildDefinitionPath("Programs","Build"),
                                    Progress = 0
                                }
                            },
                            new MemoryItemData
                            {
                                Location = 1,
                                Memory = new MemoryData
                                {
                                    OwnerId = 0,
                                    Definition = GameResources.BuildDefinitionPath("Programs","Research"),
                                    Progress = 0
                                }
                            }
                        }
                    }
                }
            },
            BattlefieldStorage = new BattlefieldStorageData
            {
                Length = 20,
                Items = new []
                {
                    new BattlefieldItemData
                    {
                        Location = 19,
                        Building = new BuildingData
                        {
                            OwnerId = 0,
                            Definition = GameResources.BuildDefinitionPath("Buildings", "Flag"),
                        },
                        Unit = new UnitData
                        {
                            OwnerId = 0,
                            Definition = GameResources.BuildDefinitionPath("Units", "Guardian"),
                        },
                    }
                }
            }
        };
    }
}