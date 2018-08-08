﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ClickSound : MonoBehaviour
{
    [SerializeField]
    public AudioClip sound;
	// Use this for initialization

    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
	void Start ()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;

        button.onClick.AddListener(() => PlaySound());
        source.volume = 0.8f;
	}
	
    void PlaySound()
    {
        source.PlayOneShot(sound);
    }


}
