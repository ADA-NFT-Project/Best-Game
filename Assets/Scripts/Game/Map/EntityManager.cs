using System;
using System.Collections.Generic;
using Game.Entity;
using UnityEngine;

namespace Game.Map
{
    public class EntityManager : MonoBehaviour
    {
        private List<UnitEntity> entitiesOnMap;

        public List<UnitEntity> EntitiesOnMap => entitiesOnMap;

        private void Awake()
        {
            entitiesOnMap = new List<UnitEntity>();
        }

        private void OnEnable()
        {
            UnitEntity.OnUnitSpawn += AddToList;
            UnitEntity.OnUnitDie += RemoveFromList;
        }

        private void OnDisable()
        {
            UnitEntity.OnUnitSpawn -= AddToList;
            UnitEntity.OnUnitDie -= RemoveFromList;
        }

        private void AddToList(UnitEntity me)
        {
            entitiesOnMap.Add(me);
        }

        private void RemoveFromList(UnitEntity me)
        {
            entitiesOnMap.Remove(me);
        }
    }
}
