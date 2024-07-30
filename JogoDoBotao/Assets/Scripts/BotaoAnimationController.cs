using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoAnimationController : MonoBehaviour
{
    [SerializeField] private Animator agentAnimator;

    private void SetTypeAnimation(int val)
    {
        agentAnimator.SetInteger("Tipo", val);
    }

    public void AnimateType(int val)
    {
        SetTypeAnimation(val);
    }
}
