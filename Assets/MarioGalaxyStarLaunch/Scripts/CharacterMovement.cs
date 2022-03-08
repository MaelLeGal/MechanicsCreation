using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{ 
    public float speed = 10f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;

    public bool flying = false;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
            /*if (flying)
            {
                flying = false;
            }*/
        }
        if (!flying)
        {
            Debug.Log("Je passe ici");
            moveDirection.y -= gravity * Time.deltaTime;
        }
        controller.Move(moveDirection * Time.deltaTime);
    }
}
