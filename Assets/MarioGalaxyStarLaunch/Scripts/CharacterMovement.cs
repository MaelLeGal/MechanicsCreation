using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/*public enum CharacterState
{
    FLYING,
    GROUNDED,
    JUMPING,
    RUNNING,
    IDLE,
    ACTIVATEDTRIGGER
}*/

//[RequireComponent(typeof(CharacterController))]
/*public class CharacterMovement : MonoBehaviour
{
    //public Camera camera;
    public CinemachineFreeLook thirdPersonCamera;

    public float speed = 10f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;

    public bool flying = false;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private HashSet<CharacterState> states = new HashSet<CharacterState>();

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        states.Add(CharacterState.IDLE);
        if (controller.isGrounded)
        {
            states.Add(CharacterState.GROUNDED);
        }
        else
        {
            states.Add(CharacterState.JUMPING);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (controller.isGrounded)
        {
            states.Add(CharacterState.GROUNDED);
        }

        if (Input.GetButton("Jump"))
        {
            states.Add(CharacterState.JUMPING);
            moveDirection.y = jumpSpeed;
        }

        if(Input.GetAxis("Horizontal") != 0|| Input.GetAxis("Vertical") != 0)
        {
            states.Add(CharacterState.RUNNING);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {

        }




        if(states.Count == 0)
        {
            states.Add(CharacterState.IDLE);
        }

        if (controller.enabled)
        {
            if (controller.isGrounded)
            {
                moveDirection = Input.GetAxis("Horizontal") * Camera.main.transform.right + Input.GetAxis("Vertical") * Camera.main.transform.forward;
                moveDirection.y = 0f;
                moveDirection *= speed;

                if (Input.GetButton("Jump"))
                {
                    moveDirection.y = jumpSpeed;
                }
            }
            if (!flying)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }
            controller.Move(moveDirection * Time.deltaTime);
        }
    }

    public void Launch()
    {
        flying = true;
        GetComponent<CharacterController>().enabled = false;
    }

    public void Landing()
    {
        GetComponent<CharacterController>().enabled = true;
        flying = false;
        thirdPersonCamera.MoveToTopOfPrioritySubqueue();
    }

    public void AddState(CharacterState state)
    {
        states.Add(state);
    }

    public void RemoveState(CharacterState state)
    {
        states.Remove(state);
    }
}*/
