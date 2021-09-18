using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



namespace Units
{
    [CreateAssetMenu(menuName = "Units/Unit", fileName = "New Unit")]
    public class UnitInfo : IdScobject
    {
        //assign fields are for debugging. remove when game reads from cloud.
        [SerializeField] private string unitName;
        [SerializeField] private SpeciesInfo assignSpecies;
        [SerializeField] private SpeciesData speciesData;
        [SerializeField] private List<SkillInfo> assignSkills;
        [SerializeField] private List<SkillData> skillsData;
        [SerializeField] private List<PartsInfo> assignParts;
        [SerializeField] private List<PartsData> partsData;
        [SerializeField] private UnitStats stats;

        private void OnValidate()
        {
            if(assignSpecies != null)
                speciesData = new SpeciesData(assignSpecies.ID);
            
            skillsData = new List<SkillData>();
            foreach (var s in assignSkills)
            {
                if(s != null)
                    skillsData.Add(new SkillData(s.ID));
            }

            partsData = new List<PartsData>();
            foreach (var p in assignParts)
            {
                if(p != null)
                    partsData.Add(new PartsData(p.BodyPart, p.ID));
            }
            
            EditorUtility.SetDirty(this);
        }

        public void CreateFromData(string _name, string _speciesID, List<string> _skillsIDs, Dictionary<string, string> _partsIDs, List<float> _stats)
        {
            //do this crap later
        }
    }
    
    


    //Unserialize when database works
    [System.Serializable]
    public struct PartsData
    {
        [SerializeField] private UnitPart partSlot;
        [SerializeField] private string partID;

        public UnitPart PartSlotID => partSlot;
        public string PartID => partID;

        public PartsData(UnitPart _slot, string _ID)
        {
            partSlot = _slot;
            partID = _ID;
        }
    }

    [System.Serializable]

    public struct SpeciesData
    {
        [SerializeField] private string id;
        public string ID => id;

        public SpeciesData(string _id)
        {
            id = _id;
        }
    }
    [System.Serializable]
    public struct SkillData
    {
        [SerializeField] private string id;
        public string ID => id;

        public SkillData(string _id)
        {
            id = _id;
        }
    }
}
