using OfficeFever.PlayerInput;
using UnityEngine;

namespace OfficeFever.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private MovementSettings _movementSettings;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private InputController _inputController;

        private void Update()
        {
            Vector3 dir = new Vector3(_inputController.Direction.x * _movementSettings.MoveSpeed, 
            0f, _inputController.Direction.y * _movementSettings.MoveSpeed);
            _characterController.Move(dir * Time.deltaTime);

            if (_inputController.IsMoving)
            {
                Quaternion lookRotation = Quaternion.LookRotation(dir, transform.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 
                _movementSettings.RotationSpeed * Time.deltaTime);
            }
        }
    }
}

