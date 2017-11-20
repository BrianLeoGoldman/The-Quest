using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderTrapActivation : MonoBehaviour {

    private bool isActivated;

    void Start()
    {
        isActivated = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !isActivated)
        {
            transform.Rotate(0, 0, 20);
            isActivated = !isActivated;
        }
    }
}
