using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicPlayer;
    public AudioClip[] tracks;
    public float fadeDuration;
    public float targetVolume;
    private int trackIndex = 0;


    void Start()
    {
        //? Start first track:
        musicPlayer.clip = tracks[trackIndex];
        musicPlayer.Play();
        nextTrack();
    }

    void Update()
    {
        //? Check if track is done:
        if (musicPlayer.isPlaying == false) {
            nextTrack();
        }
    }

    void nextTrack() {
        //? Start crossFade
        StartCoroutine(crossFade(musicPlayer,fadeDuration));
    }



    public IEnumerator crossFade(AudioSource audioSource, float duration)
    {
        //? Set base parameters
        float currentTime = 0;
        float start = audioSource.volume;

        //? Fade out:
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, 0, currentTime / duration);
            yield return null;
        }

        //? Change AudioSource to the next track:
        musicPlayer.clip = tracks[trackIndex];
        musicPlayer.Play();
        currentTime = 0;
        start = audioSource.volume;

        //? Fade in:
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }

        //? Increase track index to properly load next track.
        trackIndex++;

    }



}
