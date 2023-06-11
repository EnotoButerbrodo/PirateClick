using UnityEngine;
using Zenject;

namespace Code.Clicker
{
    public abstract class Valuable : MonoBehaviour, IClickable
    {
        [SerializeField] private int _coinsValuable = 1;
        [SerializeField] private BoxCollider _coinsCreateArea;
        
        [Inject] private ClickerEvents _clickerEvents;
        
        [ContextMenu("React")]
        public void React()
        {
            CallCoinsEarned();
            OnReact();
        }
        
        private void CallCoinsEarned()
        {
            for (int i = 0; i < _coinsValuable; i++)
            {
                _clickerEvents.CallCoinEarned(GetRandomCreatePoint());
            }
        }

        private Vector3 GetRandomCreatePoint()
        {
            var bounds = _coinsCreateArea.bounds;
            
            return new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                Random.Range(bounds.min.z, bounds.max.z)
            );
        }

        protected abstract void OnReact();
    }
}