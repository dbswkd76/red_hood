using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plusminusbutton : MonoBehaviour
{
    public dongmul dongmul;
    public int number;
    public void button(){
        dongmul.choice = number;
        Debug.Log("plus 버튼 눌림");
        dongmul.inDeck();
    }

    public void minusbutton(){
        dongmul.choice = number;
        Debug.Log("minus 버튼 눌림");
        dongmul.outDeck();

    }
}
