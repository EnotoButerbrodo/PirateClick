using UnityEngine.SceneManagement;

public static class SceneLoader
{
    private const string MainMenuSceneName = "MainMenu";
    private const string CoinSceneName = "CoinScene";

    public static void LoadMainMenu() 
        => LoadScene(MainMenuSceneName);

    public static void LoadCoinScene()
        => LoadScene(CoinSceneName);

    private static void LoadScene(string sceneName) 
        => SceneManager.LoadScene(sceneName);
}