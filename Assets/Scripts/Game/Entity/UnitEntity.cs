using System;
using Units;
using UnityEngine;

namespace Game.Entity
{
    public class UnitEntity : MonoBehaviour
    {
        public event Action<int, UnitEntity> OnHit;
        public event Action<UnitEntity> OnDie;
        public event Action<UnitEntity> OnSpawn;
        
        public static event Action<int, UnitEntity> OnUnitHit;
        public static event Action<UnitEntity> OnUnitDie;
        public static event Action<UnitEntity> OnUnitSpawn;
        
        private SkillUser skills;
        private LivingEntity life;

        private SpriteRenderer sprite;
        //to movement

        private UnitInfo info;
        
        public Animator animator;

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
            animator = GetComponent<Animator>();
            sprite = GetComponentInChildren<SpriteRenderer>();
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
    }
}
