using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Game.Entity;
using UnityEngine;

namespace Game
{
    public abstract class Skill : MonoBehaviour
    {
        [SerializeField] private string skillName;

        [SerializeField] private AnimationClip spawnAction;
        [SerializeField] private AnimationClip activeAction;
        [SerializeField] private AnimationClip getHitAction;
        [SerializeField] private AnimationClip hitOtherAction;
        [SerializeField] private AnimationClip onDieAction;
        

        [HideInInspector] public SkillUser user;

        private Dictionary<int, Action> getEffect;
        public Dictionary<int, Action> GetEffect => getEffect;

        public string SkillName => skillName;

        private void Awake()
        {
            getEffect = new Dictionary<int, Action>();
        }

        public virtual void UseOnSpawnAction()
        {
            user.StartSkillAnimation(spawnAction);
        }

        public virtual void UseSkill()
        {
            user.StartSkillAnimation(activeAction);
        }

        public virtual void UseOnGetHitAction(int d)
        {
            if (d <= 0) return;
            user.StartSkillAnimation(getHitAction);
        }

        public virtual void UseOnHitOtherAction(UnitEntity other)
        {
            user.StartSkillAnimation(hitOtherAction);
        }

        public virtual void UseOnDieAction()
        {
            user.StartSkillAnimation(onDieAction);
        }

        public void ActivateSkillEffect(int effect)
        {
            GetEffect[effect]?.Invoke();
        }
        
    }
}
