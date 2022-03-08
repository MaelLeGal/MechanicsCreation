using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct PathEvents
{
    [Range(0, 1)]
    public float progress;
    public Vector3 rotation;
}

public class StarLauncherTrigger : MonoBehaviour
{

    [SerializeField]
    private BezierSpline path;

    [SerializeField]
    private PathEvents[] events;

    private GameObject player;

    private bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            triggered = true;
            player.GetComponent<CharacterMovement>().flying = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.gameObject;
    }

    private void OnTriggerStay(Collider other)
    {
        player = other.gameObject;
        if (triggered)
        {
            GameObject walker = new GameObject("Walker");
            walker.transform.parent = this.transform;
            walker.transform.localPosition = Vector3.zero;
            player.transform.SetParent(walker.transform);
            StarLauncherWalker walkerComp = walker.AddComponent<StarLauncherWalker>();
            walkerComp.spline = path;
            walkerComp.duration = 5f;
            walkerComp.lookForward = false;
            walkerComp.mode = SplineWalkerMode.Once;
            walkerComp.Events = events;

            player.GetComponent<CharacterController>().enabled = false;
            triggered = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player = null;
    }
}
