using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineManager : MonoBehaviour {

    public GameObject explosion;
    
    private Renderer rend;
    public int damage;
    //Animator anim;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        //anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Vector3 offset = new Vector3(0, 1, 0);
            Instantiate(explosion, transform.position + offset, transform.rotation);
            other.GetComponent<PlayerManager>().receiveDamage(damage);
            Destroy(gameObject);
            

        }
    }
}
