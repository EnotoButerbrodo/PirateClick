using System;
using UnityEngine;
using Zenject;

namespace Code.Clicker
{
    public class ClickEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particlePrefab;
        
        [Inject] private ClickerEvents _events;

        private void OnEnable()
        {
            _events.ClickableClicked += React;
        }

        private void React(Vector3 clickPosition, IClickable collider)
        {
            Instantiate(_particlePrefab, clickPosition, Quaternion.identity);
        }
    }
}