using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalPullScript : MonoBehaviour {
    public float Strength;
    public float Range;
    public float EnterAtmosRange;
    public int planetID;

    public bool inRange;  //public for debug
    public bool inAtmosRange; //public for debug
    public float inAtmosTime;


    // Use this for initialization
    void Start () {
  
        //GetComponent<SpriteRenderer>().sprite = inactiveSprite;

    }

    void FixedUpdate()
    {
        GameObject []PlayerObjects;
        PlayerObjects = GameObject.FindGameObjectsWithTag("Player");
        inRange = false;
        inAtmosRange = false;

        foreach (GameObject PlayerObject in PlayerObjects)
        {
            //Check if player object is in range for gravitational pull
            if (Vector3.Distance(transform.position, PlayerObject.GetComponent<Transform>().position) < Range){
                inRange = true;

                var vsub = transform.position - PlayerObject.GetComponent<Transform>().position;
                PlayerObject.GetComponent<Rigidbody>().AddForce(vsub.normalized * (Mathf.Max((Strength - vsub.magnitude) / 5, 0)), ForceMode.Force);
            }

            //Check if player object is in range to enter atomosphere
            if (Vector3.Distance(transform.position, PlayerObject.GetComponent<Transform>().position) < EnterAtmosRange)
            {
                inAtmosRange = true;

            }

        }

        //time how long player is is enter atmosphere range

        if (inAtmosRange)
        {
            inAtmosTime += Time.deltaTime;

        }
        else inAtmosTime = 0;






    }


 
}
