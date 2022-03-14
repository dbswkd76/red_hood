using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imsi : MonoBehaviour
{
    public float nowhp;
    public float maxhp;

    private void Start()
    {
        nowhp = maxhp;        
    }

    public void Damage(float damage)
    {
        nowhp -= damage;
    }
}
