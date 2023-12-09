using Asteroids.Domain.Combat;
using UnityEngine;

namespace Asteroids.Domain.Combat
{
    public class ProjectileColliderDamager : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.attachedRigidbody.gameObject.TryGetComponent(out Health health))
            {
                health.Damage();
            }
        }
    }
}
