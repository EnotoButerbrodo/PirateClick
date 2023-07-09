using System;
using Services;
using UnityEngine;
using Zenject;

namespace Code.Clicker
{
    public class ClickEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particlePrefab;
        [SerializeField] private AudioClip _clickClip;

        [Inject] private ClickerEvents _events;
        [Inject] private IAudioService _audio;

        private void OnEnable()
        {
            _events.ClickableClicked += React;
        }

        private void React(Vector3 clickPosition, IClickable collider)
        {
            Instantiate(_particlePrefab, clickPosition, Quaternion.identity);
            _audio.Play(_clickClip, 0.25f);
        }
    }
}