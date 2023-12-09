using Asteroids.Domain.Spawning;
using UnityEngine;

namespace Asteroids.Domain.Shooting
{
    public class Shooter : Shootable
    {
        private Spawner<Projectile> _spawner;
        private Transform _projectileSpawnpoint;

        public Shooter(Projectile projectilePrefab, Transform projectileSpawnpoint)
        {
            _spawner = new Spawner<Projectile>(projectilePrefab);
            _projectileSpawnpoint = projectileSpawnpoint;
        }

        private void UpdateSpawnPositionAndRotation()
        {
            _spawner.SetPosition(_projectileSpawnpoint.position);
            _spawner.SetRotation(_projectileSpawnpoint.rotation);
        }

        public void Shoot()
        {
            UpdateSpawnPositionAndRotation();

            var newProjectile = _spawner.Spawn();
            newProjectile.Launch();
        }
    }
}
