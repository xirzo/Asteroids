using Asteroids.Domain.Spawning;
using UnityEngine;

namespace Asteroids.Domain.Shooting
{
    public class Shooter : Shootable
    {
        private Spawner<Projectile> _spawner;

        public Shooter(Projectile projectilePrefab, Transform projectileSpawnpoint)
        {
            _spawner = new Spawner<Projectile>(projectilePrefab);
            _spawner.SetPosition(projectileSpawnpoint.position);
            _spawner.SetRotation(projectileSpawnpoint.rotation);
        }

        public void Shoot()
        {
            var newProjectile = _spawner.Spawn();
            newProjectile.Launch();
        }
    }
}
