using UnityEngine;

namespace Asteroids.Domain.Moving
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class AsteroidMovement : MonoBehaviour, Movement
    {
        public bool IsMoving => _rigidbody2D.velocity.magnitude > 0.01f;
        public Vector3 Velocity => _rigidbody2D.velocity;
        [SerializeField, Range(0, 20)] private float _initialForceLowerLimit = 5f;
        [SerializeField, Range(20, 30)] private float _initialForceUpperLimit = 5f;
        private float _initialForce;
        private Rigidbody2D _rigidbody2D;
        private Vector3 _playerPosition;
        private Vector3 _directionToPlayer;

        private void Awake()
        {
            TryGetComponent(out _rigidbody2D);
        }

        private void CalculateDirectionToPlayer()
        {
            _directionToPlayer = _playerPosition - transform.position;
        }

        private void CalculateInitialForce()
        {
            _initialForce = Random.Range(_initialForceLowerLimit, _initialForceUpperLimit);
        }

        private void LaunchTowardsPlayer()
        {
            _rigidbody2D.AddForce(_directionToPlayer * _initialForce, ForceMode2D.Impulse);
        }

        public void Launch()
        {
            CalculateDirectionToPlayer();
            CalculateInitialForce();
            LaunchTowardsPlayer();
        }

        public void Initialize(Vector3 playerPosition)
        {
            _playerPosition = playerPosition;
        }
    }
}
