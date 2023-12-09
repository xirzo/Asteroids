using UnityEngine;
using Input = Asteroids.Domain.Inputs.Input;

namespace Asteroids.Domain.Shooting
{
    [RequireComponent(typeof(Input))]
    [RequireComponent(typeof(Shooter))]
    public class ShooterInputAdapter : MonoBehaviour
    {
        private Input _input;
        private Shooter _shooter;

        private void Awake()
        {
            TryGetComponent(out _input);
            TryGetComponent(out _shooter);
        }

        private void GetFireInputAndShoot()
        {
            if (_input.FirePressed == true)
            {
                _shooter.Shoot();
            }
        }

        private void Update()
        {
            GetFireInputAndShoot();
        }
    }
}
