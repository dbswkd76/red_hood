using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject A;
    Transform AT;
    void Start()
    {
        AT = A.transform;
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, AT.position, 2f * Time.deltaTime);
        transform.Translate(0, 0, 650); //ī�޶� ���� z������ �̵�
    }
}