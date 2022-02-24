using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    public static AudioManager instance;

    void Awake() {
        if ( instance != null ) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        foreach(Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;
        }
    }
    // Use this for initialization
    void Start()
    {


    }
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown(KeyCode.X))
        {
            Play("test");
        }
	}
    public void Play(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        if (s!= null)
        {
            s.audioSource.Play();
        }
    }
}
