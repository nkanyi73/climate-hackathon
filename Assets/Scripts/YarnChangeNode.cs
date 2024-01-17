using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnChangeNode : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public string nodeToBeginPlaying;
    public bool hasBeenTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        dialogueRunner = FindAnyObjectByType<DialogueRunner>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!hasBeenTriggered)
            {
                dialogueRunner.StartDialogue(nodeToBeginPlaying);
                hasBeenTriggered = true;
            }
        }
    }
}
