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
        [SerializeField] private List<UnitAttribute> attributes;
        [SerializeField] private List<SkillInfo> skills;
        [SerializeField] private UnitGraphicsInfo unitGraphicsInfo;


    }
}
