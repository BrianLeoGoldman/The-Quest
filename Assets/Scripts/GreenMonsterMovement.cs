using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMonsterMovement : MonoBehaviour {

    public float walkSpeed = 2.0f;
    public float range = 10.0f;
    float toMove;
    Vector3 walkAmount;
    public bool goRight;
    public bool goLeft;

    bool facingRight;

    private void Start()
    {
        goRight = true;
        goLeft = false;
        toMove = range;
        facingRight = true;
    }

    void Update()
    {
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
