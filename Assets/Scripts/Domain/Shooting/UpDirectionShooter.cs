using UnityEngine;

namespace Asteroids.Domain.Shooting
{
    public class UpDirectionShooter : MonoBehaviour, Shooter
    {
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Transform _projectileSpawnpoint;
        private Shooter _shooter;

        private void Awake()
        {
            _shooter = new DefaultShooter(_projectilePrefab, _projectileSpawnpoint);
        }

        public void Shoot()
        {
            _shooter.Shoot();
        }
    }
}
