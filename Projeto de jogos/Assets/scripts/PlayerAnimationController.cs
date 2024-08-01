using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator playerAnimator;

    // M�todo para definir um trigger no Animator
    public void SetTrigger(string triggerName)
    {
        if (playerAnimator != null)
        {
            playerAnimator.SetTrigger(triggerName);
        }
    }

    // M�todo j� existente para reproduzir anima��es por nome
    public void PlayAnimation(string animationName)
    {
        if (playerAnimator != null)
        {
            playerAnimator.Play(animationName);
        }
    }
}
