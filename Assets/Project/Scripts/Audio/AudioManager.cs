using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour, IGameManager {

    public Sound[] sounds;

    [SerializeField]
    public Slider mSlider;

    public void SetLevel(float sliderValue) {
        PlayerPrefs.SetFloat("Volume", sliderValue);
    }

    public ManagerStatus _Status { get; set; } = ManagerStatus.SHUTDOWN;

    public float soundVolume {
        get { return AudioListener.volume; }
        set { AudioListener.volume = value; }
    }
    public bool soundMute {
        get { return AudioListener.pause; }
        set { AudioListener.pause = value; }
    }

    // This method is called just before the start method
    void Awake() {
        if (mSlider != null)
            mSlider.value = PlayerPrefs.GetFloat("Volume");
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.clip = s.clip;

            s.source.loop = s.loop;
        }
    }

    public void PlayOneShot(string name, float pitch) {
        Sound sourceFounded = Array.Find(sounds, sound => sound.name == name);

        // Manage source not found
        if (sourceFounded == null) {
            Debug.LogWarning("Error: sound with name: '" + name + "' has not been founded");
            return;
        }

        float volume = PlayerPrefs.GetFloat("Volume");

        Debug.Log(volume);

        // To make a more realistic sound each sound cannot sound with the same volume and pitch
        if (name == "FootStepSound") {
            if (volume==0.0f)
                sourceFounded.source.volume = 0.0f;
            else{
                sourceFounded.source.volume = UnityEngine.Random.Range(0.8f, 1.0f);
                sourceFounded.pitch = pitch;
            }
            sourceFounded.source.PlayOneShot(sourceFounded.clip);
            return;
        }
        sourceFounded.source.volume = volume;

        sourceFounded.source.PlayOneShot(sourceFounded.clip);
    }

    public void Play(string name) {
        Sound sourceFounded = Array.Find(sounds, sound => sound.name == name);

        // Manage source not found
        if (sourceFounded == null) {
            Debug.LogWarning("Error: sound with name: '" + name + "' has not been founded");
            return;
        }

        float volume = PlayerPrefs.GetFloat("Volume");

        sourceFounded.source.volume = volume;

        sourceFounded.source.Play();
    }


    public bool isPlaying(string name) {
        Sound sourceFounded = Array.Find(sounds, sound => sound.name == name);

        // Manage source not found
        if (sourceFounded == null) {
            Debug.LogWarning("Error: sound with name: '" + name + "' has not been founded");
            return false;
        }
        return sourceFounded.source.isPlaying;
    }

    public void Stop(string name) {
        Sound sourceFounded = Array.Find(sounds, sound => sound.name == name);

        // Manage source not found
        if (sourceFounded == null) {
            Debug.LogWarning("Error: sound with name: '" + name + "' has not been founded");
            return;
        }

        sourceFounded.source.Stop();
    }

    public void Startup() {
        _Status = ManagerStatus.INITIALIZING;
        //
        _Status = ManagerStatus.STARTED;
    }
}
