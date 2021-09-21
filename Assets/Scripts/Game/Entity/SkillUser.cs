using System;
using System.Collections.Generic;
using Game;
using UnityEngine;
using Game.Skills;
using Spine.Unity;

namespace Game.Entity
{
    [RequireComponent(typeof(UnitEntity))]
    public class SkillUser : MonoBehaviour
    {
        private const int ANIMATOR_SKILL_TRACK = 1;
        
        private List<Skill> skills;
        private UnitEntity entity;

        public UnitEntity Entity
        {
            get => entity;
            set => entity = value;
        }

        private void Awake()
        {
            skills = new List<Skill>();
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

        private void UseOnSpawnSkills(UnitEntity le)
        {
            foreach (Skill s in skills)
            {
                s.UseSkillEventAction(SkillTriggerEvent.Spawn);
            }
        }

        private void UseOnGetHitSkills(int d, UnitEntity le)
        {
            if (d <= 0) return;
            foreach (Skill s in skills)
            {
                s.UseSkillEventAction(SkillTriggerEvent.Gethit);
            }
        }

        private void UseOnDieSkills(UnitEntity le)
        {
            foreach (Skill s in skills)
            {
                s.UseSkillEventAction(SkillTriggerEvent.Die);
            }
        }

        public void UseSkill(int order)
        {
            skills[order].UseSkillEventAction(SkillTriggerEvent.Activate);
        }

        public void StartSkillAnimation(AnimationReferenceAsset clip)
        {
            Entity.animator.AnimationState.SetAnimation(ANIMATOR_SKILL_TRACK, clip, false);
        }

        public void AddSkill(Skill s)
        {
            skills.Add(s);
            s.user = this;
        }
    }
}
