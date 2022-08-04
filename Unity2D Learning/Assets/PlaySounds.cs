using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour
{
    [SerializeField] private AudioSource flipSoundEffect;
    [SerializeField] private AudioSource runSoundEffect;

    public void PlaySoundFlip()
    {
        if (!flipSoundEffect.isPlaying == true)
        {
            flipSoundEffect.Play();
        }
        
    }
    

    public void PlaySoundRun()
    {
        if(!runSoundEffect.isPlaying == true)
        {
            runSoundEffect.Play();
        } else
        {
            runSoundEffect.Stop();
        }
    }
}
