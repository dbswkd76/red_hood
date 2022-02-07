using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dongmul : MonoBehaviour
{  
    public int[] DeckArr = new int [] {0, 0, 0};
    public GameObject[] animal1 = new GameObject [8];
    public GameObject[] animal2 = new GameObject [8];
    public GameObject[] animal3 = new GameObject [8];
    private bool isOn = false;
    public GameObject buton;
    public GameObject selectionOryu;
    public GameObject jeojang;
    public GameObject select;
    public int choice;

    public void setDeck(){
        if (!isOn){
            buton.SetActive(true);
            jeojang.SetActive(true);
            select.SetActive(false);
            isOn = true;
        }
        else{
            buton.SetActive(false);
            jeojang.SetActive(false);
            select.SetActive(true);
            isOn = false;
        }
    }

    //public void inAnimal(){

    //}

    //public void outDeck(int jari){
        //if (isOn){
            //gameObject.SetActive(false);
            //DeckArr[jari] = 0;
        //}
    //}
    
    public void inDeck(){
        bool inin = false;
        if (isOn){
            for(int i=0;i<3;i++){
                if (DeckArr[i] == 0){
                    inin = true;
                    break;
                }
            }
            if (inin==false){
                selectionOryu.SetActive(true);  //오류창 출력
            }
            else if (i == 0){
                DeckArr[i] = choice;
                animal1[choice].SetActive(true);
            }

            else if (i == 1){
                DeckArr[i] = choice;
                animal1[choice].SetActive(true);
            }
            else if (i == 2){
                DeckArr[i] = choice;
                animal1[choice].SetActive(true);
            }
            
        }
        
    }

    public void close(){
        selectionOryu.SetActive(false);  //오류창 종료버튼
    }

}
