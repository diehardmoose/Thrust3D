using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController3D : MonoBehaviour {

    public float flt_RotationSpeed;
    public float flt_ThrustForce;

    private Rigidbody tmpRigidbody;

	// Use this for initialization
	void Start () {

        tmpRigidbody = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {

        //Rotate Left
        if (Input.GetKey(KeyCode.A))
        {
            tmpRigidbody.transform.Rotate(Vector3.down * flt_RotationSpeed  *Time.deltaTime,Space.World);
        }

        //Rotate right
        if (Input.GetKey(KeyCode.D))
        {
            tmpRigidbody.transform.Rotate(Vector3.up * flt_RotationSpeed * Time.deltaTime, Space.World);
        }

        //Rotate down
        if (Input.GetKey(KeyCode.W))
        {
            tmpRigidbody.transform.Rotate(Vector3.right * flt_RotationSpeed * Time.deltaTime);
        }

        //rotate up
        if (Input.GetKey(KeyCode.S))
        {
            tmpRigidbody.transform.Rotate(Vector3.left * flt_RotationSpeed * Time.deltaTime);
        }

        //Thruster pressed
        if (Input.GetKey(KeyCode.Space))
        {

            // tmpRigidbody.AddForce(transform.up * flt_ThrustForce * Time.deltaTime);
            //tmpRigidbody.AddRelativeForce(Vector3.forward * flt_ThrustForce * Time.deltaTime);

            //tmpRigidbody.AddForce(0,flt_ThrustForce*Time.deltaTime,0,ForceMode.Impulse);
            tmpRigidbody.AddRelativeForce(0,0,-flt_ThrustForce * Time.deltaTime, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        //float h = Input.GetAxis("Horizontal") * flt_RotationSpeed * Time.deltaTime;
        //float v = Input.GetAxis("Vertical") * flt_RotationSpeed * Time.deltaTime;

        //tmpRigidbody.AddTorque(transform.up * h);
        //tmpRigidbody.AddTorque(transform.right * v);
    }
}
