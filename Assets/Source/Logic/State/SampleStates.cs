using System.Collections.Generic;
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
            Players = new List<PlayerData>
            {
                new PlayerData
                {
                    Id = 0,
                    Processors = new List<ProcessorData>
                    {
                        new ProcessorData
                        {
                            Definition = "Processors/Basic",
                            ClockSpeed = 1.0f,
                            ProcessorStorage = new LineStorageData
                            {
                                Length = 1,
                                Items = new List<LineItemData>
                                {
                                    new LineItemData
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
                            }  
                        }
                    },
                    MemoryStorage = new LineStorageData
                    {
                        Length = 3,
                        Items = new List<LineItemData>
                        {
                            new LineItemData
                            {
                                Location = 0,
                                Memory = new MemoryData
                                {
                                    OwnerId = 0,
                                    Definition = GameResources.BuildDefinitionPath("Programs","Build"),
                                    Progress = 0
                                }
                            },
                            new LineItemData
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
                    DiskStorage = new LineStorageData
                    {
                        Length = 5,
                        Items = new List<LineItemData>
                        {
                            new LineItemData
                            {
                                Location = 0,
                                Memory = new MemoryData
                                {
                                    OwnerId = 0,
                                    Definition = GameResources.BuildDefinitionPath("Programs","Build"),
                                    Progress = 0
                                }
                            },
                            new LineItemData
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
                Items = new List<BattlefieldItemData>
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
                        }
                    }
                }
            }
        };
    }
}