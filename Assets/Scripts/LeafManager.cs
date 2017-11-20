using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafManager : MonoBehaviour {

    public int damage;
    public float maxSpeed = 17f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerManager>().receiveDamage(damage);
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
