using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Domain.Spawning
{
    public class OutOfCameraPointSearcher : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        private Vector3 _topLeftPosition;
        private Vector3 _topRightPosition;
        private Vector3 _bottomLeftPosition;
        private Vector3 _bottomRightPosition;

        private void CalculatePoints()
        {
            _topLeftPosition = _camera.ViewportToWorldPoint(new Vector3(0, 1, _camera.nearClipPlane));
            _topRightPosition = _camera.ViewportToWorldPoint(new Vector3(1, 1, _camera.nearClipPlane));
            _bottomLeftPosition = _camera.ViewportToWorldPoint(new Vector3(0, 0, _camera.nearClipPlane));
            _bottomRightPosition = _camera.ViewportToWorldPoint(new Vector3(1, 0, _camera.nearClipPlane));
        }

        private void Awake()
        {
            CalculatePoints();
        }
    }
}
