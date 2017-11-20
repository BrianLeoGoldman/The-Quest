using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollection : MonoBehaviour {

    public int value;
    public GameObject effect;
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
            other.GetComponent<PlayerManager>().recoverHealth(value);
            Instantiate(effect, transform.position, transform.rotation);
            rend.enabled = false;
            hasBeenCollected = true;
            Destroy(gameObject, sound.clip.length);
        }
    }
}
