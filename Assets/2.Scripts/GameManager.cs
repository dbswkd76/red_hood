using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public void SceneChangeRound(){
        SceneManager.LoadScene("윤장");
    }
}
