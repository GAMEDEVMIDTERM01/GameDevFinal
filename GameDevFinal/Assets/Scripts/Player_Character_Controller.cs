using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Character_Controller : MonoBehaviour
{
    public Rigidbody playerRigid;
    private bool isGrounded;

    private bool canJump;

    public float groundDistance;

    [Header("Ground Checking")]
    public LayerMask groundLayer;

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

    public CapsuleCollider playerCollider;
    private Material playerMaterial;

    private float animationTimer;
    private int currentFrame;

    private bool movingHor;

    private float direction;

    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position - new Vector3(0, playerCollider.bounds.extents.y + groundDistance, 0));
    }
    

    void Start()
    {
        playerMaterial = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        movingHor = Input.GetAxisRaw("Horizontal") != 0;

        isGrounded = Physics.Raycast(transform.position, -transform.up, playerCollider.bounds.extents.y + groundDistance, groundLayer, QueryTriggerInteraction.Ignore);

        canJump = Input.GetKeyDown(KeyCode.Space);

        if (movingHor == false && isGrounded)
        {
            PlayerAnimation(runSprite);
        }

        else if (direction > 0 && isGrounded)
        {
            PlayerAnimation(rightSprite);
        }

        else if (direction < 0 && isGrounded)
        {
            PlayerAnimation(leftSprite);
        }

        if (movingHor == false && !isGrounded)
        {
            PlayerJumpAnimation(jumpSprite);
        }
        if (movingHor == true && direction > 0 && !isGrounded)
        {
            PlayerJumpAnimation(jumpRightSprite);
        }
        if (movingHor == true && direction < 0 && !isGrounded)
        {
            PlayerJumpAnimation(jumpLeftSprite);
        }
    }


    private void FixedUpdate()
    {
        MoveForward();

        if (movingHor)
        {
            MoveHorizontally();
        }
        
        if (canJump && isGrounded)
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
        direction = Input.GetAxis("Horizontal");

        float horizontalSpeed = direction * sideSpeed * Time.deltaTime;

        playerRigid.velocity = new Vector3(horizontalSpeed, playerRigid.velocity.y, playerRigid.velocity.z);

    }

    private void Jump()
    {
        playerRigid.AddForce(Vector3.up * jumpForce*Time.deltaTime, ForceMode.Impulse);
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

    private void PlayerJumpAnimation(Texture[] flipbookSprites)
    {
        animationTimer -= Time.deltaTime;
        if (animationTimer <= 0)
        {
            animationTimer = 1f / animationFPS;
            currentFrame++;
            if (currentFrame >= flipbookSprites.Length)
            {
                playerMaterial.mainTexture = flipbookSprites[flipbookSprites.Length - 1];
            }
            else
            {
                playerMaterial.mainTexture = flipbookSprites[currentFrame];
            }   
        }
    }
}
