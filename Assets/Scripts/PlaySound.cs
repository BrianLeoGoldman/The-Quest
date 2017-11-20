using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

    private AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            sound.Play();
        }
    }
}
