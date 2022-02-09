using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckOnOff : MonoBehaviour
{
    public GameObject Info;
    
    public void InfoSetActive()
    {
        Info.SetActive(true);
        GameObject tempInfo = null;
        tempInfo = GameObject.FindWithTag("Info");
        if (tempInfo.activeSelf == true)
        {
            tempInfo.SetActive(false);
        }

        Info.SetActive(true);
        
      
    }
    // Start is called before the first frame update
    void Start()
    {
       
        gameObject.SetActive(false); 
        
    }

    // Update is called once per frame
    void Update()
    {
        InfoSetActive();
    }
}
