using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _coinSceneButton;
    
    private void OnEnable()
    {
        _coinSceneButton.onClick.AddListener(OpenCoinScene);
    }

    private void OnDisable()
    {
        _coinSceneButton.onClick.RemoveListener(OpenCoinScene);
    }

    private void OpenCoinScene() 
        => SceneLoader.LoadCoinScene();
    
}