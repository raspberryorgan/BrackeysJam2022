using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
public class AudioManager : MonoBehaviour {

    public Sound[] sounds;
    public int sources;
    AudioSource[] audioSources;

    public static AudioManager instance;

    void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        foreach (Sound s in sounds)
        {
            
        }
        audioSources = new AudioSource[sources];
        for (int i = 0; i < sources; i++)
        {
            audioSources[i] = gameObject.AddComponent<AudioSource>();
            audioSources[i].mute = true;
        }
    }
    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update() {
        
    }
    public void Play(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        if (s != null)
        {
            AudioSource asource = FindAudioSource();
            asource.clip = s.clip;
            asource.volume = s.volume;
            asource.pitch = s.pitch;
            asource.loop = s.loop;
            asource.Play();
            //Debug.Log("Playing " + soundName);
        }
        else
        {
            //Debug.Log(soundName + " not found.");
        }
    }
    public void PlayStep()
    {
        List<Sound> list = sounds.Where(x => x.name == "step").ToList();
        Sound s = list[UnityEngine.Random.Range(0, list.Count )];
        AudioSource asource = FindAudioSource();
        asource.clip = s.clip;
        asource.volume = s.volume;
        asource.pitch = s.pitch;
        asource.loop = s.loop;
        asource.Play();
    }
    AudioSource FindAudioSource()
    {
        AudioSource asource = audioSources.Where(x => x.isPlaying == false).First();
        asource.mute = false;
        //Debug.Log(asource);
        return asource;
    }
}
