using Game.Entity;
using UnityEngine;

namespace Units
{
    [CreateAssetMenu(menuName = "Species", fileName = "New Species")]
    public class SpeciesInfo : IdScobject
    {
        [SerializeField] private string speciesName;
        [TextArea(2,8)]
        [SerializeField] private string description;

        [SerializeField] private int rarity;

        [SerializeField] private Sprite sprite;
        [SerializeField] private UnitEntity entityPrefab;


    }
}
