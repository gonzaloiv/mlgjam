using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class AudioSystem : Singleton<AudioSystem> {

    #region Fields / Properties

    [SerializeField] private List<AudioSource> audioSources;
    [SerializeField] private List<AudioClip> musicAudioClips;
    [SerializeField] private List<AudioClip> errorAudioClips;
    [SerializeField] private List<AudioClip> successAudioClips;
    [SerializeField] private List<AudioClip> gameplayAudioClips;

    #endregion

    #region Public Behaviour

    public void PlayAudioClip (string audioClipName, AudioLayer audioLayer, bool stopCurrentAudioClip = false) {
        DoPlayAudioClip(GetAudioClip(audioClipName, audioLayer), audioLayer, stopCurrentAudioClip);
    }

    public void PlayAudioClip (AudioClip audioClip, AudioLayer audioLayer, bool stopCurrentAudioClip = false) {
        DoPlayAudioClip(audioClip, audioLayer, stopCurrentAudioClip);
    }

    public void PlayRandomAudioClip (AudioLayer audioLayer, bool stopCurrentAudioClip = false) {
        DoPlayAudioClip(GetRandomAudioClip(audioLayer), audioLayer, stopCurrentAudioClip);
    }

    public void StopAudioSource (AudioLayer audioLayer) {
        GetAudioSource(audioLayer).Stop();
    }

    public void StopAudioSources () {
        audioSources.ForEach(source => source.Stop());
    }

    #endregion

    #region Private Behaviour

    private AudioSource DoPlayAudioClip (AudioClip audioClip, AudioLayer audioLayer, bool stopCurrentAudioClip) {

        AudioSource audioSource = GetAudioSource(audioLayer);

        if (stopCurrentAudioClip && audioSource.isPlaying)
            audioSource.Stop();

        if (audioLayer == AudioLayer.Music && audioSource.isPlaying && audioClip == audioSource.clip)
            return null;

        if (audioClip != null) {
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        return audioSource;

    }

    private AudioClip GetAudioClip (string audioClipName, AudioLayer audioLayer) {
        AudioClip audioClip = null;
        switch (audioLayer) {
            case AudioLayer.Music:
                audioClip = musicAudioClips.FirstOrDefault(clip => clip.name == audioClipName);
                break;
            case AudioLayer.Error:
                audioClip = errorAudioClips.FirstOrDefault(clip => clip.name == audioClipName);
                break;
            case AudioLayer.Success:
                audioClip = successAudioClips.FirstOrDefault(clip => clip.name == audioClipName);
                break;
            case AudioLayer.Gameplay:
                audioClip = gameplayAudioClips.FirstOrDefault(clip => clip.name == audioClipName);
                break;
        }
        return audioClip;
    }

    private AudioClip GetRandomAudioClip (AudioLayer audioLayer) {
        AudioClip audioClip = null;
        switch (audioLayer) {
            case AudioLayer.Error:
                audioClip = errorAudioClips[UnityEngine.Random.Range(0, errorAudioClips.Count)];
                break;
            case AudioLayer.Success:
                audioClip = successAudioClips[UnityEngine.Random.Range(0, successAudioClips.Count)];
                break;
        }
        return audioClip;
    }

    private AudioSource GetAudioSource (AudioLayer audioLayer) {
        return audioSources[(int) audioLayer];
    }

    #endregion

}
