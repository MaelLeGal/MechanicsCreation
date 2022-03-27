using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTimelineEvents : MonoBehaviour
{
    public Animator characterAnimator;

    public void ResetRoll()
    {
        characterAnimator.ResetTrigger("Roll");
    }

    public void ResetSpin()
    {
        characterAnimator.ResetTrigger("Spin");
    }
}
