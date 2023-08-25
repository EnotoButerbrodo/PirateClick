using System.Collections;
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
        
        public Vector3 GetTargetWorldPosition()
        {
            var targetPivot = _coinPickupPosition.pivot;
                
            var targetViewportPosition = new Vector3(
                targetPivot.x
                , targetPivot.y
                , _camera.nearClipPlane);

            Vector3 targetWorldPosition = _camera.ViewportToWorldPoint(targetViewportPosition);
            
            return targetWorldPosition;
        }
        private void Start()
        {
            _camera = Camera.main;
        }

        private void OnEnable()
        {
            _clickerEvents.CoinEarned += OnCoinEarned;
            _clickerEvents.ValuableUnlocked += OnValuableUnlock;
        }

        private void OnValuableUnlock(int cost, ILockedObject unlockedobject)
        {
            StartCoroutine(UnlockCoroutine(cost, unlockedobject));
        }

        private IEnumerator UnlockCoroutine(int cost, ILockedObject unlockedObject)
        {
            var waiter = new WaitForSeconds(1f / cost);
            for (int i = 0; i < cost; i++)
            {
                Coin coin = _coinFactory.GetCoin(GetTargetWorldPosition(), (c) => {unlockedObject.GetCoin();});
                coin.SetTarget(() => unlockedObject.Position
                    , (c) => {unlockedObject.GetCoin();});
                
                yield return waiter;
            }   
        }

        private void OnDisable()
        {
            _clickerEvents.CoinEarned -= OnCoinEarned;
        }

        private void OnCoinEarned(int count, ICoinsSource coinsSource)
        {
            StartCoroutine(CoinsEarnCoroutine(count, coinsSource));
        }

        private IEnumerator CoinsEarnCoroutine(int coinsCount, ICoinsSource coinsSource)
        {
            var waiter = new WaitForSeconds(1f / coinsCount);
            for (int i = 0; i < coinsCount; i++)
            {
                var coin = _coinFactory.GetCoin(coinsSource.GetRandomEarnPosition(), OnCoinWalletPickup);
                coin.SetTarget(GetTargetWorldPosition, OnCoinWalletPickup);
                yield return waiter;
            }   
        }
        

        private void OnCoinWalletPickup(Coin coin)
        {
            _audio.PlayOneShot(_pickupAudio, 0.5f);
            _wallet.Add(1);
        }
        
        
    }
}