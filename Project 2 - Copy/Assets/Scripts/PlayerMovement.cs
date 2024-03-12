using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField]
    private LayerMask jumpableground;


    private float dirX;
    [SerializeField]
    private float speed = 7f;
    [SerializeField]
    private float JumpForce = 14f;

    private enum PlayerState {Idle,Running,Jumping,Falling }


    private Vector3 respawnpoint;
    public GameObject fallDectector;


     

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        respawnpoint = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
        float deltaX = dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
        
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpForce, 0);
        }
      
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        PlayerState state;

        if (dirX > 0f)
        {
            state = PlayerState.Running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = PlayerState.Running;
            sprite.flipX = true;
        }
        else
        {
            state = PlayerState.Idle;
        }
        if (rb.velocity.y > .1f)
        {
            state = PlayerState.Jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = PlayerState.Falling;
        }

        anim.SetInteger("State", (int)state);

    } 

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableground);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FallDectector")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        }
    }
}
