
using System;
using System.Collections;
using DG.Tweening;

using Services;
using UnityEngine;
using Zenject;

namespace Code.Clicker
{
    public class CoinPicker : MonoBehaviour
    {
        [SerializeField] private CoinFactory _coinFactory;
        [SerializeField] private RectTransform _coinPickupPosition;
        [SerializeField] private AudioClip _pickupAudio;
            
        [Inject] private IWallet _wallet;
        [Inject] private ClickerEvents _clickerEvents;
        [Inject] private IAudioService _audio;

        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void OnEnable()
        {
            _clickerEvents.CoinEarned += OnCoinEarned;
            _clickerEvents.CoinPicked += OnCoinPickup;
        }

        private void OnDisable()
        {
            _clickerEvents.CoinEarned -= OnCoinEarned;
        }

        private void OnCoinEarned(Vector3 earnWorldPosition)
        {
            var coin = _coinFactory.Get(earnWorldPosition);
            
            CreateCoin(coin);
        }

        private void CreateCoin(Coin coin)
        {
            coin.SetTarget(_coinPickupPosition);
        }

        private void OnCoinPickup(Coin coin)
        {
            _audio.Play(_pickupAudio, 0.5f);
            _wallet.Add(1);
        }
    }
}