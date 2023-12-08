using System;
using UnityEngine;

namespace Asteroids.Domain.Inputs
{
    public class StandardInput : MonoBehaviour, Input
    {
        public event Action OnFirePerformed;
        public float MovementX => _movementX;
        public float MovementY => _movementY;

        private float _movementX;
        private float _movementY;

        private void Update()
        {
            _movementX = UnityEngine.Input.GetAxisRaw("Horizontal");
            _movementY = UnityEngine.Input.GetAxisRaw("Vertical");
        }
    }
}
