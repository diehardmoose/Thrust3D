using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TopDownLevelController : MonoBehaviour {
    public Canvas MainCanvas;
    public Text txtAtmosTimer;
    public Text txtAtmosPrep;
    public Image fadeImage;

    private bool EnteringAtmos;

	// Use this for initialization
	void Start () {
        StartCoroutine(GameLoop());
    }
	
    public void FadeOut()
    {
        StartCoroutine(DoFadeOut());
    }

    public void FadeIn()
    {
        StartCoroutine(DoFadeIn());
    }

    IEnumerator DoFadeIn()
    {

        while (fadeImage.color.a > 0)
        {
            Color c = fadeImage.color;
            c.a -= Time.deltaTime / 2;
            fadeImage.color = c; ;
            yield return null;
        }

        yield return null;

    }

    IEnumerator DoFadeOut()
    {

        while (fadeImage.color.a < 256)
        {
            Color c = fadeImage.color;
            c.a += Time.deltaTime / 2;
            fadeImage.color = c; ;
            yield return null;
        }

        yield return null;

    }

    void FixedUpdate()
    {

        GameObject[] PlanetObjects;
        PlanetObjects = GameObject.FindGameObjectsWithTag("Planet");

        foreach (GameObject PlayerObject in PlanetObjects)
        {

            //Check if player object is in range to enter atomosphere
            if (PlayerObject.GetComponent<GravitationalPullScript>().inAtmosRange)
            {
                txtAtmosTimer.enabled = true;
                txtAtmosPrep.enabled = true;
                float lclInAtmosTime = Mathf.Round(PlayerObject.GetComponent<GravitationalPullScript>().inAtmosTime);

                txtAtmosTimer.text = (5 - lclInAtmosTime).ToString();
                if ((5 - lclInAtmosTime) <= 0)
                {
                    EnteringAtmos = true;
                }
            
            }
            else
            {
                txtAtmosTimer.enabled = false;
                txtAtmosPrep.enabled = false;
            }

        }


        
    }

    IEnumerator GameLoop() {

        yield return StartCoroutine(StartLevel());

        yield return StartCoroutine(PlayingLevel());

        yield return StartCoroutine(EndLevel());

        SceneManager.LoadScene("TestScene");

    }

    IEnumerator StartLevel()
    {
        EnteringAtmos = false;

        WaitForSeconds m_StartWait = new WaitForSeconds(2);

        FadeIn();

        yield return m_StartWait;
    }

    IEnumerator PlayingLevel()
    {
        while (!EnteringAtmos)
        {
            yield return null;
        }
    }

    IEnumerator EndLevel()
    {

        WaitForSeconds m_StartWait = new WaitForSeconds(2);

        FadeOut();
 

        yield return m_StartWait;
    }

}
