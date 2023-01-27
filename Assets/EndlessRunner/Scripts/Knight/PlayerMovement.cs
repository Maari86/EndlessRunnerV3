using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    private float JumpCooldown;

    [SerializeField] private LayerMask JumpableGround;

    private float dirX = 0f;
  
    [SerializeField] private float moveSpeed = 0f;
    [SerializeField] private float jumpForce = 0f;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip checkpointSound;



    // Start is called before the first frame update

    private void Update()
    {
        GetPosition();
    }

    private void OnEnable()
    {
        Health.OnPlayerDeath += DisablePlayerMovement;
    }
    private void OnDisable()
    {
        Health.OnPlayerDeath -= DisablePlayerMovement;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Start()
    {
        EnablePlayerMovement();
    }

    public Vector2 GetPosition()
    {
        float dirX = Input.GetAxisRaw("Horizontal");


        if (dirX > 0.01f)
            transform.localScale = Vector3.one;
        else if (dirX < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);


            anim.SetBool("Moving", dirX != 0);
            anim.SetBool("Grounded", isGrounded());
        if (JumpCooldown < 0.2f)
        {

            if (Input.GetButtonDown("Jump") && isGrounded())
                Jump();

            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }
        else 
        {
           JumpCooldown += Time.deltaTime;
        }
        {
            return transform.position;
        }

       
         
    }



   private void Jump()
    {
        if (isGrounded()) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetTrigger("Jump");
            SoundManager.instance.PlaySound(jumpSound);
        }
        else if (!isGrounded())
        {

        }
    }


    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.down, 0.1f, JumpableGround);
        return raycastHit.collider != null;
    }






    public bool Attack()
    {
        return dirX == 0 && isGrounded();
    }

    public bool RageAttack()
    {
        return dirX == 0 && isGrounded();
    }

    private void DisablePlayerMovement()
    {
        anim.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
    }
    private void EnablePlayerMovement()
    {
        anim.enabled = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.transform.tag == "CheckPoint")
        {
            collision.GetComponent<Animator>().SetTrigger("appear");
            SoundManager.instance.PlaySound(checkpointSound);
        }
    }

}

