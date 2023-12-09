using UnityEngine;

namespace Asteroids.Domain.Shooting
{
    public class PlayerShooter : MonoBehaviour, Shootable
    {
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Transform _projectileSpawnpoint;
        private Shootable _shooter;

        private void Awake()
        {
            _shooter = new Shooter(_projectilePrefab, _projectileSpawnpoint);
        }

        public void Shoot()
        {
            _shooter.Shoot();
        }
    }
}
