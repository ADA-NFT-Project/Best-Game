using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
    public enum UnitPart
    {
        Head, Shoulders, Knees, Toes
    }
    
    [CreateAssetMenu(menuName = "Body Part", fileName = "New Part")]
    public class PartsInfo : IdScobject
    {
        [SerializeField] private UnitPart bodyPart;
        [SerializeField] private string partName;
        [TextArea(2,8)]
        [SerializeField] private string description;

        [SerializeField] private int rarity;

        [SerializeField] private Sprite sprite;
        [SerializeField] private BodyPart partPrefab;

        public UnitPart BodyPart => bodyPart;
    }
}