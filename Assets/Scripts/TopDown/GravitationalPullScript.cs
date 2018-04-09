﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalPullScript : MonoBehaviour {
    public float Strength;
    public float Range;

    public Sprite inactiveSprite;
    public Sprite activeSprite;
    public bool inRange;


    // Use this for initialization
    void Start () {
  
        //GetComponent<SpriteRenderer>().sprite = inactiveSprite;

    }

    void FixedUpdate()
    {
        GameObject []energySpheres;
        energySpheres = GameObject.FindGameObjectsWithTag("Player");
        inRange = false;

        foreach (GameObject energySphere in energySpheres)
        {
            if (Vector3.Distance(transform.position, energySphere.GetComponent<Transform>().position) < Range){
                inRange = true;

                var vsub = transform.position - energySphere.GetComponent<Transform>().position;
                energySphere.GetComponent<Rigidbody>().AddForce(vsub.normalized * (Mathf.Max((Strength - vsub.magnitude) / 5, 0)), ForceMode.Force);
            }
        }

        //if (inRange)
        //{
        //    GetComponent<SpriteRenderer>().sprite = activeSprite;
        //} else
        //{
        //    GetComponent<SpriteRenderer>().sprite = inactiveSprite;
        //}
           
        
    }


 
}
