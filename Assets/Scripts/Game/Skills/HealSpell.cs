using System;
using Game.Entity;
using UnityEngine;

namespace Game.Skills
{
    public class HealSpell : Skill
    {
        [SerializeField] private int toHeal;

        protected override void Start()
        {
            base.Start();
            GetEffect[0] = Heal;
            GetEffect[1] = Heal;
        }

        private void Heal()
        {
            user.Entity.Life.TakeDamage(-toHeal);
        }

        protected override void InitialEffect()
        {
            Heal();
        }
    }
}
