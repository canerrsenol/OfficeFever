using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfficeFever.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private MovementSettings movementStats;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private FloatingJoystick floatingJoystick;

        private void Update()
        {
            Vector3 dir = new Vector3(floatingJoystick.Horizontal * 5f, 0f, floatingJoystick.Vertical * 5f);
            characterController.Move(dir * Time.deltaTime);
        }
    }
}

