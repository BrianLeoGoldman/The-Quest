using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private Transform player;
    private Vector3 offset = new Vector3(0, 0, -10);

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x + offset.x, 0, 1200), Mathf.Clamp(player.position.y, 0, 1200), transform.position.z);

    }
}
