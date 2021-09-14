using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Units
{
    [CreateAssetMenu(menuName = "Units/Unit", fileName = "New Unit")]
    public class UnitInfo : ScriptableObject
    {
        [Tooltip("should assign automatically")] [SerializeField]
        private string id;

        [SerializeField] private string unitName;
        [SerializeField] private List<AttributeData> attributes;
        [SerializeField] private List<SkillData> skills;
        [SerializeField] private List<PartsData> parts;
        [SerializeField] private UnitStats stats;
    }


    //Unserialize when database works
    [System.Serializable]
    public struct PartsData
    {
        [SerializeField] private string partSlotID;
        [SerializeField] private string partID;

        public string PartSlotID => partSlotID;
        public string PartID => partID;
    }
    

    [System.Serializable]

    public struct AttributeData
    {
        [SerializeField] private string id;
        public string ID => id;
    }
    [System.Serializable]
    public struct SkillData
    {
        [SerializeField] private string id;
        public string ID => id;
    }
}
