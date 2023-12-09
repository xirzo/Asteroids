using UnityEngine;

namespace Asteroids.Domain.Shooting
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField, Range(0, 25)] private float _launchInitialForce = 1f;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            TryGetComponent(out _rigidbody);
        }

        public void Launch()
        {
            _rigidbody.AddForce(transform.up * _launchInitialForce, ForceMode2D.Impulse);
        }
    }
}
