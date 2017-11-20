using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour {

    public int damage;

    public GameObject dust;
    public GameObject drop1;
    public GameObject drop2;
    public int health;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerManager>().receiveDamage(damage);
        }
    }

    void Update()
    {
        if(health <= 0)
        {
            Die();
        }
    }

    public void ReceiveDamage(int damage)
    {
        health -= damage;
    }

    void Die()
    {
        int random = Random.Range(0, 10);
        if (random == 1)
        {
            Instantiate(drop1, transform.position, transform.rotation);
        }
        if (random == 2)
        {
            Instantiate(drop2, transform.position, transform.rotation);
        }
        Instantiate(dust, transform.position, transform.rotation);
        Destroy(gameObject);

    }
}
