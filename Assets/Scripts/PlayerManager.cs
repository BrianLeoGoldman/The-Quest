using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int health;
    public int score;
    private AudioSource sound;
    Animator anim;

    public int damageCooldown;
    public int counter;

    void Start()
    {
        counter = 0;
        sound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        anim.SetBool("Dead", false);
        anim.SetBool("DeathComplete", false);

    }

    private void Update()
    {
        if(counter > 0)
        {
            counter--;
        }
        else
        {
            counter = 0;
        }
        if(transform.position.y < (-10))
        {
            StartCoroutine(Reset(0.0f));
        }
    }

    public void addScore(int newScore)
    {
        score += newScore;
    }

    public void receiveDamage(int damage)
    {
        if(counter == 0)
        {
            sound.Play();
            health -= damage;
            counter = damageCooldown;
            if (health <= 0)
            {
                health = 0;
                anim.SetBool("Dead", true);
                Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
                rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
                StartCoroutine(Reset(0.6f));
            }
        }
    }

    public void recoverHealth(int healthAmount)
    {
        health += healthAmount;
        if(health > 30)
        {
            health = 30;
        }
    }

    public int returnHealth()
    {
        return health;
    }

    public int returnScore()
    {
        return score;
    }

    IEnumerator Reset(float Count)
    {
        yield return new WaitForSeconds(Count);
        anim.SetBool("DeathComplete", true);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        yield return null;
    }
}
