using System.Collections;
using Asteroids.Domain.Combat;
using UnityEngine;

namespace Asteroids.Domain.Combat
{
    public class AsteroidColliderDamager : MonoBehaviour
    {
        [SerializeField, Min(0)] private float _timeBeforeAbleToDamageAgain = 0.75f;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.attachedRigidbody.gameObject.TryGetComponent(out Health health))
            {
                health.Damage();
                gameObject.SetActive(false);
            }
        }
    }
}
