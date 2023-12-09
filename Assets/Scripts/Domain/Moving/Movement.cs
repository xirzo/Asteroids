using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Domain.Moving
{
    public interface Movement
    {
        bool IsMoving { get; }
        Vector3 Velocity { get; }
    }
}
