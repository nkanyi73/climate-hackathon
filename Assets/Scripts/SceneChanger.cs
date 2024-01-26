using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public OVRScreenFade screenFade;
    public string sceneNameMaster;
    public float fadeTime;
    public bool finalScene;

    // Start is called before the first frame update
    void Start()
    {
        screenFade = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<OVRScreenFade>();
        if(screenFade == null )
        {
            Debug.LogError("Could Not find screen fade");
        }
        else
        {
            fadeTime = screenFade.fadeTime;
        }
        
    }
    
    public void MoveToNextScene(string sceneName)
    {
        StartCoroutine(NextSceneCoroutine(sceneName));
    }

    public IEnumerator NextSceneCoroutine(string sceneName)
    {

        screenFade.FadeOut();

        yield return new WaitForSeconds(fadeTime);
        if (finalScene)
        {
            Application.Quit();
        } 
        else
        {
            SceneManager.LoadScene(sceneName);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Detected");
        if(other.CompareTag("Player"))
        {
            Debug.Log("Switching to " + sceneNameMaster);
            MoveToNextScene(sceneNameMaster);
        }
    }
}
