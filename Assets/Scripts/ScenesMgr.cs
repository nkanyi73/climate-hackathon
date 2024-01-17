using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesMgr : MonoBehaviour
{
    public string sceneToChangeTo;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Detected");
        if(other.CompareTag("Player"))
        {
            SwitchScene(sceneToChangeTo);
        }
    }

    public void SwitchScene(string sceneToChangeTo)
    {
        SceneManager.LoadScene(sceneToChangeTo);
    }
}
