using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
    public string animationName;
    public Cinemachine.CinemachineVirtualCamera camera;
    public CameraTargets cameraTargets;
}

[Serializable]
public struct CameraTargets
{
    public Transform follow;
    public Transform lookAt;
}

public class StarLauncher : MonoBehaviour
{
    [SerializeField]
    private BezierSpline path;

    public Animator StarAnimator;
    public GameObject trail;
    public Cinemachine.CinemachineFreeLook mainCamera;

    [SerializeField]
    private PathEvents[] events;

    private GameObject character;

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

        if (character != null && character.GetComponent<Character>() == _character)
        {
            Transform star = this.transform.Find("Star").Find("Plane");
            _character.SetNewState(CharacterStateEnum.FLYING);
            character.gameObject.transform.position = star.position;
            Debug.Log(character.transform.eulerAngles);
            character.gameObject.transform.eulerAngles = this.gameObject.transform.eulerAngles;
            Debug.Log(this.gameObject.transform.eulerAngles);
            Debug.Log(character.transform.eulerAngles);
            Debug.Log(character);
            StarAnimator.SetTrigger("TriggerLaunch");
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
        character.transform.localEulerAngles = new Vector3(90, 0, 0);
        walker.transform.up = path.GetVelocity(0);
        StarLauncherWalker walkerComp = walker.AddComponent<StarLauncherWalker>();
        walkerComp.spline = path;
        walkerComp.duration = 5f;
        walkerComp.lookForward = true;
        walkerComp.mode = SplineWalkerMode.Once;
        walkerComp.character = character;
        walkerComp.Events = new Queue<PathEvents>(events.OrderBy(e => e.progress));
        walkerComp.mainCamera = mainCamera;
    }

    private void AttachTrailToCharacter()
    {
        GameObject trailGO = Instantiate(trail, character.transform);
    }

    public void Launch()
    {
        CreateWalker();
        AttachTrailToCharacter();
    }

    public void ResetAnimationTrigger()
    {
        Debug.Log("Called");
        StarAnimator.ResetTrigger("TriggerLaunch");
    }
}
