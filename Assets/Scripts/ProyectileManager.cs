using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileManager : MonoBehaviour {

    public int damage;
    public float maxSpeed = 17f;
    public GameObject effect;
    private AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        sound.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<DamageManager>().ReceiveDamage(damage);
            Instantiate(effect, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Vector3 posX = transform.position;
        Vector3 velocityX = new Vector3(maxSpeed * Time.deltaTime, 0, 0);
        posX += transform.rotation * velocityX;
        transform.position = posX;

    }

    public void IsFacingRight(bool facingRight)
    {
        if (!facingRight)
        {
            maxSpeed *= (-1);
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            Vector3 position = transform.position;
            position.x -= 2;
            transform.position = position;
        }
    }
}
