using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Parallax : MonoBehaviour

{

    private float lenght, starposx, startposy;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {

        starposx = transform.position.x;

        startposy= transform.position.y;

        lenght = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    void Update()
    {

        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
        
        transform.position = new Vector3(starposx + dist, startposy, transform.position.z);

        if (temp > starposx + lenght) starposx += lenght;

        else if (temp < starposx - lenght) starposx -= lenght;

    }

}