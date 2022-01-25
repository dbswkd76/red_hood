using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dongmul : MonoBehaviour
{
    public int[] deck = new int[3];
    public int dongmulPlus;
    public int dongmulMinus;

    public void start(){
        if (deck[0]==0){
            deckStart();
        }
    }
    private void deckStart(){
        deck[0] = 1;
        deck[1] = 2;
        deck[2] = 3;
    }

    public void deckMinus(){
        deck[dongmulMinus] = 0;
    }

    public void deckPlus(){
        deck[dongmulPlus] = dongmulPlus;
    }


}
