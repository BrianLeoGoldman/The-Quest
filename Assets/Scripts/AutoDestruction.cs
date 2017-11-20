using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruction : MonoBehaviour {

    public float lifeTime = 1.0f;
    public bool auto;

    void Awake()
    {
        if (auto)
        {
            Destroy(gameObject, lifeTime);
        }
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DestroyFromOutside()
    {
        Destroy(gameObject);
    }
}
