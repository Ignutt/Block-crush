using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        
        public AudioMixerGroup audioMixer;
        public Sound[] sounds;

        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            foreach (Sound sound in sounds)
            {
                sound.audioSource = gameObject.AddComponent<AudioSource>();
                sound.audioSource.clip = sound.audioClip;

                sound.audioSource.volume = sound.volume;
                sound.audioSource.playOnAwake = sound.playOnAwake;

                sound.audioSource.outputAudioMixerGroup = audioMixer;
                if (sound.playOnAwake) sound.audioSource.Play();
            }
            SetMusicStatus(Utils.MusicValue);
        }

        public void Play(string clipName)
        {
            Array.Find(sounds, sound => sound.name == clipName).audioSource.Play();
        }

        public void Stop(string clipName)
        {
            Array.Find(sounds, sound => sound.name == clipName).audioSource.Stop();
        }

        public bool IsPlaying(string clipName)
        {
            return Array.Find(sounds, sound => sound.name == clipName).audioSource.isPlaying;
        }

        public void SetMusicStatus(float value)
        {
            value -= 80;
            audioMixer.audioMixer.SetFloat(Utils.AudioMixerMusicProp, value);
        }
    }
}
