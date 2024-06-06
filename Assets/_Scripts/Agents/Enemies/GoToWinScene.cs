using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToWinScene : MonoBehaviour
{
    public void LoadWinScene()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.WinScene);
    }
}
