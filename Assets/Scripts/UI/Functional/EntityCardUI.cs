using System.Collections.Generic;
using PlayerInput;
using TMPro;
using UnityEngine;

namespace UI.Functional
{
    public enum EntityCardState
    {
        Reserve, Destroyed, Spawned
    }
    public class EntityCardUI : MonoBehaviour, ISelectionInteractor
    {
        private static readonly string[] HOVER_TEXT = new[] {"Summon", "Repair", ""};

        private EntityCardState state = EntityCardState.Reserve;

        public EntityCardState State => state;

        [Header("Assign Slots")] 
        [SerializeField] private TextMeshProUGUI entityNameSlot;
        [SerializeField] private SpriteRenderer entitySpriteSlot;
        [SerializeField] private TextMeshProUGUI costSlot;
        [SerializeField] private SpriteRenderer cardStatusSlot;
        [SerializeField] private TextMeshProUGUI hoverTextSlot;
        [SerializeField] private Transform hoverSlot;
        
        [Header("Assign Sprites")] 
        [SerializeField] private Sprite reserveStatusSprite;
        [SerializeField] private Sprite destroyedStatusSprite;
        [SerializeField] private Sprite spawnedStatusSprite;


        public List<MapObjectType> GetValidSelectables()
        {
            return new List<MapObjectType>() {MapObjectType.LanePoint};
        }

        public void ProcessInteraction(ISelectable selectable)
        {
            
        }
    }
}
