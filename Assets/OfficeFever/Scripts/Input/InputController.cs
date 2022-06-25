using UnityEngine;

namespace OfficeFever.PlayerInput
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private FloatingJoystick joystick;
        private bool isMoving;
        private Vector2 direction;
        
        public bool IsMoving { get { return isMoving;}}
        public Vector2 Direction { get { return direction;}}

        private void Update()
        {
            direction.x = joystick.Horizontal;
            direction.y = joystick.Vertical;

            if(direction == Vector2.zero)
            {
                isMoving = false;
            }
            else
            {
                isMoving = true;
            }
        }
    }
}

