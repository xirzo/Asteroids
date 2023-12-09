using System.Collections;
using Asteroids.Domain.Combat;
using UnityEngine;

namespace Asteroids.Domain.Combat
{
    public class AsteroidColliderDamager : MonoBehaviour
    {
        [SerializeField, Min(0)] private float _timeBeforeAbleToDamageAgain = 0.75f;
        private float _timeBeforeAbleToDamageElapsed;
        private bool _canDamage = true;

        private IEnumerator StartCanDamageCountdown()
        {
            _canDamage = false;
            _timeBeforeAbleToDamageElapsed = 0;

            while (_timeBeforeAbleToDamageElapsed <= 1f)
            {
                _timeBeforeAbleToDamageElapsed += Time.deltaTime / _timeBeforeAbleToDamageAgain;
                yield return null;
            }

            _canDamage = true;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_canDamage == false)
            {
                return;
            }

            if (other.collider.attachedRigidbody.gameObject.TryGetComponent(out Health health))
            {
                health.Damage();
                StartCoroutine(StartCanDamageCountdown());
            }
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}
