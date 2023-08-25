using System;
using UnityEngine;
using Zenject;

namespace Code.Clicker
{
    public class CoinFactory : MonoBehaviour
    {
        [SerializeField] private Coin _prefab;

        [Inject] private DiContainer _container;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }
        
        
        public Coin GetCoin(Vector3 position, Action<Coin> onReachedTarget)
        {
            var coin = _container
                .InstantiatePrefabForComponent<Coin>
                    (_prefab, position, Quaternion.identity, null);

            return coin;
        }

    }
}