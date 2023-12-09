using UnityEngine;
using Input = Asteroids.Domain.Inputs.Input;

namespace Asteroids.Domain.Moving
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Input))]
    public class PlayerMovement : MonoBehaviour, Movement
    {
        public bool IsMoving => _rigidbody.velocity.magnitude > 0.01f;
        public Vector3 Velocity => _rigidbody.velocity;

        [SerializeField, Min(0)] private float _movementSpeed = 5f;
        [SerializeField, Min(0)] private float _rotationSpeed = 50f;
        private Rigidbody2D _rigidbody;
        private Input _input;
        private Vector3 _velocity;
        private float _rotationZ;
        private Quaternion _turnRotation;

        private void Awake()
        {
            TryGetComponent(out _input);
            TryGetComponent(out _rigidbody);
        }

        private void CalculateVelocity()
        {
            _velocity = transform.up * _input.MovementY * _movementSpeed;
        }

        private void ApplyMovement()
        {
            _rigidbody.velocity = _velocity;
        }

        private void CalculateTurnRotation()
        {
            _rotationZ += -_input.MovementX * _rotationSpeed * Time.deltaTime;
            _turnRotation = Quaternion.Euler(new Vector3(0, 0, _rotationZ));
        }

        private void ApplyRotation()
        {
            _rigidbody.MoveRotation(_turnRotation);
        }

        private void FixedUpdate()
        {
            CalculateVelocity();
            ApplyMovement();
            CalculateTurnRotation();
            ApplyRotation();
        }
    }
}
