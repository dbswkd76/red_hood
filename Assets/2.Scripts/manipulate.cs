using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manipulate : MonoBehaviour
{
    static int idx = 0;
    [SerializeField] GameObject[] Panel = new GameObject[5];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
           
            Panel[idx].SetActive(false);
            idx++;
            Panel[idx].SetActive(true);
        }
    }
}
