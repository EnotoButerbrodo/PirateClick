using UnityEngine;

namespace Services
{
    public class AudioService : MonoBehaviour, IAudioService
    {
        [SerializeField] private AudioSource _source;
        
        public void Play(AudioClip clip, float volume = 1f)
        {
            _source.PlayOneShot(clip, volume); 
        }
    }
}