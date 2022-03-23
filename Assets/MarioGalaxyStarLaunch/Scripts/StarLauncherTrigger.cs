using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


/*
 * Represent an event done at progress time on the curve
 * Rotation player and walker might be added
 * Name of an animation to be launched might be added
 * Switch camera might be added
 * VFX launch
 * */
[Serializable]
public struct PathEvents
{
    [Range(0, 1)]
    public float progress;
    public Vector3 rotationWalker;
    public Vector3 rotationPlayer;
    public Cinemachine.CinemachineVirtualCamera camera;
    public CameraTargets cameraTargets;
}

[Serializable]
public struct CameraTargets
{
    public Transform follow;
    public Transform lookAt;
}

public class StarLauncherTrigger : MonoBehaviour
{

    public Animator StarAnimator;

    [SerializeField]
    private BezierSpline path;

    [SerializeField]
    private PathEvents[] events;

    [SerializeField]
    private GameObject trail;

    private GameObject player;

    private bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            triggered = true;
            
        }
    }

    public void Launch()
    {
        GameObject walker = new GameObject("Walker");

        walker.transform.parent = this.transform;
        walker.transform.localPosition = Vector3.zero;
        player.transform.SetParent(walker.transform);
        walker.transform.up = path.GetVelocity(0);
        StarLauncherWalker walkerComp = walker.AddComponent<StarLauncherWalker>();
        walkerComp.spline = path;
        walkerComp.duration = 5f;
        walkerComp.lookForward = false;
        walkerComp.mode = SplineWalkerMode.Once;
        walkerComp.Events = new Queue<PathEvents>(events);
        walkerComp.character = player;

        GameObject trailGO = Instantiate(trail, player.transform);

        triggered = false;
    }

    public void ResetTrigger()
    {
        StarAnimator.ResetTrigger("TriggerLaunch");
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(triggered);
        if (other is CharacterController)
        {
            player = other.gameObject;
        }
    }

    /*private void OnTriggerStay(Collider other)
    {
        player = other.gameObject;
        if (triggered)
        {
            Debug.Log("Triggered");
            StarAnimator.SetTrigger("TriggerLaunch");

            player.GetComponent<CharacterMovement>().Launch();
            Transform star = this.transform.Find("Star").Find("Plane");
            player.transform.SetPositionAndRotation(star.position,star.rotation * Quaternion.Euler(new Vector3(90f, 0f,0f)));
            
        }
    }*/

    private void OnTriggerExit(Collider other)
    {
        triggered = false;
        player = null;
    }

}
