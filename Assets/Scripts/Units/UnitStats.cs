using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Units
{
    [System.Serializable]
    public struct UnitStats
    {
        //placeholders
        [SerializeField] private float attack;
        [SerializeField] private float defence;
        [SerializeField] private float agility;

        public UnitStats(List<float> stats)
        {
            attack = stats[0];
            defence = stats[1];
            agility = stats[2];
        }
    }
}
