using UnityEngine;

namespace Asteroids.Domain.Spawning
{
    public class Spawner<T> where T : MonoBehaviour
    {
        private T _prefab;
        private Vector3 _position;
        private Quaternion _rotation;
        private Transform _parent;

        public Spawner(T prefab)
        {
            _prefab = prefab;
        }

        public void SetPosition(Vector3 position)
        {
            _position = position;
        }

        public void SetRotation(Quaternion rotation)
        {
            _rotation = rotation;
        }

        public void SetParent(Transform parent)
        {
            _parent = parent;
        }

        public T Spawn()
        {
            return Object.Instantiate(_prefab, _position, _rotation, _parent);
        }
    }
}
