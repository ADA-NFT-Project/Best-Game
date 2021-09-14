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

            for (int i = 0; i < skills.Count; i++)
            {
                skills[i].user = Entity;
                for (int j = 0; j < skills[i].Animations.Count; j++)
                {
                    if (skills[i].Animations[j] == null) continue;
                    print(Skill.SkillToAnimation(skills[i], j));
                    animationOverride[Skill.SkillToAnimation(skills[i], j)] = skills[i].Animations[j];
                }
            }
        }

        private void UseOnSpawnSkills(UnitEntity le)
        {
            foreach (Skill s in skills)
            {
                s.UseOnSpawnAction();
            }
        }

        private void UseOnGetHitSkills(int d, UnitEntity le)
        {
            if (d <= 0) return;
            foreach (Skill s in skills)
            {
                s.UseOnGetHitAction(d);
            }
        }

        private void UseOnDieSkills(UnitEntity le)
        {
            foreach (Skill s in skills)
            {
                s.UseOnDieAction();
            }
        }

        public void UseSkill(int order)
        {
            skills[order].UseSkill();
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
    }
}
