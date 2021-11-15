//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//public class EnemyhpBar : MonoBehaviour
//{


//    private float maxhp = 100;
//    public float nowhp = 100;

//    public GameObject hpbar_background;
//    public Image hpbar;



//    void Start()
//    {
//        hpbar.fillAmount = 1f;
//    }
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            nowhp -= 10;
//        }
//        hpbar.fillAmount = (float)nowhp /(float) maxhp;
//        hpbar_background.SetActive(true);
//    }
//}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//public class EnemyhpBar : MonoBehaviour
//{
//    //[SerializeField] GameObject prfHpBar;
//    //[SerializeField] Slider hpbar;
//    //List<Transform> m_enemyList = new List<Transform>();
//    //List<GameObject> m_hpBarList = new List<GameObject>();
//    //Camera m_cam = null;

//    //private float maxhp = 100;
//    //private float nowhp = 100;

//    private GameObject m_goHpBar;
//    private float m_fSpeed = 5.0f;


//    //private void HandleHp()
//    //{
//    //    hpbar.value = (float)nowhp / (float)maxhp;
//    //}
//    void Start()
//    {
//        m_goHpBar = GameObject.Find("hpbar test/Slider");
//    }
//    void Update()
//    {
//        m_goHpBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.8f, 0));
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyhpBar : MonoBehaviour
{
    [SerializeField] GameObject prfHpBar;
    //[SerializeField] Slider hpbar;
    List<Transform> m_enemyList = new List<Transform>();
    List<GameObject> m_hpBarList = new List<GameObject>();
    Camera m_cam = null;

    private float maxhp = 100;
    private float nowhp = 100;

    //private void HandleHp()
    //{
    //    hpbar.value = (float)nowhp / (float)maxhp;
    //}

    void Start()
    {
        //hpbar.value = (float)nowhp / (float)maxhp;
        m_cam = Camera.main;
        GameObject[] t_objects = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < t_objects.Length; i++)
        {
            m_enemyList.Add(t_objects[i].transform);
            GameObject t_hpbar = Instantiate(prfHpBar, t_objects[i].transform.position, Quaternion.identity, transform);
            m_hpBarList.Add(t_hpbar);
        }

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            nowhp -= 10;
        }
        //HandleHp();
        for (int i = 0; i < m_enemyList.Count; i++)
        {
            m_hpBarList[i].transform.position = m_cam.WorldToScreenPoint(m_enemyList[i].position + new Vector3(0, 0.5f, 0));
        }

    }
}



