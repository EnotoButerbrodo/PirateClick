using Services;
using UnityEngine;
using Zenject;

namespace Code.Clicker
{
    public class ChestAudio : MonoBehaviour
    {
        [Inject] private IAudioService _audio;

        [SerializeField] private AudioClip _landClip;
        
        public void PlayLand()
        {
            _audio.Play(_landClip, 0.25f);
        }
    }
}