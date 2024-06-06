using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] Button _startGame;
    [SerializeField] Button _quit;

    private void Start() 
    {
        _startGame.onClick.AddListener(StartGame);
        _quit.onClick.AddListener(Quit);
    }

    private void StartGame()
    {
        ScenesManager.Instance.LoadNextScene();
        Debug.Log("Start game");
    }

    private void Quit()
    {
        ScenesManager.Instance.QuitGame();
        Debug.Log("Quit");
    }
}
