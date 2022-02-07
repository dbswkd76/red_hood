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
    }
}
