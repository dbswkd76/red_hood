using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sulmyeong : MonoBehaviour
{
    public dongmul dongmul;
    private int sulmyeongCode;

    public void sulmyeongOn(){
        for (int i = 0; i<8; i++){
            dongmul.sulmyeongText[i].SetActive(false);
            dongmul.sulmyeongAni[i].SetActive(false);
        }
        dongmul.sulmyeongText[sulmyeongCode].SetActive(true);
        dongmul.sulmyeongAni[sulmyeongCode].SetActive(true);
    }
    private void Start()
    {
        
        if(name.Equals("meerkat"))
            sulmyeongCode=0;
        if(name.Equals("snake"))
            sulmyeongCode=1;
        if(name.Equals("raven"))
            sulmyeongCode=2;
        if(name.Equals("fox"))
            sulmyeongCode=3;
        if(name.Equals("deer"))
            sulmyeongCode=4;
        if(name.Equals("eagle"))
            sulmyeongCode=5;
        if(name.Equals("panther"))
            sulmyeongCode=6;   
        if(name.Equals("bear"))
            sulmyeongCode=7;
    }
}
