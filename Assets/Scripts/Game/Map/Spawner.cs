using System;
using Game.Entity;
using Units;
using UnityEngine;

namespace Game.Map
{
    public class Spawner : MonoBehaviour
    {
        private EntityInit entityInit;

        private void Start()
        {
            entityInit = FindObjectOfType<EntityInit>();
            if (entityInit == null)
            {
                Debug.Log("Entity Initializer module not found in scene.", this);
            }
        }

        public void Spawn(UnitInfo unit)
        {
            entityInit.location = transform;
            entityInit.SpawnEntityFromUnit(unit);
        }
    }
}
