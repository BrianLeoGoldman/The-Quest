using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileCollection : MonoBehaviour {

    public int type;
    private AudioSource sound;
    private Renderer rend;
    private bool hasBeenCollected;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        hasBeenCollected = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !hasBeenCollected)
        {
            sound.Play();
            other.GetComponent<PlayerShooting>().SetBullet(type);
            rend.enabled = false;
            hasBeenCollected = true;
            Destroy(gameObject, sound.clip.length);
        }
    }
}
