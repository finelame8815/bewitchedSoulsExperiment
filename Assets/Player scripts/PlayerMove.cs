using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed;

    public GameObject otherPlayer;
    public float jumpSpeed = 8.0f;
    public float gravity_speed = 20.0f;
    public bool isGrounded = true;
    public float max_distance = 5;
    public float repulse_speed = 5.0f;

    public float Timer = 0.0f;
    public float targetTime = 1.0f;
    public bool inAnchor = false;

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

    public void setAnchor(GameObject anchor, bool isAnchor)
    {
        inAnchor = isAnchor;
        otherPlayer = anchor;
    }

    private void PlayerMovement()
    {
        float distance = Vector3.Distance(this.transform.position, otherPlayer.transform.position);
        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;
        float speed_modifier = 1;

        if (distance > 5)
            speed_modifier = (-1 / max_distance) * (distance - 5) + 1f;
        if ((distance - 5) > max_distance)
           speed_modifier = 0.01f;

        Vector3 targetDir = otherPlayer.transform.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);

        PlayerMove script = otherPlayer.GetComponent<PlayerMove>();

        if ((angle < 50.0f && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) || (script && script.inAnchor))
            speed_modifier = 1f;

        Vector3 forwardMovement = transform.forward * vertInput * speed_modifier;
        Vector3 LateralMovement = transform.right * horizInput * speed_modifier;

        moveDirection = forwardMovement + LateralMovement;
        if (Input.GetButton("Jump") && isGrounded && Timer < 0)
        {
            Timer = targetTime;
            _body.velocity += jumpSpeed * Vector3.up;
        }

        if (Input.GetKey(KeyCode.F) && isGrounded)
        {
            _body.velocity += repulse_speed * speed_modifier * -targetDir * Time.deltaTime;
        }

        moveDirection.y -= gravity_speed * Time.fixedDeltaTime;
        transform.position += moveDirection * Time.deltaTime;
    }

}
