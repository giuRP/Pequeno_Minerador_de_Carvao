using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIInGameMenu : MonoBehaviour
{
    public GameObject menuPanel;

    public void ToggleMenu()
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    public void ResetTimeScale()
    {
        Time.timeScale = 1;
    }

    public void LoadMenu()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.MainMenu);
    }

    public void RestartLevel()
    {
        ScenesManager.Instance.LoadCurrentScene();
    }

    public void LoadNextScene()
    {
        ScenesManager.Instance.LoadNextScene();
    }
}
