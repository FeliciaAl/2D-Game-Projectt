using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float walkSpeed = 1.5f;
    public float jumpSpeed = 100.0f;
    public float downSpeed = 0.5f;
    public float jumpMultiplier = 1.5f;
    public float walkMultiplier = 100.0f;
    float timer;
    float waitTime = 0.1f;
    SpriteRenderer spriteRender;
    
    float startPosY;
    public Animator charAnimator;
    Rigidbody2D RB;
    public bool grounded = false;

    Vector2 startPos;
	// Use this for initialization
	void Start () {
        RB = this.GetComponent<Rigidbody2D>();
        charAnimator = this.GetComponent<Animator>();
        spriteRender = this.GetComponent<SpriteRenderer>();
        //charAnimator.Play("idle2");
        startPosY = transform.position.y;

        startPos = transform.position;
    }

    void checkGrounded()
    {
        if (grounded)
        {
            

        }

        else
        {
            
        }
    }
	
    void falldown()
    {
        if(!grounded)
        {
            RB.AddForce(Vector2.down / 10, ForceMode2D.Force);
        }
    }
	// Update is called once per frame
	void Update ()
    {
        //checkGrounded();
        falldown();

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            charAnimator.SetBool("jumpTrigger", true);
            timer += Time.deltaTime;
            print(timer + " s");
            if (timer > 0.5f)
            {
                print("timer's up");
                RB.AddForce((Vector2.up * jumpSpeed), ForceMode2D.Impulse);
                timer = 0f;
                grounded = false;
            }
        }

        else if (Input.GetKey(KeyCode.D))
        {
            charAnimator.SetBool("walkTrigger", true);
            float x = Input.GetAxis("Horizontal");
            spriteRender.flipX = false;
            RB.AddForce((Vector2.right * walkSpeed) * Time.deltaTime, ForceMode2D.Impulse);
        }

        else if(Input.GetKey(KeyCode.A))
        {
            charAnimator.SetBool("walkTrigger", true);
            spriteRender.flipX = true;
            RB.AddForce((Vector2.left * walkSpeed) * Time.deltaTime, ForceMode2D.Impulse);
        }

        else
        {
            charAnimator.SetBool("jumpTrigger", false);
            timer = 0f;

            charAnimator.SetBool("walkTrigger", false);
        }
    }

    void movePlayer(float horizontalInput)
    {
        RB.velocity = new Vector2(horizontalInput * walkSpeed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
            print("grounded");
        }

        else if(collision.gameObject.tag == "Collectibles")
        {
            Destroy(collision.gameObject);
            print("collectible");
        }

        else if(collision.gameObject.tag == "End")
        {
            transform.position = startPos;
        }
    }
}
