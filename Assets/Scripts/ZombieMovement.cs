using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour {

    public float walkSpeed = 2.0f;
    public float range = 10.0f;
    float toMove;
    Vector3 walkAmount;
    public bool goRight;
    public bool goLeft;
    private float appearenceWait;

    Animator anim;
    private GameObject player;
    private float initialYPosition;

    bool facingRight;
    private float leftLimit;
    private float rightLimit;

    private void Start()
    {
        goRight = false;
        goLeft = true;
        toMove = range;
        facingRight = false;
        appearenceWait = 10.0f;
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        initialYPosition = transform.position.y;
    }

    void Update()
    {
        leftLimit = transform.position.x - 5;
        rightLimit = transform.position.x + 5;
        
            if (appearenceWait <= 0f)
            {
                anim.SetBool("Moving", true);
                if (player.transform.position.x > leftLimit && player.transform.position.x < rightLimit)
                {
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, walkSpeed * Time.deltaTime);
                    transform.position = new Vector3(transform.position.x, initialYPosition, transform.position.z);
                    if (player.transform.position.x > transform.position.x && !facingRight)
                    {
                        Flip();
                    }
                    if (player.transform.position.x < transform.position.x && facingRight)
                    {
                        Flip();
                    }
                }
                else
                {

                    if (goRight && !facingRight)
                    {
                        Flip();
                    }
                    if (goLeft && facingRight)
                    {
                        Flip();
                    }
                    checkLimits();
                    if (goRight)
                    {
                        walkAmount.x = 1.0f * walkSpeed * Time.deltaTime;
                    }
                    else if (goLeft)
                    {
                        walkAmount.x = -1.0f * walkSpeed * Time.deltaTime;
                    }
                    transform.Translate(walkAmount);
                    toMove -= 0.1f;
                }
            }
            else
            {
                appearenceWait = appearenceWait - 0.2f;
            }
    }

    void checkLimits()
    {
        if (toMove <= 0.0f && goRight)
        {
            goRight = false;
            goLeft = true;
            toMove = range;
            Flip();
        }

        else if (toMove <= 0 && goLeft)
        {
            goRight = true;
            goLeft = false;
            toMove = range;
            Flip();
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
