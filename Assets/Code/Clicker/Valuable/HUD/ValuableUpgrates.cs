using System.Collections.Generic;
using UnityEngine;

namespace Code.Clicker.HUD
{
    public class ValuableUpgrates : MonoBehaviour
    {
        [SerializeField] private Valuable _valuable;

        [SerializeField] private List<float> _reloadReduceValues = new List<float>
            (new[] {0.5f, 0.5f, 0.5f});


        private int _currentReloadUpgrate = 0;
        
        public bool HasReloadUpgrade() 
            => _currentReloadUpgrate < _reloadReduceValues.Count;

        public void UpgrateReload()
        {
            _valuable.Stats.CoinsRefreshTime -= _reloadReduceValues[_currentReloadUpgrate++];
        }
    }
}