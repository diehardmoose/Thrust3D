using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCameraController : MonoBehaviour {
    public GameObject ObjectToFollow;
    public float offsetX;
    public float offsetY;
    public float offsetZ;

    public Vector3 offset;
    public Vector3 testpos;

    // Use this for initialization
    void Start () {
        offset.x = offsetX;
        offset.y = offsetY;
        offset.z = offsetZ;

    }
	
	// Update is called once per frame
	void Update () {
        transform.position = ObjectToFollow.transform.position + offset;
        
        testpos = transform.position;


    }
}
