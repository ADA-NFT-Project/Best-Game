using System;
using Game.Entity;
using UnityEngine;

namespace Game.Skills
{
    public class HealSpell : Skill
    {
        [SerializeField] private int toHeal;

        private void Start()
        {
            GetEffect[0] = Heal;
        }

        public void Heal()
        {
            user.Life.TakeDamage(-toHeal);
        }
    }
}
