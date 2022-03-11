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
        GetComponentInParent<StarLauncherTrigger>().Launch();
    }

    public void ResetTrigger()
    {
        GetComponentInParent<StarLauncherTrigger>().ResetTrigger();
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
