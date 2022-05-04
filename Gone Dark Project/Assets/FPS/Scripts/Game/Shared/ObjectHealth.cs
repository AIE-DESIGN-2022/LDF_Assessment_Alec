using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Game;
namespace Unity.FPS.Game
{
    public class ObjectHealth : MonoBehaviour
    {
        [Tooltip("Maximum amount of health")] public float MaxHealth = 10f;

        public float CurrentHealth { get; set; }
        public bool Invincible { get; set; }
        public bool CanPickup() => CurrentHealth < MaxHealth;

        public float GetRatio() => CurrentHealth / MaxHealth;

        bool m_IsDead;

        public GameObject damageArea;
        public GameObject TNT;


        void Start()
        {
            CurrentHealth = MaxHealth;
        }

        public void TakeDamage(float damage, GameObject damageSource)
        {
            if (Invincible)
                return;

            float healthBefore = CurrentHealth;
            CurrentHealth -= damage;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0f, MaxHealth);

            HandleDeath();
        }

        void HandleDeath()
        {
            if (m_IsDead)
                return;

            // call OnDie action
            if (CurrentHealth <= 0f)
            {
                m_IsDead = true;
                damageArea.SetActive(true);
                Destroy(TNT);
                Invoke("WaitForExplosion", 1.5f);

            }
        }
        void WaitForExplosion()
        {
            Destroy(this.gameObject);
        }
    }
}
