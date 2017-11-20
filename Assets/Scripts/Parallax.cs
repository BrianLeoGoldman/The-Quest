using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    public Transform[] backgrounds;  
    private float[] parallaxScales;  
    public float smoothing = 1f;  

    private Transform cam;  
    private Vector3 previousCamPos;  

    void Awake ()  
    {
        cam = Camera.main.transform;
    }
    
    void Start ()
    {
        previousCamPos = cam.position;
        parallaxScales = new float[backgrounds.Length];

        for(int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * (-1);
        }
	}

	void Update ()
    {
		for(int i = 0; i < backgrounds.Length; i++)  
        {
            //El parallax va opuesto al movimiento de la camara
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];
            //Posicion en x hacia la cual moverse: posicion actual + valor del parallax
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;
            //Vector hacia el cual moverse
            Vector3 backgroundTargetPosition = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
            //Transicion sutil entre la posicion actual y la final
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPosition, smoothing * Time.deltaTime);
        }
        
        previousCamPos = cam.position;
    }
}
