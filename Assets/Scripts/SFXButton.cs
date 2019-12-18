using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXButton : MonoBehaviour
{
    private AudioManager audioManager;
    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void PlaySFX()
    {
        audioManager.PlayButtonSound();
    }
}
