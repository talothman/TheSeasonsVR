﻿using UnityEngine;
using System.Collections;

public class PlayAudioOnEnable : MonoBehaviour {
    void OnEnable()
    {
        GetComponent<AudioSource>().Play();
    }
	
}
