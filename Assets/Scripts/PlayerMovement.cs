using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float maxSpeed = 10f;
    public bool facingRight = true;
    Animator anim;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask ground;

    public float jumpForce = 700f; 
    bool doubleJump = false;

	void Start ()
    {
        anim = GetComponent<Animator>();
	}

	void FixedUpdate ()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, ground);
        anim.SetBool("Ground", grounded);
        if (grounded)
        {
            doubleJump = false;
        }
        anim.SetFloat("VSpeed", GetComponent<Rigidbody2D>().velocity.y);

        //if (!grounded)  return ;

        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if(move > 0 && !facingRight)
        {
            Flip();
        }
        else if(move < 0 && facingRight)
        {
            Flip();
        }

	}

    void Update()
    {
        if((grounded || !doubleJump) && Input.GetButtonDown("Jump"))
        {
            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            if(!doubleJump && !grounded)
            {
                doubleJump = true;
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
