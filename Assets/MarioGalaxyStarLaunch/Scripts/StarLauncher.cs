using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarLauncher : MonoBehaviour
{
    [SerializeField]
    private BezierSpline path;

    GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<CharacterInputManager>().starLauncherTriggerEvent += onTrigger;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onTrigger(Character _character)
    {
        if (character != null)
        {
            CreateWalker();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other is CharacterController)
        {
            character = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other is CharacterController)
        {
            character = null;
        }
    }

    private void CreateWalker()
    {
        GameObject walker = new GameObject("Walker");

        walker.transform.parent = this.transform;
        walker.transform.localPosition = Vector3.zero;
        character.transform.SetParent(walker.transform);
        walker.transform.up = path.GetVelocity(0);
        StarLauncherWalker walkerComp = walker.AddComponent<StarLauncherWalker>();
        walkerComp.spline = path;
        walkerComp.duration = 5f;
        walkerComp.lookForward = false;
        walkerComp.mode = SplineWalkerMode.Once;
        walkerComp.player = character;
    }
}
