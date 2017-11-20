using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideToSide : MonoBehaviour {

    public float platformSpeed = 2f;
    bool endPoint;
    private Vector3 rightLimit;
    private Vector3 leftLimit;

    void Start()
    {
        rightLimit = transform.position + new Vector3(3, 0, 0);
        leftLimit = transform.position - new Vector3(3, 0, 0);
    }

    void Update()
    {

        if (endPoint)
        {
            transform.position += Vector3.right * platformSpeed * Time.deltaTime;
        }
        else
        {
            transform.position -= Vector3.right * platformSpeed * Time.deltaTime;
        }

        if (transform.position.x >= rightLimit.x)
        {
            endPoint = false;
        }
        if (transform.position.x <= leftLimit.x)
        {
            endPoint = true;
        }
    }
}
