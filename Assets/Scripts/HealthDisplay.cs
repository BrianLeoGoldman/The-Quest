using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour {

    GameObject player;
    SpriteRenderer renderer;
    public int health;
    private GUIStyle guiStyle = new GUIStyle();

    public Sprite zero, one, two, three, four, five, six, seven, eight, nine, ten, eleven, twelve, thirteen, fourteen, fifteen;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = fifteen;
        health = player.GetComponent<PlayerManager>().returnHealth();
    }

    void OnGUI()
    {
        guiStyle.fontSize = 30;
        GUI.Label(new Rect(10, 17, 50, 20), "LIFE", guiStyle);
    }

    void Update()
    {
        health = player.GetComponent<PlayerManager>().returnHealth();
        CheckHealthBar();
    }

    void CheckHealthBar()
    {
        switch (health)
        {
            case 0:
                renderer.sprite = zero;
                break;
            case 1:
                renderer.sprite = one;
                break;
            case 2:
                renderer.sprite = one;
                break;
            case 3:
                renderer.sprite = two;
                break;
            case 4:
                renderer.sprite = two;
                break;
            case 5:
                renderer.sprite = three;
                break;
            case 6:
                renderer.sprite = three;
                break;
            case 7:
                renderer.sprite = four;
                break;
            case 8:
                renderer.sprite = four;
                break;
            case 9:
                renderer.sprite = five;
                break;
            case 10:
                renderer.sprite = five;
                break;
            case 11:
                renderer.sprite = six;
                break;
            case 12:
                renderer.sprite = six;
                break;
            case 13:
                renderer.sprite = seven;
                break;
            case 14:
                renderer.sprite = seven;
                break;
            case 15:
                renderer.sprite = eight;
                break;
            case 16:
                renderer.sprite = eight;
                break;
            case 17:
                renderer.sprite = nine;
                break;
            case 18:
                renderer.sprite = nine;
                break;
            case 19:
                renderer.sprite = ten;
                break;
            case 20:
                renderer.sprite = ten;
                break;
            case 21:
                renderer.sprite = eleven;
                break;
            case 22:
                renderer.sprite = eleven;
                break;
            case 23:
                renderer.sprite = twelve;
                break;
            case 24:
                renderer.sprite = twelve;
                break;
            case 25:
                renderer.sprite = thirteen;
                break;
            case 26:
                renderer.sprite = thirteen;
                break;
            case 27:
                renderer.sprite = fourteen;
                break;
            case 28:
                renderer.sprite = fourteen;
                break;
            case 29:
                renderer.sprite = fifteen;
                break;
            case 30:
                renderer.sprite = fifteen;
                break;
            default:
                renderer.sprite = fifteen;
                break;
        }
    }
}
