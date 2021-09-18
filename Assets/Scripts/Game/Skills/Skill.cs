using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Game.Entity;
using UnityEngine;

namespace Game.Skills
{
    public enum SkillEvent
    {
        Spawn, Activate, Gethit, Hitother, Die
    }
    
    public abstract class Skill : MonoBehaviour
    {
        [Serializable]
        struct EventClipPair
        {
            [SerializeField] private SkillEvent skillEvent;
            [SerializeField] private AnimationClip action;

            public SkillEvent SkillEvent => skillEvent;
            public AnimationClip Action => action;
        }
        
        [SerializeField] private string skillName;
        [SerializeField] private List<EventClipPair> skillActions;


        private Dictionary<SkillEvent, AnimationClip> event2clip;
        [HideInInspector] public SkillUser user;

        private Dictionary<int, Action> getEffect;
        public Dictionary<int, Action> GetEffect => getEffect;

        public string SkillName => skillName;

        private void Awake()
        {
            getEffect = new Dictionary<int, Action>();
            event2clip = new Dictionary<SkillEvent, AnimationClip>();
            foreach (EventClipPair ecp in skillActions)
            {
                event2clip[ecp.SkillEvent] = ecp.Action;
            }
            
        }

        public void UseSkillEventAction(SkillEvent skillEvent)
        {
            if (!event2clip.ContainsKey(skillEvent)) return;
            user.StartSkillAnimation(event2clip[skillEvent]);
        }

        public void ActivateSkillEffect(int effect)
        {
            GetEffect[effect]?.Invoke();
        }
        
    }
}
