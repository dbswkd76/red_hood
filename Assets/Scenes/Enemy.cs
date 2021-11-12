using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public GameObject prfHpBar;
    public GameObject canvas;

    RectTransform hpBar;
    public float height = 1.7f;
    void Start()
    {
        hpBar = Instantiate(prfHpBar, canvas.transform).GetComponent<RectTransform>();
        //m_goHpBar = GameObject.Find("Canvas/Slider");
        //wolf = GameObject.Find("ready_1");
    }

    void Update()
    {
        Vector3 _hpBarPos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0));
        hpBar.position = _hpBarPos;
        //// �׽�Ʈ�� ���� Ű���� �̵� ����
        //float fHorizontal = Input.GetAxis("Horizontal");
        //float fVertical = Input.GetAxis("Vertical");

        //transform.Translate(Vector3.right * Time.deltaTime * m_fSpeed * fHorizontal, Space.World);
        //transform.Translate(Vector3.up * Time.deltaTime * m_fSpeed * fVertical, Space.World);
        //// �׽�Ʈ�� ���� Ű���� �̵� ��


        //// ������Ʈ�� ���� HP Bar ��ġ �̵�
        //m_goHpBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.8f, 0));
        //wolf.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.8f, 0));
    }
}


