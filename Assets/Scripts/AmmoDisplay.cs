using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDisplay : MonoBehaviour {

    GameObject player;
    private GUIStyle guiStyle = new GUIStyle();
    SpriteRenderer renderer;
    private int typeOfBullet;
    public Sprite bullet, fire, ice, thunder;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = bullet;
        typeOfBullet = 0;
    }

    void OnGUI()
    {
        guiStyle.fontSize = 30;
        GUI.Label(new Rect(450, 25, 50, 20), "AMMO" , guiStyle);

    }

    void Update()
    {
        typeOfBullet = player.GetComponent<PlayerShooting>().ReturnAmmo();
        switch (typeOfBullet)
        {
            case 0:
                renderer.sprite = bullet;
                break;
            case 1:
                renderer.sprite = fire;
                break;
            case 2:
                renderer.sprite = thunder;
                break;
            case 3:
                renderer.sprite = ice;
                break;
            default:
                renderer.sprite = bullet;
                break;
        }
    }

    
}
