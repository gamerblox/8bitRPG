using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicManager : MonoBehaviour {

    AudioSource asource;
    GameTimeManager gtm;

    public AudioClip[] NightAudioClips;
    public AudioClip[] DayAudioClips;

    public bool Reset = false;

    void Start()
    {
        asource = this.GetComponent<AudioSource>();
        gtm = GameTimeManager.GameTime;

    }

    void Update()
    {
        //reset bool for quick debugging
        if (Reset)
        {
            asource.Stop();
            Reset = false;

        }

        //if not playing, then play a clip
        if (!asource.isPlaying)
        {
            //sets clip accoring to time of day
            if ((gtm.CurrentTime / gtm.LengthOfDay) < gtm.MinTimeStart || (gtm.CurrentTime / gtm.LengthOfDay) >= gtm.MaxTimeStart)
            {
                PlayNightSound();

            }
            else PlayDaySound();

        }

    }

    //Plays sound for night
    public void PlayNightSound()
    {
        int clip = Random.Range(0, NightAudioClips.Length);
        asource.clip = NightAudioClips[clip];
        asource.Play();

    }

    //Plays sound for day
    public void PlayDaySound()
    {
        int clip = Random.Range(0, DayAudioClips.Length);
        asource.clip = DayAudioClips[clip];
        asource.Play();

    }

}
