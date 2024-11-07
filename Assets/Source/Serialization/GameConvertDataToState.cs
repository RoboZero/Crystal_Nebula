﻿using System.Collections.Generic;
using System.Linq;
using Source.Logic.State;
using Source.Logic.State.Battlefield;
using Source.Logic.State.LineItems;
using Source.Logic.State.LineItems.Units;
using Source.Serialization.Data;
using Source.Visuals.BattlefieldStorage;
using Source.Visuals.MemoryStorage;
using UnityEngine;

namespace Source.Serialization
{
    public class GameConvertDataToState
    {
        private GameResources gameResources;

        public GameConvertDataToState(GameResources gameResources)
        {
            this.gameResources = gameResources;
        }

        public GameState Convert(GameData gameData)
        {
            var players = gameData.Players.Select(ConvertPlayer).ToList();

            var gameState = new GameState
            {
                Level = ConvertLevel(gameData.Level),
                BattlefieldStorage = ConvertBattlefieldStorage(gameData.BattlefieldStorage),
                Players = players
            };
            return gameState;
        }

        private Level ConvertLevel(LevelData levelData)
        {
            return new Level()
            {
                Definition = levelData.Definition
            };
        }

        private LineStorage<BattlefieldItem> ConvertBattlefieldStorage(BattlefieldStorageData battlefieldStorage)
        {
            var battlefieldItems = new List<BattlefieldItem>(new BattlefieldItem[battlefieldStorage.Length]);

            for (var i = 0; i < battlefieldStorage.Length; i++)
            {
                battlefieldItems[i] = new BattlefieldItem();
            }
            
            foreach (var item in battlefieldStorage.Items)
            {
                battlefieldItems[item.Location] = ConvertBattlefieldItem(item);
            }

            return new LineStorage<BattlefieldItem>()
            {
                Items = battlefieldItems
            };
        }

        private BattlefieldItem ConvertBattlefieldItem(BattlefieldItemData battlefieldItemData)
        {
            BuildingMemory building = null;
            if (battlefieldItemData.Building != null)
            {
                if (gameResources.TryLoadAsset(this, battlefieldItemData.Building.Definition, out BuildingMemoryDataSO buildingDataSO))
                {
                    building = buildingDataSO.CreateInstance(battlefieldItemData.Building);
                }
            }

            UnitMemory unit = null;
            if (battlefieldItemData.Unit != null)
            {
                if (gameResources.TryLoadAsset(this, battlefieldItemData.Unit.Definition, out UnitMemoryDataSO unitDataSO))
                {
                    unit = (UnitMemory) unitDataSO.CreateMemoryInstance(battlefieldItemData.Unit);
                }
            }

            return new BattlefieldItem()
            {
                Building = building,
                Unit = unit
            };
        }

        private Player ConvertPlayer(PlayerData playerData)
        {
            var processors = playerData.Processors.Select(ConvertProcessor).ToList();

            return new Player()
            {
                Id = playerData.Id,
                PersonalStorage = ConvertMemoryStorage("Personal", playerData.PersonalStorage),
                Processors = processors,
                MemoryStorage = ConvertMemoryStorage("Memory", playerData.MemoryStorage),
                DiskStorage = ConvertMemoryStorage("Disk", playerData.DiskStorage),
            };
        }

        private Processor ConvertProcessor(ProcessorData processorData)
        {
            return new Processor()
            {
                Definition = processorData.Definition,
                ProcessorStorage = ConvertMemoryStorage("Processor", processorData.ProcessorStorage),
                ClockSpeed = processorData.ClockSpeed,
            };
        }

        private LineStorage<MemoryItem> ConvertMemoryStorage(string storageName, MemoryStorageData memoryStorage)
        {
            var lineStorageItems = new List<MemoryItem>(new MemoryItem[memoryStorage.Length]);

            foreach (var storedItem in memoryStorage.Items)
            {
                if (gameResources.TryLoadAsset(this, storedItem.Memory.Definition, out MemoryDataSO memoryDataSO))
                {
                    lineStorageItems[storedItem.Location] = memoryDataSO.CreateMemoryInstance(storedItem.Memory);
                }
                else
                {
                    Debug.LogError($"Unable to load {nameof(memoryDataSO)} asset for stored data item: {storedItem}");
                }
            }

            return new LineStorage<MemoryItem>()
            {
                StorageName = storageName,
                Length = memoryStorage.Length,
                Items = lineStorageItems
            };
        }
    }
}