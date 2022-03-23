using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarLauncher : MonoBehaviour
{
    [SerializeField]
    private BezierSpline path;

    public Animator StarAnimator;
    public GameObject trail;

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

        if (character != null && character.GetComponent<Character>() == _character)
        {
            Transform star = this.transform.Find("Star").Find("Plane");
            _character.SetNewState(CharacterStateEnum.FLYING);
            _character.transform.SetPositionAndRotation(star.position, star.rotation * Quaternion.Euler(new Vector3(90f, 0f, 0f)));
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
        walker.transform.up = path.GetVelocity(0);
        StarLauncherWalker walkerComp = walker.AddComponent<StarLauncherWalker>();
        walkerComp.spline = path;
        walkerComp.duration = 5f;
        walkerComp.lookForward = false;
        walkerComp.mode = SplineWalkerMode.Once;
        walkerComp.character = character;
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
