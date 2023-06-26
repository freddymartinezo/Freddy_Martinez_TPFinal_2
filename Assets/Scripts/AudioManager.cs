using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager obj;

    public AudioClip jump;
    public AudioClip coin;
    public AudioClip gui;
    public AudioClip hit;
    public AudioClip enemyHit;
    public AudioClip win;

    private AudioSource audioSrc;

    private void Awake()
    {
        obj = this;
        audioSrc = gameObject.AddComponent<AudioSource>();
    }

    public void PlayJump() { PlaySound(jump); }
    public void PlayCoin() { PlaySound(coin); }
    public void PlayGui() { PlaySound(gui); }
    public void PlayHit() { PlaySound(hit); }
    public void PlayEnemyHit() { PlaySound(enemyHit); }
    public void PlayWin() { PlaySound(win); }


    public void PlaySound (AudioClip clip)
    {
        audioSrc.PlayOneShot(clip);
    }
    private void OnDestroy()
    {
        obj = null;
    }
}
