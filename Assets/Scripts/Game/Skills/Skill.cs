using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Game.Entity;
using Spine;
using Spine.Unity;
using UnityEngine;
using Event = Spine.Event;

namespace Game.Skills
{
    public enum SkillTriggerEvent
    {
        Spawn, Activate, Gethit, Hitother, Die
    }
    
    public abstract class Skill : MonoBehaviour
    {
        [Serializable]
        struct EventClipPair
        {
            [SerializeField] private SkillTriggerEvent skillEvent;
            [SerializeField] private AnimationReferenceAsset action;

            public SkillTriggerEvent SkillEvent => skillEvent;
            public AnimationReferenceAsset Action => action;
        }
        
        [SerializeField] private string skillName;
        [SerializeField] private List<EventClipPair> skillActions;


        private Dictionary<SkillTriggerEvent, AnimationReferenceAsset> event2clip;
        [HideInInspector] public SkillUser user;
        private SkeletonAnimation animator;

        private Dictionary<int, Action> getEffect;
        public Dictionary<int, Action> GetEffect => getEffect;

        public string SkillName => skillName;

        private void Awake()
        {
            getEffect = new Dictionary<int, Action>();
            event2clip = new Dictionary<SkillTriggerEvent, AnimationReferenceAsset>();
            foreach (EventClipPair ecp in skillActions)
            {
                event2clip[ecp.SkillEvent] = ecp.Action;
            }
        }

        private void OnDisable()
        {
            if(animator != null)
                animator.AnimationState.Event -= HandleAnimationStateEvent;
        }

        protected virtual void Start()
        {
            animator = user.Entity.animator;
            animator.AnimationState.Event += HandleAnimationStateEvent;
        }

        public void UseSkillEventAction(SkillTriggerEvent skillEvent)
        {
            if (!event2clip.ContainsKey(skillEvent)) return;
            user.StartSkillAnimation(event2clip[skillEvent]);
        }

        private void ActivateSkillEffect(int effect)
        {
            if (effect >= GetEffect.Count)
            {
                Debug.LogWarning($"Skill effect of index {effect} is not assigned. Go edit the skill behaviour script and add to GetEffect.");
                return;
            }
            GetEffect[effect]?.Invoke();
        }

        private void HandleAnimationStateEvent(TrackEntry trackEntry, Event e)
        {
            string eventName = e.Data.Name;
            int eventID;
            bool eventNameValid = Int32.TryParse(e.Data.Name, out eventID);
            if (!eventNameValid)
            {
                Debug.LogWarning($"Event name {eventName} is not an integer. Animation event will be ignored.", this);
                return;
            }
            
            ActivateSkillEffect(eventID);
        }

        protected virtual void InitialEffect()
        {
            
        }

    }
}
