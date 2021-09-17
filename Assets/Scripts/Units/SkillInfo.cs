using System;
using Game;
using UnityEditor;
using UnityEngine;

namespace Units
{
    [CreateAssetMenu(menuName = "Skill", fileName = "New Skill")]
    public class SkillInfo : IdScobject
    {
        [SerializeField] private string skillName;
        [TextArea(2,8)]
        [SerializeField] private string description;

        [SerializeField] private int rarity;

        [SerializeField] private Sprite sprite;
        [SerializeField] private Skill skillPrefab;

        private void OnValidate()
        {
#if UNITY_EDITOR
            if (id == "")
            {
                id = GUID.Generate().ToString();
                EditorUtility.SetDirty(this);
            }
#endif
        }
    }
}
