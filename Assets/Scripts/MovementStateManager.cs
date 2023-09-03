using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3;
    [HideInInspector] public Vector3 dir;
    private float hzInput, vInput;
    private CharacterController _characterController;

    [SerializeField] private float groundYOffSet;
    [SerializeField] private LayerMask groundMask;
    private Vector3 spherePos;

    [SerializeField] private float gravity = -9.81f;
    private Vector3 velocity;
    
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetDirectionAndMove();
        Gravity();
    }

    private void GetDirectionAndMove()
    {
        hzInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        dir = transform.forward * vInput + transform.right * hzInput;

        _characterController.Move(dir * moveSpeed * Time.deltaTime);
    }

    private bool isGrounded()
    {
        spherePos = new Vector3(transform.position.x, transform.position.y - groundYOffSet, transform.position.z);

        if (Physics.CheckSphere(spherePos, _characterController.radius - 0.05f, groundMask)) return true;
        return false;
    }

    private void Gravity()
    {
        if (!isGrounded())
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else if(velocity.y < 0)
        {
            velocity.y = -2;
        }

        _characterController.Move(velocity * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(spherePos, _characterController.radius - 0.05f);
    }
}
