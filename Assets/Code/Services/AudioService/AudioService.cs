using UnityEngine;

namespace Services
{
    public class AudioService : MonoBehaviour, IAudioService
    {
        [SerializeField] private AudioSource _source;
        
        public void Play(AudioClip clip)
        {
            _source.PlayOneShot(clip); 
        }
    }
}