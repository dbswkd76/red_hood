using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cost : MonoBehaviour
{
    [SerializeField]
    private Text costTxt;
    private float cost1;
    
   
   
    void Start()
    {
        Invoke("costup", 1.0f);
    }
    private void costup()
    {
        cost1++;
       
        
        Invoke("costup", 2.0f);
    }
    // Start is called before the first frame update


    // Update is called once per frame
    public void summon()
    {
        cost1 = Mathf.Clamp(cost1, 0, 100);
        if (Input.GetKeyDown(KeyCode.U)){
            cost1 -= 1;
           
        }
    }
    void Update()
    {
        costTxt.text = " " + cost1;
        summon();
    }
}