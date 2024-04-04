using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Character_Controller : MonoBehaviour
{
    private Rigidbody playerRigid;
    private bool isGrounded;
    private bool canJump;

    [Header("Ground Checking")]
    public LayerMask groundLayer;
    public float groundCheckDistance = 1.5f;

    [Header("Frames Per Second")]
    public float animationFPS;

    [Header("Animation Sprites")]
    public Texture[] jumpSprite;
    public Texture[] jumpLeftSprite;
    public Texture[] jumpRightSprite;
    public Texture[] runSprite;
    public Texture[] leftSprite;
    public Texture[] rightSprite;

    public float forwardSpeed;
    public float sideSpeed;
    public float jumpForce;

    private CapsuleCollider playerCollider;
    private Material playerMaterial;

    private float animationTimer;
    private int currentFrame;

    private bool moveHor;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position - new Vector3(0, groundCheckDistance, 0));
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
        playerMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

        if(Physics.Raycast(transform.position, -transform.up, groundCheckDistance, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }

    }

    private void FixedUpdate()
    {
        MoveForward();
        MoveHorizontally();

        if (canJump && isGrounded)
        {
            Jump();
        }
    }

    private void MoveForward()
    {
        playerRigid.velocity = new Vector3(playerRigid.velocity.x, playerRigid.velocity.y, forwardSpeed * Time.deltaTime);

        if(moveHor == false)
        {
            PlayerAnimation(runSprite);
        }
        
    }

    private void MoveHorizontally()
    {
        float direction = Input.GetAxis("Horizontal");
        float horizontalSpeed = direction * sideSpeed * Time.deltaTime;

        playerRigid.velocity = new Vector3(horizontalSpeed, playerRigid.velocity.y, playerRigid.velocity.z);

        if(direction < 0 || direction > 0)
        {
            moveHor = true;
        }
        else
        {
            moveHor = false;
        }


        if (direction > 0)
        {
            if (!isGrounded)
            {
                PlayerAnimation(jumpRightSprite);
            }
            else
            {
                PlayerAnimation(rightSprite);
            }

        }
        else if (direction < 0)
        {
            if (!isGrounded)
            {
                PlayerAnimation(jumpLeftSprite);
            }
            else
            {
                PlayerAnimation(leftSprite);
            }
            
        }
    }

    private void Jump()
    {
        playerRigid.AddForce(Vector3.up * jumpForce*Time.deltaTime, ForceMode.Impulse);

        if(moveHor == false)
        {
            PlayerAnimation(jumpSprite);
        }

    }

    private void PlayerAnimation(Texture[] flipbookSprites)
    {
        animationTimer -= Time.deltaTime;
        if (animationTimer <= 0)
        {
            animationTimer = 1f / animationFPS;
            currentFrame++;
            if (currentFrame >= flipbookSprites.Length)
            {
                currentFrame = 0;
            }
            playerMaterial.mainTexture = flipbookSprites[currentFrame];
        }
    }
}
