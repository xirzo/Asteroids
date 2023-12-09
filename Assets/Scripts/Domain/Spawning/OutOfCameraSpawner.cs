using UnityEngine;

namespace Asteroids.Domain.Spawning
{
    [RequireComponent(typeof(OutOfCameraPointSearcher))]
    public class OutOfCameraSpawner : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour _prefabToSpawn;

        private OutOfCameraPointSearcher _pointSearcher;
        private Spawner<MonoBehaviour> _spawner;

        private void Awake()
        {
            TryGetComponent(out _pointSearcher);

            _spawner = new Spawner<MonoBehaviour>(_prefabToSpawn);
        }

        public void Spawn()
        {

        }
    }
}
