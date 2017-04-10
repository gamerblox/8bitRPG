using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    AudioSource asource;

    public AudioClip[] AudioClips;

    //Plays sound accoring to index
    public void PlaySound(int clip)
    {
        if (asource == null)
            return;
        asource.clip = AudioClips[clip];
        asource.Play();

    }

	void Start ()
    {
        asource = this.GetComponent<AudioSource>();

	}
	
	void Update ()
    {
		

	}

}
