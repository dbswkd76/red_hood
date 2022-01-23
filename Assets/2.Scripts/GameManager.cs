using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public void Start(){
        Awake();
    }
    public void SceneChangeRound(){
        Debug.Log("라운드선택");
        SceneManager.LoadScene("yunjang");
    }
    public void SceneDeckSetting(){
        Debug.Log("덱셋팅");
        SceneManager.LoadScene("DeckSetting");
    }
    public void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(1080, 720, true);
    }
    public void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(1080, 720, true);
    }
}
