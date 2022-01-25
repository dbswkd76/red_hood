using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckOnOff : MonoBehaviour
{
    public GameObject Info;
    
    public void InfoSetActive()
    {

        
        Info.SetActive(!Info.active);
        GameObject tempInfo = null;
        tempInfo = GameObject.FindWithTag("Info");
        Debug.Log("get" + tempInfo);
        tempInfo.SetActive(false);
        Info.SetActive(!Info.active);
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
