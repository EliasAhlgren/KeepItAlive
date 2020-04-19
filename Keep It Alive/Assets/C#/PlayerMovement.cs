using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController playerController;

    [Range(0.0f, 100.0f)]
    public float speed = 15;
    public float rocketSpeed = 5;

    public AnimationCurve rocketCurve;

    public float airTime;

    [SerializeField] Vector3 playerVelocity;

    public float gravity = -9.81f;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [SerializeField] bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        float x = -Input.GetAxis("Horizontal");
        float z = -Input.GetAxis("Vertical");

        

        Vector3 MoveAmount = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.Space))
        {
            MoveAmount.y = rocketSpeed * rocketCurve.Evaluate(airTime);
            airTime += Time.deltaTime;
        }
        else
        {
            airTime = 0;
        }

        playerController.Move(MoveAmount * speed * Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;

        playerController.Move(playerVelocity * Time.deltaTime);

    }
}
