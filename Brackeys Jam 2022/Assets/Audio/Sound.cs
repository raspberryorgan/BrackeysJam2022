using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound  {
    public AudioClip clip;
    public string name;
    [Range(0f, 1f)]
    public float volume;
    [Range(0f, 1f)]
    public float volumeVariance = .1f;


    [Range(.1f, 3f)]
    public float pitch;
    [Range(0f, 1f)]
    public float pitchVariance = .1f;

    public bool loop;
    [HideInInspector]
    public AudioSource audioSource;
}
