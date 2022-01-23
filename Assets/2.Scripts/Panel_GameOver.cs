using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Panel_GameOver : MonoBehaviour
{
    
    private void Awake()
    {
        transform.gameObject.SetActive(false); 
    }

    public void Show()
    { 
        transform.gameObject.SetActive(true);
        Debug.Log("panel on");
    }

    public void OnClick_Retry() // 재도전 함수
    {
        SceneManager.LoadScene("yunjang"); 
    }
   
}
