    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dongmul : MonoBehaviour
{  
    public bool setAS = false;  //동물선택이 false 스킬은 true
    public deckInfo deckInfo;
    [SerializeField] GameObject[] animal1 = new GameObject [8];
    [SerializeField] GameObject[] animal2 = new GameObject [8];
    [SerializeField] GameObject[] animal3 = new GameObject [8];
    private bool isOn = false;
    [SerializeField] GameObject buton;
    [SerializeField] GameObject selectionOryu;
    [SerializeField] GameObject jungbokOryu;
    [SerializeField] GameObject jeojang;
    [SerializeField] GameObject select;
    public int choice;
    [SerializeField] GameObject[] minusbuton = new GameObject [3];
    [SerializeField] GameObject minus;
    public GameObject[] sulmyeongText = new GameObject [8];
    public GameObject[] sulmyeongAni = new GameObject [8];

    [SerializeField] GameObject setAnimalButton;
    [SerializeField] GameObject setSkillButton;

    [SerializeField] GameObject[] skill1 = new GameObject [8];
    [SerializeField] GameObject[] skill2 = new GameObject [8];
    [SerializeField] GameObject[] skill3 = new GameObject [8];
    
    public void setAnimal(){
        if (setAS){
            setAnimalButton.SetActive(true);
            setSkillButton.SetActive(false);
            
            for (int i = 0; i<8; i++){
                skill1[i].SetActive(false);
                skill2[i].SetActive(false);
                skill3[i].SetActive(false);
            }
                
            for (int i = 0; i<3; i++){
                if (0<=deckInfo.DeckArr[i] && deckInfo.DeckArr[i]<=8 && !setAS){
                    if (i==0){
                        animal1[deckInfo.DeckArr[i]].SetActive(true);
                    }
                    else if (i==1){
                        animal2[deckInfo.DeckArr[i]].SetActive(true);
                    }
                    else if (i==2){
                        animal3[deckInfo.DeckArr[i]].SetActive(true);
                    }
                }
            }
            setAS = false;
        }
    }

    public void setSkill(){
        if (!setAS){
            setSkillButton.SetActive(true);
            setAnimalButton.SetActive(false);
            for (int i = 0; i<8; i++){
                skill1[i].SetActive(false);
                skill2[i].SetActive(false);
                skill3[i].SetActive(false);
            }
                
            for (int i = 0; i<3; i++){
                if (0<=deckInfo.SkillArr[i] && deckInfo.SkillArr[i]<=8 && setAS){
                    if (i==0){
                        skill1[deckInfo.SkillArr[i]].SetActive(true);
                    }
                    else if (i==1){
                        animal2[deckInfo.SkillArr[i]].SetActive(true);
                    }
                    else if (i==2){
                        animal3[deckInfo.SkillArr[i]].SetActive(true);
                    }
                }
            }
            setAS = true;
        }

    }

    public async void setDeck(){
        if (!isOn){
            buton.SetActive(true);
            jeojang.SetActive(true);
            select.SetActive(false);
            minus.SetActive(true);
            if (0<=deckInfo.DeckArr[0] && deckInfo.DeckArr[0]<8)
                animal1[deckInfo.DeckArr[0]].SetActive(true);
            if (0<=deckInfo.DeckArr[1] && deckInfo.DeckArr[1]<8)
                animal2[deckInfo.DeckArr[1]].SetActive(true);
            if (0<=deckInfo.DeckArr[2] && deckInfo.DeckArr[2]<8)
                animal3[deckInfo.DeckArr[2]].SetActive(true);
            if (0<=deckInfo.SkillArr[0] && deckInfo.SkillArr[0]<8)
                skill1[deckInfo.SkillArr[0]].SetActive(true);
            if (0<=deckInfo.SkillArr[1] && deckInfo.SkillArr[1]<8)
                skill2[deckInfo.SkillArr[1]].SetActive(true);
            if (0<=deckInfo.SkillArr[2] && deckInfo.SkillArr[2]<8)
                skill3[deckInfo.SkillArr[2]].SetActive(true);
            isOn = true;
        }
        else{
            buton.SetActive(false);
            jeojang.SetActive(false);
            select.SetActive(true);
            minus.SetActive(false);
            for (int i = 0; i<=7; i++){
                animal1[i].SetActive(false);
                animal2[i].SetActive(false);
                animal3[i].SetActive(false);
                skill1[i].SetActive(false);
                skill2[i].SetActive(false);
                skill3[i].SetActive(false);
            }

            isOn = false;
        }
    }

    //public void inAnimal(){

    //}

    public void outDeck(){
        Debug.Log("덱 빼기 실행됨");
        if (isOn && !setAS){
            if (choice == -1){
                deckInfo.DeckArr[0] = 10;
                for (int k = 0; k<=7; k++)
                    animal1[k].SetActive(false);
                minusbuton[0].SetActive(false);
            }
            else if (choice == -2){
                deckInfo.DeckArr[1] = 10;
                for (int k = 0; k<=7; k++)
                    animal2[k].SetActive(false);
                minusbuton[1].SetActive(false);
            }
            else if (choice == -3){
                deckInfo.DeckArr[2] = 10;
                for (int k = 0; k<=7; k++)
                    animal3[k].SetActive(false);
                minusbuton[2].SetActive(false);
            }
        }
        else if (isOn && setAS){
            if (choice == -1){
                deckInfo.SkillArr[0] = 10;
                for (int k = 0; k<=7; k++)
                    skill1[k].SetActive(false);
                minusbuton[0].SetActive(false);
            }
            else if (choice == -2){
                deckInfo.SkillArr[1] = 10;
                for (int k = 0; k<=7; k++)
                    skill2[k].SetActive(false);
                minusbuton[1].SetActive(false);
            }
            else if (choice == -3){
                deckInfo.SkillArr[2] = 10;
                for (int k = 0; k<=7; k++)
                    skill3[k].SetActive(false);
                minusbuton[2].SetActive(false);
            }
        }
    }
    
    public void inDeck(){
        Debug.Log("덱 집어넣기 실행됨");
        bool inin = false;
        int i = 0;
        if (isOn && !setAS){
            for(int j=0;j<3;j++){
                i = j;
                if (deckInfo.DeckArr[j] == 10){
                    inin = true;
                    break;
                }
            }
            if (inin==false){
                selectionOryu.SetActive(true);  //오류창 출력
            }
            else if (deckInfo.DeckArr[0]==choice || deckInfo.DeckArr[1]==choice || deckInfo.DeckArr[2]==choice){
                jungbokOryu.SetActive(true);
            }
            else if (i == 0){
                deckInfo.DeckArr[i] = choice;
                animal1[choice].SetActive(true);
                minusbuton[i].SetActive(true);
            }

            else if (i == 1){
                deckInfo.DeckArr[i] = choice;
                animal2[choice].SetActive(true);
                minusbuton[i].SetActive(true);
            }
            else if (i == 2){
                deckInfo.DeckArr[i] = choice;
                animal3[choice].SetActive(true);
                minusbuton[i].SetActive(true);
            }
            
        }
        else if (isOn && setAS){
            for(int j=0;j<3;j++){
                i = j;
                if (deckInfo.SkillArr[j] == 10){
                    inin = true;
                    break;
                }
            }
            if (inin==false){
                selectionOryu.SetActive(true);  //오류창 출력
            }
            else if (deckInfo.SkillArr[0]==choice || deckInfo.SkillArr[1]==choice || deckInfo.SkillArr[2]==choice){
                jungbokOryu.SetActive(true);
            }
            else if (i == 0){
                deckInfo.SkillArr[i] = choice;
                skill1[choice].SetActive(true);
                minusbuton[i].SetActive(true);
            }

            else if (i == 1){
                deckInfo.SkillArr[i] = choice;
                skill2[choice].SetActive(true);
                minusbuton[i].SetActive(true);
            }
            else if (i == 2){
                deckInfo.SkillArr[i] = choice;
                skill3[choice].SetActive(true);
                minusbuton[i].SetActive(true);
            }  
        }
        
    }

    public void close(){
        selectionOryu.SetActive(false);  //오류창 종료버튼
        jungbokOryu.SetActive(false);
    }

}
