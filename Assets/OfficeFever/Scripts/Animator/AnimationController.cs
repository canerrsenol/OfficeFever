using OfficeFever.PlayerInput;
using UnityEngine;

namespace OfficeFever.PlayerAnimation
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField] Animator animator;
        [SerializeField] RuntimeAnimatorController animatorController;
        [SerializeField] AnimatorOverrideController overrideController;
        [SerializeField] InputController inputController;

        private bool isOverride = false;

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

        public void AnimationOverride()
        {
            if(isOverride)
            {
                animator.runtimeAnimatorController = animatorController;
                isOverride = false;
            }
            else
            {
                animator.runtimeAnimatorController = overrideController;
                isOverride = true;
            }
        }
    }
}

