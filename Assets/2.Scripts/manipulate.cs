using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class manipulate : MonoBehaviour
{
    static int idx = 0;
    [SerializeField] GameObject[] Panel = new GameObject[5];
    [SerializeField] GameObject DeckPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void GameStartButton()
    {
        SceneManager.LoadScene("Round Select");
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
           
            Panel[idx].SetActive(false);
            if (idx == 1)
            {
                DeckPanel.SetActive(true);
            }
            else if(idx==4)
            {
                DeckPanel.SetActive(false);
            }
            idx++;
            Panel[idx].SetActive(true);
            
        }
    }
}
