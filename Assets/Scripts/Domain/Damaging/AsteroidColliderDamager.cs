using UnityEngine;

namespace Asteroids.Domain.Damaging
{
    [RequireComponent(typeof(Health))]
    public class AsteroidColliderDamager : MonoBehaviour
    {
        [SerializeField, Min(0)] private float _timeBeforeAbleToDamageAgain = 0.75f;

        private Health _health;

        private void Awake()
        {
            TryGetComponent(out _health);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.attachedRigidbody.gameObject.TryGetComponent(out Health health))
            {
                health.Damage();
                _health.Damage(_health.MaxHealthPoints);
            }
        }
    }
}
