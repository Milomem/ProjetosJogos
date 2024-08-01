using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator playerAnimator;

    // Método para definir um trigger no Animator
    public void SetTrigger(string triggerName)
    {
        if (playerAnimator != null)
        {
            playerAnimator.SetTrigger(triggerName);
        }
    }

    // Método já existente para reproduzir animações por nome
    public void PlayAnimation(string animationName)
    {
        if (playerAnimator != null)
        {
            playerAnimator.Play(animationName);
        }
    }
}
