using System;
using Asteroids.Domain.Markers;
using UnityEngine;

namespace Asteroids.Domain.Combat
{
    public class ProjectileColliderDamager : MonoBehaviour
    {
        public event Action OnTargetHit;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.attachedRigidbody.gameObject.TryGetComponent(out Player player))
            {
                return;
            }

            if (other.collider.attachedRigidbody.gameObject.TryGetComponent(out Health health))
            {
                health.Damage();
                gameObject.SetActive(false);
                OnTargetHit?.Invoke();
            }
        }
    }
}
