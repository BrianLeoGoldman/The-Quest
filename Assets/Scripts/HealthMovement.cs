using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMovement : MonoBehaviour {

    public float speed = 2f;
    //public int unitsToMove = 2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.up * speed * Time.deltaTime;
        Destroy(gameObject, 2.0f);
    }
}
