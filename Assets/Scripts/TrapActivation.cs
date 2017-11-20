using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivation : MonoBehaviour {

    public GameObject rock;
    private bool hasBeenActivated;

    void Awake()
    {
        hasBeenActivated = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && hasBeenActivated)
        {
            rock.GetComponent<AutoDestruction>().DestroyFromOutside();
            hasBeenActivated = false;
        }
    }
}
