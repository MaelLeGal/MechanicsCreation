using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarLauncherTrigger : MonoBehaviour
{
    [SerializeField]
    private BezierSpline path;

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
            StarLauncherWalker walker = player.AddComponent<StarLauncherWalker>();
            walker.spline = path;
            walker.duration = 5f;
            walker.lookForward = true;
            walker.mode = SplineWalkerMode.Once;
            triggered = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player = null;
    }
}
