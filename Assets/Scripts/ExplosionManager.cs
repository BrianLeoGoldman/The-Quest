using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour {

    private AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        sound.Play();
        Destroy(gameObject, 0.3f);
    }

}
