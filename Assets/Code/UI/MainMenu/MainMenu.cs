using UnityEngine;
using UnityEngine.UI;


namespace Code.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _clickerSceneCoin;

        private void OnEnable()
        {
            _clickerSceneCoin.onClick.AddListener(OnClickerButton);
        }

        private void OnDisable()
        {
            _clickerSceneCoin.onClick.RemoveListener(OnClickerButton);
        }

        private void OnClickerButton()
            => SceneLoader.LoadClickerScene();

    }
}