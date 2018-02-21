using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance;

    public AudioMixerGroup mixerGroup;

    public Sound[] sounds;

    void Awake() {

        foreach (Sound s in sounds)
        {
            //If there is a target to put the sound effect on, use that target. Else use the audiomanager as target.
            if(s.target.gameObject != null)
            {
                s.source = s.target.gameObject.AddComponent<AudioSource>();
            }
            else
            {
                s.source = gameObject.AddComponent<AudioSource>();
            }
            s.source.clip = s.clip;
            s.source.loop = s.loop;

            //How far the sound will reach.
            s.source.minDistance = s.minDistance;
            s.source.maxDistance = s.maxDistance;

            var newMixerGroup = s.mixerGroup;

            if (newMixerGroup == null)
            {
                newMixerGroup = mixerGroup;
            }

            s.source.outputAudioMixerGroup = newMixerGroup;
        }
    }

    /// <summary>
    /// This function is called from other scripts in order to play the sound clips.
    /// </summary>
    public void Play(string sound) {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));
        s.source.spatialBlend = s.spatialBlend;

        s.source.Play();
    }

}