using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour {

    public int value;
    private AudioSource sound;
    private Renderer rend;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            sound.Play();
            other.GetComponent<PlayerManager>().addScore(value);
            rend.enabled = false;
            Destroy(gameObject, sound.clip.length);
            //Destroy(gameObject);
        }
    }

}
