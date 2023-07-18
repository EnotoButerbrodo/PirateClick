using Code.Clicker;
using TMPro;
using UnityEngine;

namespace Code.UI.Presenters
{
    public class CostPresenter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private LockedObject _lockedObject;

        private void Awake()
        {
            _text.text = _lockedObject.Cost.ToString();
        }
    }
}