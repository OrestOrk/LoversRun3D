using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip CoinFx;
    [SerializeField] private AudioClip WinFx;
    [SerializeField] private AudioClip LoseFx;

    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        GlobalEventManager.OnLevelFinish += LevelEndMusic;
        GlobalEventManager.OnCoinPickUp += PlayCoinSound;
    }
    private void PlayWinSound()
    {
        audioSource.PlayOneShot(WinFx);
    }
    private void PlayLoseSound()
    {
        audioSource.PlayOneShot(LoseFx);
    }
    private void PlayCoinSound()
    {
        audioSource.PlayOneShot(CoinFx);
    }
    private void LevelEndMusic(bool Win)
    {
        if (Win)
            PlayWinSound();
        else
            PlayLoseSound();
    }
    private void OnDestroy()
    {
        GlobalEventManager.OnLevelFinish -= LevelEndMusic;
        GlobalEventManager.OnCoinPickUp -= PlayCoinSound;
    }
}
