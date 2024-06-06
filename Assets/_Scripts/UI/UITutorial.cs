using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITutorial : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(DisableTutorialPanel());
    }

    IEnumerator DisableTutorialPanel()
    {
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(false);
    }
}
