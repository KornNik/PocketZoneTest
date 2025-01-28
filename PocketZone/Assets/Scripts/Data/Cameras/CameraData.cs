using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CamerasData", menuName = "Data/Camera/CamerasData")]
    public class CameraData : ScriptableObject
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _offsetDistance;
        [SerializeField] private float _movementDuration;

        public float MovementSpeed => _movementSpeed;
        public float OffsetDistance => _offsetDistance;
        public float MovementDuration => _movementDuration;
    }
}