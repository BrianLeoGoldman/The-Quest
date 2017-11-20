using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour {

    //Sections
    public GameObject firstSection;
    public GameObject secondSection;
    public GameObject thirdSection;
    public GameObject fourthSection;
    public GameObject fifthSection;

    // Use this for initialization
    void Start()
    {
        Vector3 vector1 = new Vector3(13.37017f, 1.992401f, 0f);
        Instantiate(firstSection, vector1, transform.rotation);

        Vector3 vector2 = new Vector3(0f, 23f, 0f);
        Instantiate(secondSection, vector2, transform.rotation);

        Vector3 vector3 = new Vector3(139.6843f, -4.546233f, 0f);
        Instantiate(thirdSection, vector3, transform.rotation);

        Vector3 vector4 = new Vector3(225.4884f, -1.485538f, 0f);
        Instantiate(fourthSection, vector4, transform.rotation);

        Vector3 vector5 = new Vector3(238.0661f, 8.134657f, 0f);
        Instantiate(fifthSection, vector5, transform.rotation);
    }
}
