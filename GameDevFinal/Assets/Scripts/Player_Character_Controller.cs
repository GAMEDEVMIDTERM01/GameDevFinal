using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Character_Controller : MonoBehaviour
{
    private Rigidbody playerRigid;
    private bool isGrounded;

    [Header("Ground Checking")]
    public Transform GroundCheck;
    public LayerMask groundLayer;

    public float forwardSpeed;
    public float sideSpeed;
    public float jumpForce;

    private CapsuleCollider playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(GroundCheck.position, new Vector2(0.1494f, 1f), CapsuleDirection2D.Vertical, 0, groundLayer);
        MoveForward();
        MoveHorizontally();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void MoveForward()
    {

        playerRigid.velocity = new Vector3(playerRigid.velocity.x, playerRigid.velocity.y, forwardSpeed * Time.deltaTime);

    }

    private void MoveHorizontally()
    {
        float direction = Input.GetAxis("Horizontal");
        float horizontalSpeed = direction * sideSpeed * Time.deltaTime;

        playerRigid.velocity = new Vector3(horizontalSpeed, playerRigid.velocity.y, playerRigid.velocity.z);
    }

    private void Jump()
    {
        playerRigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
