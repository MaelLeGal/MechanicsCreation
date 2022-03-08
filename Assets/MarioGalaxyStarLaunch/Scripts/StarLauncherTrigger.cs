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
            //walker.transform.parent = this.transform;
            //walker.transform.localPosition = Vector3.zero;
            player.transform.SetParent(walker.transform);
            StarLauncherWalker walkerComp = walker.AddComponent<StarLauncherWalker>();
            walkerComp.spline = path;
            walkerComp.duration = 5f;
            walkerComp.lookForward = true;
            walkerComp.mode = SplineWalkerMode.Once;
            triggered = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player = null;
    }
}
