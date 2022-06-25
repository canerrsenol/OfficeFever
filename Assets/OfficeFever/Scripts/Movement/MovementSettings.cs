using UnityEngine;

namespace OfficeFever.Movement
{
    [CreateAssetMenu(menuName = "OfficeFever/Movement/Movement Settings")]
    public class MovementSettings : ScriptableObject
    {
        [Header("Moving Settings")]
        [SerializeField] private float moveSpeed = 5f;

        public float MoveSpeed { get { return moveSpeed;}}

        [Header("Rotation Settings")]
        [SerializeField] private float rotationSpeed = 5f;

        public float RotationSpeed { get { return rotationSpeed;}}
    }
}

