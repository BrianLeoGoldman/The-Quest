using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Moving")
        {
            transform.parent = other.transform;
        }
        else
        {
            transform.parent = null;
        }
    }
}
