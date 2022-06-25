using OfficeFever.PlayerInput;
using UnityEngine;

namespace OfficeFever.PlayerAnimation
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField] Animator animator;
        [SerializeField] AnimatorOverrideController overrideController;
        [SerializeField] InputController inputController;

        private void Update()
        {
            if(inputController.IsMoving)
            {
                animator.SetBool("moving", true);
            }
            else
            {
                animator.SetBool("moving", false);
            }
        }
    }
}

