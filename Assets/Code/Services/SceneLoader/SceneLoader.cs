using UnityEngine.SceneManagement;

public static class SceneLoader
{
    private const string MainMenuSceneName = "MainMenu";
    private const string ClickerSceneName = "ClickerScene";

    public static void LoadMainMenu() 
        => LoadScene(MainMenuSceneName);

    public static void LoadClickerScene()  
        => LoadScene(ClickerSceneName);

    private static void LoadScene(string sceneName) 
        => SceneManager.LoadScene(sceneName);
}