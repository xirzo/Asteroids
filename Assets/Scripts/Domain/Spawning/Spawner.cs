using UnityEngine;

namespace Asteroids.Domain.Spawning
{
    public class Spawner<T> where T : MonoBehaviour
    {
        private T _prefab;
        private Transform _spawnpoint;

        public Spawner(T prefab, Transform spawnpoint)
        {
            _prefab = prefab;
            _spawnpoint = spawnpoint;
        }

        public T Spawn()
        {
            return Object.Instantiate(_prefab, _spawnpoint.position, _spawnpoint.rotation);
        }
    }
}
