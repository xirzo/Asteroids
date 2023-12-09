using UnityEngine;

namespace Asteroids.Domain.Shooting
{
    public class DefaultShooter : Shooter
    {
        private Projectile _projectilePrefab;
        private Transform _projectileSpawnpoint;

        public DefaultShooter(Projectile projectilePrefab, Transform projectileSpawnpoint)
        {
            _projectilePrefab = projectilePrefab;
            _projectileSpawnpoint = projectileSpawnpoint;
        }

        public void Shoot()
        {
            var newProjectile = Object.Instantiate(_projectilePrefab, _projectileSpawnpoint.position, _projectileSpawnpoint.rotation);
            newProjectile.Launch();
        }
    }
}
