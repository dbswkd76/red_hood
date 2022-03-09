using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public void SceneChangeRound(){
        Debug.Log("라운드선택");
        SceneManager.LoadScene("uitest");
    }
    public void SceneDeckSetting(){
        Debug.Log("덱셋팅");
        SceneManager.LoadScene("DeckSetting");
    }
}
