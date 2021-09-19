using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Units.UnitGen
{
    [CreateAssetMenu(menuName = "Units/UnitGen/Params", fileName = "New UnitGen")]
    public class UnitGenParams : ScriptableObject
    {
        [SerializeField] private WeightTable<SpeciesData> speciesGenParams;
        [SerializeField] private List<WeightTable<int>> statsGenParams;
        [SerializeField] private WeightTable<PartsData> partsGenParams;
        [SerializeField] private WeightTable<SkillData> skillGenParams;
    }

    [Serializable]
    public struct WeightTable<T> : ISerializationCallbackReceiver
    {
        [Serializable]
        struct WeightValuePair<U>
        {
            [SerializeField] private U data;
            [SerializeField] private float weight;
            

            public float Weight => weight;
            public U Data => data;

            public WeightValuePair(float w, U d)
            {
                weight = w;
                data = d;
            }
        }

        [SerializeField] private List<WeightValuePair<T>> weightValuePairs;
        private Dictionary<T, float> getWeight;

        private void TryAdd(T t, float w)
        {
            if (getWeight.ContainsKey(t)) return;
            getWeight.Add(t, w);
        }

        public float GetWeight(T type)
        {
            if (!getWeight.ContainsKey(type)) return 0;
            return getWeight[type];
        }

        public T PickWeighted()
        {
            float rand0to1 = UnityEngine.Random.value;
            float rand0toWeightSum = MathUtility.SumOfList(getWeight.Values) * rand0to1;
            float acc = 0;
            foreach (var gw in getWeight)
            {
                acc += gw.Value;
                if (acc >= rand0toWeightSum)
                {
                    return gw.Key;
                }
            }

            return getWeight.Keys.ToList()[0];
        }

        public void RecompileDictionary()
        {
            getWeight = new Dictionary<T, float>();
            foreach (var kvp in weightValuePairs)
            {
                TryAdd(kvp.Data, kvp.Weight);
            }
        }

        public void OnBeforeSerialize()
        {
            
        }

        public void OnAfterDeserialize()
        {
            RecompileDictionary();
        }
    }
}
