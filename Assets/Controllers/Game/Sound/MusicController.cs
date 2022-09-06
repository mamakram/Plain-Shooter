using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    // Play an intro Clip followed by a loop
    public AudioSource introAudioSource;
    public AudioSource loopAudioSource;
    public AudioSource gameOverAudioSource;
    void Awake () {
        AudioListener.pause = false;
        double startTime = AudioSettings.dspTime + 0.5;
        introAudioSource.PlayScheduled(startTime);
        loopAudioSource.PlayScheduled(startTime + introAudioSource.clip.length);
    }

    public void GameOverSound()
    {
        introAudioSource.Stop();
        loopAudioSource.Stop();
        gameOverAudioSource.Play();
    }
}
