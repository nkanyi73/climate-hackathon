using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Yarn.Unity;

public class DialogueController : MonoBehaviour
{
    public VoiceOverView voiceOverView;

    public AudioSource narrator;

    public void Start()
    {
        voiceOverView = FindAnyObjectByType<VoiceOverView>();
    }

    [YarnCommand("Set_Audio_To_Narrator")]
    public void SetAudioSourceToNarrator()
    {
        if (voiceOverView == null)
        {
            voiceOverView = FindAnyObjectByType<VoiceOverView>();
        }
        voiceOverView.audioSource = narrator;
        Debug.Log("Switching to narrator Audio Source");

    }
}
