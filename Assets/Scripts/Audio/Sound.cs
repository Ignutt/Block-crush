using UnityEngine;

namespace Audio
{
    [System.Serializable]
    public class Sound
    {
        public string name;

        public AudioClip audioClip;
    
        [Range(0f, 1f)]
        public float volume = 1;

        public bool playOnAwake = false;

        [HideInInspector]
        public AudioSource audioSource;
    }
}
