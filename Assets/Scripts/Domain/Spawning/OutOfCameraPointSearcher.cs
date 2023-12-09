using UnityEngine;

namespace Asteroids.Domain.Spawning
{
    public class OutOfCameraPointSearcher : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [Space]
        [SerializeField, Min(0)] private float _distanceFromCameraPlaneUpperLimitMultiplier = 0.75f;
        [SerializeField, Min(0)] private float _distanceFromCameraPlaneLowerLimitMultiplier = 0.1f;

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

        private Vector3 GetLeftRandomPoint()
        {
            float upperLimitX = _bottomLeftPosition.x - Mathf.Abs(_bottomLeftPosition.x * _distanceFromCameraPlaneUpperLimitMultiplier);
            float lowerLimitX = _bottomLeftPosition.x - Mathf.Abs(_bottomLeftPosition.x * _distanceFromCameraPlaneLowerLimitMultiplier);

            float lowerLimitY = _bottomLeftPosition.y;
            float upperLimitY = _topLeftPosition.y;

            float x = Random.Range(lowerLimitX, upperLimitX);
            float y = Random.Range(lowerLimitY, upperLimitY);

            return new Vector3(x, y);
        }

        private Vector3 GetRightRandomPoint()
        {
            float upperLimitX = _bottomRightPosition.x + Mathf.Abs(_bottomRightPosition.x * _distanceFromCameraPlaneUpperLimitMultiplier);
            float lowerLimitX = _bottomRightPosition.x + Mathf.Abs(_bottomRightPosition.x * _distanceFromCameraPlaneLowerLimitMultiplier);

            float lowerLimitY = _bottomRightPosition.y;
            float upperLimitY = _topRightPosition.y;

            float x = Random.Range(lowerLimitX, upperLimitX);
            float y = Random.Range(lowerLimitY, upperLimitY);

            return new Vector3(x, y);
        }

        private Vector3 GetUpperRandomPoint()
        {
            float lowerLimitX = _topLeftPosition.x;
            float upperLimitX = _topRightPosition.x;

            float upperLimitY = _topLeftPosition.y + Mathf.Abs(_topLeftPosition.x * _distanceFromCameraPlaneUpperLimitMultiplier);
            float lowerLimitY = _topLeftPosition.y + Mathf.Abs(_topLeftPosition.x * _distanceFromCameraPlaneLowerLimitMultiplier);

            float x = Random.Range(lowerLimitX, upperLimitX);
            float y = Random.Range(lowerLimitY, upperLimitY);

            return new Vector3(x, y);
        }

        private Vector3 GetLowerRandomPoint()
        {
            float lowerLimitX = _bottomLeftPosition.x;
            float upperLimitX = _bottomRightPosition.x;

            float upperLimitY = _bottomLeftPosition.y - Mathf.Abs(_topLeftPosition.x * _distanceFromCameraPlaneUpperLimitMultiplier);
            float lowerLimitY = _bottomLeftPosition.y - Mathf.Abs(_topLeftPosition.x * _distanceFromCameraPlaneLowerLimitMultiplier);

            float x = Random.Range(lowerLimitX, upperLimitX);
            float y = Random.Range(lowerLimitY, upperLimitY);

            return new Vector3(x, y);
        }

        public Vector3 GetRandomPointOut()
        {
            int random = Random.Range(0, 4);

            switch (random)
            {
                case 0:
                    return GetUpperRandomPoint();
                case 1:
                    return GetLeftRandomPoint();
                case 2:
                    return GetLowerRandomPoint();
                case 3:
                    return GetRightRandomPoint();
            }

            return Vector3.zero;
        }
    }
}
