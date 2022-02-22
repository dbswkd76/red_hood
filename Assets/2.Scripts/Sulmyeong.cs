using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sulmyeong : MonoBehaviour
{
    public dongmul dongmul;
    [SerializeField] int sulmyeongCode;

    public void sulmyeongOn(){
        for (int i = 0; i<8; i++){
            dongmul.sulmyeongText[i].SetActive(false);
            dongmul.sulmyeongAni[i].SetActive(false);
        }
        dongmul.sulmyeongText[sulmyeongCode].SetActive(true);
        dongmul.sulmyeongAni[sulmyeongCode].SetActive(true);
    }
}
