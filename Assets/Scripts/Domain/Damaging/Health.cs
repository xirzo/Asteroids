using System;
using UnityEngine;

namespace Asteroids.Domain.Damaging
{
    public class Health : MonoBehaviour
    {
        public event Action<int> OnDamaged;
        public int MaxHealthPoints => _maxHealthPoints;
        public int CurrentHealthPoints => _currentHealthPoints;
        [SerializeField, Min(1)] private int _maxHealthPoints = 1;
        private int _currentHealthPoints;
        private Vector3 _startPoisiton;
        private Quaternion _startRotation;
        private void SetCurrentHealthToMax()
        {
            _currentHealthPoints = _maxHealthPoints;
        }

        private void Awake()
        {
            _startPoisiton = transform.position;
            _startRotation = transform.rotation;

            SetCurrentHealthToMax();
        }

        private void Die()
        {
            gameObject.SetActive(false);
        }

        private void ResetPositionAndRotation()
        {
            transform.position = _startPoisiton;
            transform.rotation = _startRotation;
        }

        public void Damage(int points = 1)
        {
            if (points <= 0)
            {
                throw new ArgumentOutOfRangeException("Points number should be at least 1!");
            }

            if (_currentHealthPoints - points <= 0)
            {
                _currentHealthPoints = 0;
                Die();
                OnDamaged?.Invoke(_currentHealthPoints);
                return;
            }

            _currentHealthPoints -= points;
            ResetPositionAndRotation();
            OnDamaged?.Invoke(_currentHealthPoints);
        }

        public void Heal(int points = 1)
        {
            if (points <= 0)
            {
                throw new ArgumentOutOfRangeException("Points number should be at least 1!");
            }

            if (_currentHealthPoints + points > _maxHealthPoints)
            {
                _currentHealthPoints = _maxHealthPoints;
                return;
            }

            _currentHealthPoints += points;
        }
    }
}
