using System;
using Game.Skills;
using Spine;
using Spine.Unity;
using Units;
using UnityEngine;

namespace Game.Entity
{
    public class UnitEntity : MonoBehaviour
    {
        public event Action<int, UnitEntity> OnHit;
        public event Action<UnitEntity> OnDie;
        public event Action<UnitEntity> OnSpawn;
        public event Action Init;
        
        public static event Action<int, UnitEntity> OnUnitHit;
        public static event Action<UnitEntity> OnUnitDie;
        public static event Action<UnitEntity> OnUnitSpawn;
        
        private SkillUser skills;
        private LivingEntity life;

        private SpriteRenderer sprite;
        //to movement

        private UnitInfo info;
        
        public SkeletonAnimation animator;
        private string unitName;
        private string description; //TO BUILD PROCEDURALLY

        public string UnitName
        {
            get => unitName;
            set => unitName = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public SkillUser Skills => skills;
        public LivingEntity Life => life;

        public UnitInfo Info
        {
            get => info;
            set => info = value;
        }

        private void Awake()
        {
            skills = GetComponent<SkillUser>();
            life = GetComponent<LivingEntity>();
            animator = GetComponent<SkeletonAnimation>();
            sprite = GetComponentInChildren<SpriteRenderer>();
            animator = GetComponentInChildren<SkeletonAnimation>();
        }

        private void OnEnable()
        {
            Life.OnHit += HitAction;
            Life.OnDie += DieAction;
            Life.OnSpawn += SpawnAction;
        }

        private void OnDisable()
        {
            Life.OnHit -= HitAction;
            Life.OnDie -= DieAction;
            Life.OnSpawn -= SpawnAction;
        }

        private void HitAction(int d, LivingEntity le)
        {
            OnHit?.Invoke(d, le.Entity);
            OnUnitHit?.Invoke(d, le.Entity);
        }

        private void DieAction(LivingEntity le)
        {
            OnDie?.Invoke(le.Entity);
            OnUnitDie?.Invoke(le.Entity);
        }

        private void SpawnAction(LivingEntity le)
        {
            OnSpawn?.Invoke(le.Entity);
            OnUnitSpawn?.Invoke(le.Entity);
        }

        public void AddSkill(Skill s)
        {
            skills.AddSkill(s);
        }

        public void Initialise()
        {
            Init?.Invoke();
        }
    }
}
