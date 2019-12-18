using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;



public static class AudioController
{
    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
        audioSource.Stop();
        audioSource.volume = startVolume;

    }
    public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
        audioSource.volume = 0f;
        audioSource.Play();
        while (audioSource.volume < startVolume)
        {
            audioSource.volume += Time.deltaTime / FadeTime;
            yield return null;
        }
    }
}
public class AudioManager : MonoBehaviour
{
    [SerializeField] Sound[] sounds;
    [SerializeField] Sound[] buttonEffects;
    [SerializeField] AudioMixerGroup audioMixer;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null) { instance = this; }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = audioMixer;
        }

        foreach (Sound s in buttonEffects)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = audioMixer;
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StopAll();
        switch (scene.buildIndex)
        {

            case 0:
                // Menu scene
                Play("menu_loop", 0.3f);
                break;

            case 1:
                // Level scene
                Play("main_loop", 0.3f);
                break;

            default:
                break;
        }

    }


    public void Play(string name, float fadeInTime)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        if (sound == null) { return; }


        if (fadeInTime > 0)
        {

            StartCoroutine(AudioController.FadeIn(sound.source, fadeInTime));
        }
        else
        {
            sound.source.Play();
        }

    }
    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(buttonEffects, s => s.name == name);
        if (sound == null) { return; }
        sound.source.Play();
    }

    public void Stop(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        if (sound == null) { return; }
        sound.source.Stop();
    }

    public void StopSFX(string name)
    {
        Sound sound = Array.Find(buttonEffects, s => s.name == name);
        if (sound == null) { return; }
        sound.source.Stop();
    }

    public void StopMainLevelSounds()
    {
        Sound sound = Array.Find(sounds, s => s.name == "main_loop");
        if (sound == null) { return; }
        StartCoroutine(AudioController.FadeOut(sound.source, 0.7f));
    }

    public void PlayButtonSound()
    {
        int index = UnityEngine.Random.Range(0, buttonEffects.Length);
        PlaySFX(buttonEffects[index].name);
    }

    private void StopAll()
    {
        foreach (Sound s in sounds)
        {
            Stop(s.name);
        }
    }


}
