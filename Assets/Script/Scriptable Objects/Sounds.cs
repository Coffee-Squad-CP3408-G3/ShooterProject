using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Audio Config", menuName = "Guns/Audio Config", order = 5)]
public class Sounds : ScriptableObject
{
    [Range(0f, 1f)]
    public float volume = 1f;
    public AudioClip[] FireClips;
    public AudioClip EmptyClip;
    public AudioClip ReloadClip;
    public AudioClip LastBulletClip;
    public AudioClip ContinuousFire;


    public void PlayShootingClip(AudioSource AudioSource, bool IsLastBullet = false)
    {
        if (IsLastBullet && LastBulletClip != null) 
        {
            AudioSource.PlayOneShot(LastBulletClip, volume);
        }
        else
        {
            AudioSource.PlayOneShot(FireClips[Random.Range(0, FireClips.Length)], volume);
        }

    }

    public void PlayOutOfAmmoClip(AudioSource AudioSource)
    {
        if (EmptyClip != null)
        {
            AudioSource.PlayOneShot(EmptyClip, volume);
        }
    }

    public void PlayReloadClip(AudioSource AudioSource)
    {
        if (ReloadClip != null) 
        { 
            AudioSource.PlayOneShot(ReloadClip, volume);
        
        }
    }
}
