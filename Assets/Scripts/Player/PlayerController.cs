using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    //private
    public Rigidbody2D theRB;

    public float jumpForce;
    public float bounceForce;

    public bool stopInput;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    private bool canDoubleJump;

    private Animator anim;
    private SpriteRenderer theSR;

    public bool isLeft;
    public bool canInteract = false;

    public PauseMenu reference;

    public static PlayerController sharedInstance;
    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!reference.isPaused && !stopInput)
        {
           if (knockBackCounter <= 0)
            {
                theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);
                isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

                if (Input.GetButtonDown("Jump"))
                {
                    if (isGrounded)
                    {
                        theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                        canDoubleJump = true;
                        //AudioManager.sharedInstance.PlaySFX(10);
                    }
                    else
                    {
                        if (canDoubleJump)
                        {
                            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                            canDoubleJump = false;
                            //AudioManager.sharedInstance.PlaySFX(10);
                        }
                    }
                }

                if (theRB.velocity.x < 0)
                {
                    theSR.flipX = true;
                    isLeft = false;
                }
                else if (theRB.velocity.x > 0)
                {
                    theSR.flipX = false;
                    isLeft = true;
                }
            }
            else
            {
                knockBackCounter -= Time.deltaTime;

                if (!theSR.flipX)
                {
                    theRB.velocity = new Vector2(knockBackForce, theRB.velocity.y);
                }
                else
                {
                    theRB.velocity = new Vector2(-knockBackForce, theRB.velocity.y);
                }
            }
        }

        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }

    //Método para gestionar el KnockBack producido al jugador al hacerse daño
    public void KnockBack()
    {
        knockBackCounter = knockBackLength;
        theRB.velocity = new Vector2(0f, knockBackForce);
        anim.SetTrigger("hurt");
    }

    //Método para que el jugador rebote 
    public void Bounce(float bounceForce)
    {
        theRB.velocity = new Vector2(theRB.velocity.x, bounceForce);
        //AudioManager.sharedInstance.PlaySFX(10);
    }

    //Método para parar al jugador
    public void StopPlayer()
    {
        theRB.velocity = Vector2.zero;
    }

    //Método para conocer cuando un objeto entra entra en colisión con el jugador
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = collision.transform;
        }
    }

    //Método para conocer cuando dejamos de colisionar contra un objeto
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = null;
        }
    }
}
