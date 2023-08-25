using UnityEngine;

namespace Services
{
    public class AudioService : MonoBehaviour, IAudioService
    {
        [SerializeField] private AudioSource _source;
        
        public void Play(AudioClip clip, float volume = 1f)
        {
            _source.clip = clip;
            _source.volume = volume;
            _source.Play(); 
        }

        public void PlayOneShot(AudioClip clip, float volume = 1, bool randomPitch = false)
        {
            _source.pitch = randomPitch ? Random.Range(0.9f, 1.1f) : 1; 
            _source.PlayOneShot(clip, volume);
        }
    }
}