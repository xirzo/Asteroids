using UnityEngine;

namespace Asteroids.Domain.Inputs
{
    public class StandardInput : MonoBehaviour, Input
    {
        public bool FirePressed { get; private set; }
        public float MovementX { get; private set; }
        public float MovementY { get; private set; }

        private void GetInput()
        {
            FirePressed = UnityEngine.Input.GetKeyDown(KeyCode.Space);
            MovementX = UnityEngine.Input.GetAxisRaw("Horizontal");
            MovementY = UnityEngine.Input.GetAxisRaw("Vertical");
        }

        private void Update()
        {
            GetInput();
        }
    }
}
