using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CutSceneManager : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;

    [SerializeField]
    private Slider slider;

    private void Awake()
    {
        videoPlayer = GetComponentInChildren<VideoPlayer>();
        slider = GetComponentInChildren<Slider>();
    }

    private void Start()
    {
        videoPlayer.loopPointReached += LoadLevel1;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            slider.value += Time.deltaTime;
        }
        else
        {
            slider.value -= Time.deltaTime;
        }

        if (slider.value >= 1)
        {
            ScenesManager.Instance.LoadNextScene();
        }
    }

    private void LoadLevel1(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("Final cut scene");
        ScenesManager.Instance.LoadNextScene();
    }
}
