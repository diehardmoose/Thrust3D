using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyController : MonoBehaviour {
    //public Color colourStart;
    //public Color colourEnd;
    public float startHeight;
    public float endHeight;
    public GameObject ObjectToTrack;


    private float objectHeight;
    private float heightDiff;
    private float step;

	// Use this for initialization
	void Start () {
        RenderSettings.skybox.SetFloat("_Exposure", Mathf.Lerp(3f, 0f, 0));
        //RenderSettings.skybox.SetColor("_SkyTint", Color.Lerp(colourStart, colourEnd, step));
        //RenderSettings.skybox.SetColor("_SkyTint", Color.black);


    }

    // Update is called once per frame
    void Update() {
        objectHeight= Mathf.Abs(ObjectToTrack.transform.position.y);
        if (objectHeight > startHeight)
        {
            heightDiff = endHeight - startHeight;
            step = (objectHeight - startHeight) / heightDiff;
        }
        else step = 0;

        RenderSettings.skybox.SetFloat("_Exposure", Mathf.Lerp(3f,0f, step));
        //RenderSettings.skybox.SetFloat("_Exposure", step);

        //RenderSettings.skybox.SetFloat("_Exposure", Mathf.Sin(Time.time * Mathf.Deg2Rad * 100) + 2);
        //RenderSettings.skybox.SetColor("_SkyTint", Color.Lerp(colourStart, colourEnd, step));
        //RenderSettings.skybox.SetColor("_Tint", Color.black);
        DynamicGI.UpdateEnvironment();
    }
}
