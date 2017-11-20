using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAttack : MonoBehaviour {

    public GameObject leaf;
    public Sprite mouthClosed;
    public Sprite mouthOpen;
    public bool isOpened;

    public int spriteInterval;
    private int spriteCounter;

    bool facingRight;
    private GameObject player;

    void Start () {
        this.GetComponent<SpriteRenderer>().sprite = mouthClosed;
        isOpened = false;
        spriteCounter = spriteInterval;
        facingRight = false;
        player = GameObject.FindWithTag("Player");
    }
	
	void Update () {
        if(spriteCounter == 0 && !isOpened)
        {
            this.GetComponent<SpriteRenderer>().sprite = mouthOpen;
            Invoke("CreateLeaf", 0.3f);
            isOpened = !isOpened;
            spriteCounter = spriteInterval;
        }
        else
        {
            if(spriteCounter == 0 && isOpened)
            {
                this.GetComponent<SpriteRenderer>().sprite = mouthClosed;
                isOpened = !isOpened;
                spriteCounter = spriteInterval;
            }
            
        }
        spriteCounter -= 1;
        if(!facingRight && player.transform.position.x > transform.position.x)
        {
            Flip();
        }
        if (facingRight && player.transform.position.x < transform.position.x)
        {
            Flip();
        }

    }

    void CreateLeaf()
    {
        Vector3 position = transform.position + new Vector3(1, 0, 0);
        GameObject newLeaf = Instantiate(leaf, position, transform.rotation);
        newLeaf.GetComponent<LeafManager>().IsFacingRight(facingRight);

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
