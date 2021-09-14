using System;
using Game.Entity;
using TMPro;
using UnityEngine;

namespace UI
{
    public class EntityHealthBar : MonoBehaviour
    {
        private LivingEntity toRead;

        [SerializeField] private TextMeshPro hpText;

        private void Awake()
        {
            toRead = GetComponentInParent<LivingEntity>();
        }

        private void Update()
        {
            hpText.text = toRead.Hp.ToString();
        }
    }
}
