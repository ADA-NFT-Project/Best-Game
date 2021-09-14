using System;
using System.Collections.Generic;
using Game;
using UnityEngine;

namespace Game.Entity
{
    [RequireComponent(typeof(UnitEntity))]
    public class SkillUser : MonoBehaviour
    {
        [SerializeField] private List<Skill> skills;
        private UnitEntity entity;

        private AnimatorOverrideController animationOverride;

        public UnitEntity Entity
        {
            get => entity;
            set => entity = value;
        }

        private void Awake()
        {
            entity = GetComponent<UnitEntity>();
            foreach (Skill s in skills)
            {
                s.user = this;
            }
        }

        private void OnEnable()
        {
            Entity.OnSpawn += UseOnSpawnSkills;
            Entity.OnHit += UseOnGetHitSkills;
            Entity.OnDie += UseOnDieSkills;
        }

        private void OnDisable()
        {
            Entity.OnSpawn -= UseOnSpawnSkills;
            Entity.OnHit -= UseOnGetHitSkills;
            Entity.OnDie -= UseOnDieSkills;
        }

        private void Start()
        {
            animationOverride = new AnimatorOverrideController(Entity.animator.runtimeAnimatorController);
            Entity.animator.runtimeAnimatorController = animationOverride;
        }

        private void UseOnSpawnSkills(UnitEntity le)
        {
            foreach (Skill s in skills)
            {
                s.UseSkillEventAction(SkillEvent.Spawn);
            }
        }

        private void UseOnGetHitSkills(int d, UnitEntity le)
        {
            if (d <= 0) return;
            foreach (Skill s in skills)
            {
                s.UseSkillEventAction(SkillEvent.Gethit);
            }
        }

        private void UseOnDieSkills(UnitEntity le)
        {
            foreach (Skill s in skills)
            {
                s.UseSkillEventAction(SkillEvent.Die);
            }
        }

        public void UseSkill(int order)
        {
            skills[order].UseSkillEventAction(SkillEvent.Activate);
        }

        public void SkillEffect(string input)
        {
            string[] skillEffect = input.Split('_');
            string skill = skillEffect[0];
            int effect = Int32.Parse(skillEffect[1]);

            foreach (Skill s in skills)
            {
                if(String.Equals(s.SkillName, skill, StringComparison.CurrentCultureIgnoreCase))
                    s.ActivateSkillEffect(effect);
            }
        }

        public void StartSkillAnimation(AnimationClip clip)
        {
            animationOverride["Skill"] = clip;
            Entity.animator.Play("Skill");
        }
    }
}
