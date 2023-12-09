using System;
using UnityEngine;

namespace Asteroids.Domain.Inputs
{
    public interface Input
    {
        bool FirePressed { get; }
        float MovementX { get; }
        float MovementY { get; }
    }
}
