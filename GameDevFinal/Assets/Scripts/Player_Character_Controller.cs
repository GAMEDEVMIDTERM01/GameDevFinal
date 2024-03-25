using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Character_Controller : MonoBehaviour
{
    private Rigidbody2D playerRigid;
    private bool isGrounded;

    [Header("Ground Checking")]
    public Transform GroundCheck;
    public LayerMask groundLayer;
    public SpriteRenderer playerSprite;

    public float speed;
    public float jumpForce;

    private PolygonCollider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(GroundCheck.position, new Vector2(0.1494f, 1f), CapsuleDirection2D.Vertical, 0, groundLayer);
    }
    private void FixedUpdate()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }
    private void Move()
    {
        Vector2 movement = new Vector2(speed, playerRigid.velocity.y);
        playerRigid.velocity = movement;


    }
    private void Jump()
    {
        playerRigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
