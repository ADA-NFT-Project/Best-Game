using System;
using System.Collections.Generic;
using Units;
using UnityEngine;
using UnityEngine.UI;
using Database;
using Game.Skills;

namespace Game.Entity
{
    public class EntityInit : MonoBehaviour
    {
        public Transform location;
        
        private ObjectDatabase speciesDatabase;
        private ObjectDatabase skillsDatabase;
        private ObjectDatabase partsDatabase;

        private void Start()
        {
            GetDatabases();
        }

        public void SpawnEntityFromUnit(UnitInfo unitInfo)
        {
            //INFO LOOKUP
            SpeciesInfo speciesInfo = speciesDatabase.GetObject[unitInfo.SpeciesData.ID] as SpeciesInfo;
            List<SkillInfo> skillsInfo = new List<SkillInfo>();
            List<PartsInfo> partsInfo = new List<PartsInfo>();

            foreach (var d in unitInfo.SkillsData)
            {
                skillsInfo.Add(skillsDatabase.GetObject[d.ID] as SkillInfo);
            }
            
            foreach (var d in unitInfo.PartsData)
            {
                partsInfo.Add(partsDatabase.GetObject[d.PartID] as PartsInfo);
            }

            if (speciesInfo == null)
            {
                Debug.LogError("Invalid species ID. Spawning will not continue.");
                return;
            }
            
            //GAMEOBJECT POPULATION
            UnitEntity myEntity = Instantiate(speciesInfo.EntityPrefab, location);
            myEntity.name = myEntity.UnitName = unitInfo.UnitName;
            SkillsContainer skillsContainer = new GameObject("Skills").AddComponent<SkillsContainer>();
            var transform1 = skillsContainer.transform;
            transform1.parent = myEntity.transform;
            transform1.localPosition = new Vector3(0,0,0);
            PartsContainer partsContainer = new GameObject("Parts").AddComponent<PartsContainer>();
            var transform2 = partsContainer.transform;
            transform2.parent = myEntity.transform;
            transform2.localPosition = new Vector3(0,0,0);

            Dictionary<UnitPart, bool> getPartPopulated = new Dictionary<UnitPart, bool>();
            foreach (UnitPart e in Enum.GetValues(typeof(UnitPart)))
            {
                getPartPopulated[e] = false;
            }

            foreach (var s in skillsInfo)
            {
                if (s.SkillPrefab == null)
                {
                    Debug.LogWarning($"No prefab assigned to this skill! ({s.name})");
                    continue;
                }
                Skill skill = Instantiate(s.SkillPrefab, skillsContainer.transform);
                myEntity.AddSkill(skill);
            }

            foreach (var p in partsInfo)
            {
                UnitPart partToPopulate = p.PartType;
                if (getPartPopulated[partToPopulate])
                {
                    Debug.LogWarning("Multiple parts of same type on this entity. Earliest one will be used.");
                    continue;
                }
                getPartPopulated[partToPopulate] = true;
                Transform myPartContainer = new GameObject(p.PartType.ToString()).transform;
                myPartContainer.parent = partsContainer.transform;
                myPartContainer.localPosition = new Vector3(0, 0, 0);
                BodyPart myPart = Instantiate(p.PartPrefab,myPartContainer);
            }
            
            //INIT
            myEntity.Initialise();
        }

        private void GetDatabases()
        {
            speciesDatabase = Resources.Load<ObjectDatabase>("Databases/Species");
            skillsDatabase = Resources.Load<ObjectDatabase>("Databases/Skills");
            partsDatabase = Resources.Load<ObjectDatabase>("Databases/Parts");
            
            if(speciesDatabase == null)
                Debug.Log("no species database here");
        }
        
    
    }
}
