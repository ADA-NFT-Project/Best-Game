using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Game.Entity;
using UnityEngine;

namespace Game
{
    public abstract class Skill : MonoBehaviour
    {
        public static readonly string[] animCats = { "spawn", "use", "gethit", "hitother", "die" };
        
        [SerializeField] private string skillName;

        [SerializeField] private AnimationClip spawnAction;
        [SerializeField] private AnimationClip activeAction;
        [SerializeField] private AnimationClip getHitAction;
        [SerializeField] private AnimationClip hitOtherAction;
        [SerializeField] private AnimationClip onDieAction;
        
        private List<AnimationClip> animations;

        [HideInInspector] public UnitEntity user;

        private Dictionary<int, Action> getEffect;
        public Dictionary<int, Action> GetEffect => getEffect;

        public string SkillName => skillName;
        public List<AnimationClip> Animations => animations;

        private void Awake()
        {
            getEffect = new Dictionary<int, Action>();
            animations = new List<AnimationClip>()
            {
                spawnAction, activeAction, getHitAction, hitOtherAction, onDieAction
            };
        }

        public virtual void UseOnSpawnAction()
        {
            if (user.animator.hasState(SkillToAnimation(this, 0))) return;
            user.animator.Play(SkillToAnimation(this, 0));
        }

        public virtual void UseSkill()
        {
            if (user.animator.hasState(SkillToAnimation(this, 1))) return;
            user.animator.Play(SkillToAnimation(this, 1));
        }

        public virtual void UseOnGetHitAction(int d)
        {
            if (user.animator.hasState(SkillToAnimation(this, 2))) return;
            user.animator.Play(SkillToAnimation(this, 2));
        }

        public virtual void UseOnHitOtherAction(UnitEntity other)
        {
            if (user.animator.hasState(SkillToAnimation(this, 3))) return;
            user.animator.Play(SkillToAnimation(this, 3));
        }

        public virtual void UseOnDieAction()
        {
            if (user.animator.hasState(SkillToAnimation(this, 4))) return;
            user.animator.Play(SkillToAnimation(this, 4));
        }

        public void ActivateSkillEffect(int effect)
        {
            GetEffect[effect]?.Invoke();
        }

        public static string SkillToAnimation(Skill skill, int order)
        {
            return skill.SkillName + "_" + animCats[order];
        }
    }
}
