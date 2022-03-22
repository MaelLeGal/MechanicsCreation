using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchTimelineAnimation : MonoBehaviour
{
    public ParticleSystem ChargeUp;
    public ParticleSystem MoveIn;
    public ParticleSystem Burst;

    public void LaunchPlayer()
    {
        GetComponentInParent<StarLauncher>().Launch();
    }

    public void ResetTrigger()
    {
        GetComponentInParent<StarLauncher>().ResetAnimationTrigger();
    }

    public void LaunchStarChargeUpEmitter()
    {
        ChargeUp.Play();
    }

    public void StopStarChargeUpEmitter()
    {
        ChargeUp.Stop();
    }

    public void LaunchStarMoveInEmitter()
    {
        MoveIn.Play();
    }

    public void StopStarMoveInEmitter()
    {
        MoveIn.Stop();
    }

    public void LaunchStarBurstEmitter()
    {
        Burst.Play();
    }

    public void StopStarBurstEmitter()
    {
        Burst.Stop();
    }
}
