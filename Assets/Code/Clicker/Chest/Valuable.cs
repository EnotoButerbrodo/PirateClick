using UnityEngine;
using Zenject;

namespace Code.Clicker
{
    public abstract class Valuable : MonoBehaviour, IClickable
    {
        [SerializeField] private int _coinsValuable = 1;
        [Inject] private ClickerEvents _clickerEvents;
        
        [ContextMenu("React")]
        public void React()
        {
            CallCoinsEarned();
            OnReact();
        }
        
        private void CallCoinsEarned()
        {
            var position = transform.position;
            for (int i = 0; i < _coinsValuable; i++)
            {
                _clickerEvents.CallCoinEarned(position);
            }
        }

        protected abstract void OnReact();
    }
}