using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShipController3DTopDown : MonoBehaviour {

    public float flt_RotationSpeed;
    public float flt_ThrustForce;
    public float flt_Overallspeed;

    private Rigidbody tmpRigidbody;
    private ParticleSystem tmpParticleSystem;

	// Use this for initialization
	void Start () {

        tmpRigidbody = GetComponent<Rigidbody>();
        tmpParticleSystem = GetComponent<ParticleSystem>();
        tmpParticleSystem.Play();
        tmpParticleSystem.enableEmission = true;


    }
	
	// Update is called once per frame
	void Update () {

        //Rotate Left
        if (Input.GetKey(KeyCode.A))
            tmpRigidbody.transform.Rotate(Vector3.down * flt_RotationSpeed  *Time.deltaTime,Space.World);
        

        //Rotate right
        if (Input.GetKey(KeyCode.D))
        {
            tmpRigidbody.transform.Rotate(Vector3.up * flt_RotationSpeed * Time.deltaTime, Space.World);
        }

        //Thruster pressed
        if (Input.GetKey(KeyCode.Space))
        {
                tmpRigidbody.AddRelativeForce(0, flt_ThrustForce * Time.deltaTime,0, ForceMode.Impulse);
                tmpParticleSystem.enableEmission = true;
        }
        else
            tmpParticleSystem.enableEmission = false;


        flt_Overallspeed = tmpRigidbody.velocity.magnitude;
    }

    void FixedUpdate()
    {

    }
}
