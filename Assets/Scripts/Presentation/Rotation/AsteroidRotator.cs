using UnityEngine;

namespace Asteroids.Presentation.Rotation
{
    public class AsteroidRotator : MonoBehaviour
    {
        [SerializeField, Range(-360, 0)] private float _rotationSpeedMinLimit = -360;
        [SerializeField, Range(0, 360)] private float _rotationSpeedMaxLimit = 360;

        private float _rotationSpeed;
        private float _rotationZ;

        private void SetRandomRotationSpeed()
        {
            _rotationSpeed = Random.Range(_rotationSpeedMinLimit, _rotationSpeedMaxLimit);
        }

        private void Awake()
        {
            SetRandomRotationSpeed();
        }

        private void CalculateRotationZ()
        {
            _rotationZ = Time.deltaTime * _rotationSpeed;
        }

        private void ApplyRotatation()
        {
            transform.Rotate(new Vector3(0, 0, _rotationZ));
        }

        private void Update()
        {
            CalculateRotationZ();
            ApplyRotatation();
        }
    }
}
