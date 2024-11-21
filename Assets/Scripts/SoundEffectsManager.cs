using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SoundEffectsManager : MonoBehaviour
{
    // singleton
    public static SoundEffectsManager instance;
 
    [SerializeField] private AudioSource soundEffectObject;
 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
 
    public void PlaySoundEffect(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        AudioSource source = Instantiate(soundEffectObject, spawnTransform.position, Quaternion.identity);
 
        source.clip = audioClip;
 
        source.volume = volume;
 
        source.Play();
 
        float clipLength = source.clip.length;
 
        Destroy(source.gameObject, clipLength);
 
    }
 
    public void PlayRandomSoundEffect(AudioClip[] audioClips, Transform spawnTransform, float volume)
    {
 
        int rand = Random.Range(0, audioClips.Length);
 
        AudioSource source = Instantiate(soundEffectObject, spawnTransform.position, Quaternion.identity);
 
        source.clip = audioClips[rand];
 
        source.volume = volume;
 
        source.Play();
 
        float clipLength = source.clip.length;
 
        Destroy(source.gameObject, clipLength);
 
    }
}