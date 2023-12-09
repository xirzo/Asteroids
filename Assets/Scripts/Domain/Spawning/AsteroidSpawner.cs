using Asteroids.Domain.Moving;
using UnityEngine;

namespace Asteroids.Domain.Spawning
{
    [RequireComponent(typeof(OutOfCameraPointSearcher))]
    public class AsteroidSpawner : MonoBehaviour
    {
        [SerializeField] private AsteroidMovement _prefabToSpawn;
        [SerializeField] private Transform _objectsParent;
        [SerializeField] private Transform _player;
        [Space]
        [SerializeField, Min(0)] private float _timeBetweenSpawns = 1f;

        private OutOfCameraPointSearcher _pointSearcher;
        private Spawner<AsteroidMovement> _spawner;

        private void Awake()
        {
            TryGetComponent(out _pointSearcher);

            _spawner = new Spawner<AsteroidMovement>(_prefabToSpawn);
        }

        private AsteroidMovement Spawn()
        {
            _spawner.SetPosition(_pointSearcher.GetRandomPointOut());
            _spawner.SetRotation(Quaternion.identity);
            _spawner.SetParent(_objectsParent);
            return _spawner.Spawn();
        }

        private void Launch(AsteroidMovement asteroid)
        {
            asteroid.Initialize(_player.position);
            asteroid.Launch();
        }

        public void SpawnAndLaunch()
        {
            var newAsteroid = Spawn();
            Launch(newAsteroid);
        }

        private void Start()
        {
            InvokeRepeating("SpawnAndLaunch", 0, _timeBetweenSpawns);
        }
    }
}
