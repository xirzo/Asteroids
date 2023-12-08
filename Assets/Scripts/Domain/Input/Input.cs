using System;
using UnityEngine;

namespace Asteroids.Domain.Inputs
{
    public interface Input
    {
        event Action OnFirePerformed;
        float MovementX { get; }
        float MovementY { get; }
    }
}
