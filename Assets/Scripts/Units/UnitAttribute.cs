using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Units
{
    [CreateAssetMenu(menuName = "Units/Attribute", fileName = "New Attribute")]
    public class UnitAttribute : ScriptableObject
    {
        [SerializeField] private Color color;
        [SerializeField] private string attributeName;
        [TextArea(2, 8)] [SerializeField] private string description;

        [SerializeField] private Sprite icon;

    }
}
