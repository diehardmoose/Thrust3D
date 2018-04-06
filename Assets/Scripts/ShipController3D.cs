using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShipController3D : MonoBehaviour {

    public float flt_RotationSpeed;
    public float flt_ThrustForce;
    public float flt_MaxHeight;
    public Slider heightSlider;


    public float flt_debugHeight;

    private Rigidbody tmpRigidbody;
    private ParticleSystem tmpParticleSystem;

	// Use this for initialization
	void Start () {

        tmpRigidbody = GetComponent<Rigidbody>();
        tmpParticleSystem = GetComponent<ParticleSystem>();
        tmpParticleSystem.Play();
        tmpParticleSystem.enableEmission = true;

        //Initialise sliders
        heightSlider.maxValue = flt_MaxHeight;
        heightSlider.value = Mathf.Abs(tmpRigidbody.position.y);


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

            flt_debugHeight = Mathf.Abs(tmpRigidbody.position.y);
            if (Mathf.Abs(tmpRigidbody.position.y) < Mathf.Abs(flt_MaxHeight))
            {
                tmpRigidbody.AddRelativeForce(0, 0, -flt_ThrustForce * Time.deltaTime, ForceMode.Impulse);
                tmpParticleSystem.enableEmission = true;
            }
            else tmpParticleSystem.enableEmission = false;
        }
        else
            tmpParticleSystem.enableEmission = false;


        //Update heightSlider
        heightSlider.value = Mathf.Abs(tmpRigidbody.position.y);
    }

    void FixedUpdate()
    {
        //float h = Input.GetAxis("Horizontal") * flt_RotationSpeed * Time.deltaTime;
        //float v = Input.GetAxis("Vertical") * flt_RotationSpeed * Time.deltaTime;

        //tmpRigidbody.AddTorque(transform.up * h);
        //tmpRigidbody.AddTorque(transform.right * v);
    }
}
