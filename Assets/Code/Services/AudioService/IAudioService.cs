using UnityEngine;

namespace Services
{
    public interface IAudioService
    {
        public void Play(AudioClip clip, float volume = 1f);
    }
}