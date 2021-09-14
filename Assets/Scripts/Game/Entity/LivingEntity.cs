using System;
using UnityEngine;

namespace Game.Entity
{
    [RequireComponent(typeof(UnitEntity))]
    public class LivingEntity : MonoBehaviour, IDamageable
    {
        public event Action<LivingEntity> OnSpawn;
        public event Action<int, LivingEntity> OnHit;
        public event Action<LivingEntity> OnDie;
        
        [SerializeField] private int maxHp;
        private int hp;
        [SerializeField] private int maxMana;
        private int mana;

        private bool isAlive;
        
        private UnitEntity entity;

        public UnitEntity Entity
        {
            get => entity;
            set => entity = value;
        }

        public int Hp
        {
            get => hp;
            set => hp = value;
        }

        public int Mana
        {
            get => mana;
            set => mana = value;
        }

        public bool IsAlive => isAlive;

        private void Awake()
        {
            isAlive = true;
            entity = GetComponent<UnitEntity>();

        }

        private void OnEnable()
        {
            OnSpawn?.Invoke(this);
        }

        public void TakeDamage(int d)
        {
            Hp -= d;
            OnHit?.Invoke(d, this);
            if (Hp <= 0)
            {
                isAlive = false;
                OnDie?.Invoke(this);
            }
        }
        
    }
}
