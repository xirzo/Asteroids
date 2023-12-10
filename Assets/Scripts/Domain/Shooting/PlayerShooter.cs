using System.Collections;
using UnityEngine;

namespace Asteroids.Domain.Shooting
{
    public class PlayerShooter : MonoBehaviour, Shootable
    {
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Transform _projectileSpawnpoint;
        [Space]
        [SerializeField, Min(0)] private float _timeBetweenShots = 1.25f;
        private Shootable _shooter;
        private bool _canShoot = true;

        private void Awake()
        {
            _shooter = new Shooter(_projectilePrefab, _projectileSpawnpoint);
        }

        private IEnumerator StartShootingDelay()
        {
            _canShoot = false;
            float timeElapsed = 0;

            while (timeElapsed <= 1)
            {
                timeElapsed += Time.deltaTime * _timeBetweenShots;
                yield return null;
            }

            _canShoot = true;
        }

        public void Shoot()
        {
            if (_canShoot == false)
            {
                return;
            }

            _shooter.Shoot();
            StartCoroutine(StartShootingDelay());
        }

        private void OnDestroy()
        {
            StopCoroutine(StartShootingDelay());
        }
    }
}
