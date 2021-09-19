using System;
using Game;
using UnityEditor;
using UnityEngine;
using Game.Skills;

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

        public Skill SkillPrefab => skillPrefab;
    }
}
