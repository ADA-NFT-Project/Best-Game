using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{

    [CreateAssetMenu(menuName = "Units/Skill", fileName = "New Skill")]
    public class SkillInfo : ScriptableObject
    {
        [Tooltip("should assign automatically")] [SerializeField]
        private string id;

        [SerializeField] private string skillName;
        [TextArea(2, 8)] [SerializeField] private string description;

        [SerializeField] private Sprite icon;
    }
}
