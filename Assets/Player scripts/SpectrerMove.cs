using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectreMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed;

    public float jumpSpeed = 8.0f;
    public float gravity_speed = 20.0f;
    public bool isGrounded = true;

    public float Timer = 0.0f;
    public float targetTime = 1.0f;

    private Rigidbody _body;
    private Vector3 moveDirection = Vector3.zero;


    private void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Timer -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 LateralMovement = transform.right * horizInput;

        moveDirection = forwardMovement + LateralMovement;
        if (Input.GetButton("Jump") && isGrounded && Timer < 0)
        {
            Timer = targetTime;
            _body.velocity += jumpSpeed * Vector3.up;
        }
        moveDirection.y -= gravity_speed * Time.fixedDeltaTime;
        transform.position += moveDirection * Time.deltaTime;
    }

}
