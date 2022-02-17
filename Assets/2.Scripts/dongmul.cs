using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dongmul : MonoBehaviour
{  
    public int[] DeckArr = new int [] {10, 10, 10};
    public GameObject[] animal1 = new GameObject [8];
    public GameObject[] animal2 = new GameObject [8];
    public GameObject[] animal3 = new GameObject [8];
    private bool isOn = false;
    public GameObject buton;
    public GameObject selectionOryu;
    public GameObject jungbokOryu;
    public GameObject jeojang;
    public GameObject select;
    public int choice;
    public GameObject[] minusbuton = new GameObject [3];
    public GameObject minus;

    public void setDeck(){
        if (!isOn){
            buton.SetActive(true);
            jeojang.SetActive(true);
            select.SetActive(false);
            minus.SetActive(true);
            isOn = true;
        }
        else{
            buton.SetActive(false);
            jeojang.SetActive(false);
            select.SetActive(true);
            minus.SetActive(false);
            isOn = false;
        }
    }

    //public void inAnimal(){

    //}

    public void outDeck(){
        Debug.Log("덱 빼기 실행됨");
        if (isOn){
            if (choice == -1){
                DeckArr[0] = 10;
                for (int k = 0; k<=7; k++)
                    animal1[k].SetActive(false);
                minusbuton[0].SetActive(false);
            }
            else if (choice == -2){
                DeckArr[1] = 10;
                for (int k = 0; k<=7; k++)
                    animal2[k].SetActive(false);
                minusbuton[1].SetActive(false);
            }
            else if (choice == -3){
                DeckArr[2] = 10;
                for (int k = 0; k<=7; k++)
                    animal3[k].SetActive(false);
                minusbuton[2].SetActive(false);
            }
        }
    }
    
    public void inDeck(){
        Debug.Log("덱 집어넣기 실행됨");
        bool inin = false;
        int i = 0;
        if (isOn){
            for(int j=0;j<3;j++){
                i = j;
                if (DeckArr[j] == 10){
                    inin = true;
                    break;
                }
            }
            if (inin==false){
                selectionOryu.SetActive(true);  //오류창 출력
            }
            else if (DeckArr[0]==choice || DeckArr[1]==choice || DeckArr[2]==choice){
                jungbokOryu.SetActive(true);
            }
            else if (i == 0){
                DeckArr[i] = choice;
                animal1[choice].SetActive(true);
                minusbuton[i].SetActive(true);
            }

            else if (i == 1){
                DeckArr[i] = choice;
                animal2[choice].SetActive(true);
                minusbuton[i].SetActive(true);
            }
            else if (i == 2){
                DeckArr[i] = choice;
                animal3[choice].SetActive(true);
                minusbuton[i].SetActive(true);
            }
            
        }
        
    }

    public void close(){
        selectionOryu.SetActive(false);  //오류창 종료버튼
        jungbokOryu.SetActive(false);
    }

}