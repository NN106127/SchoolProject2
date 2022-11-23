using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currect : MonoBehaviour
{
    public GameObject img;
    public GameObject img1;
    public GameObject img2;
    public GameObject img3;
    public GameObject img4;
    public GameObject img5;
    public GameObject img6;
    public GameObject img7;

    public GameObject cur;
    public GameObject cur1;
    public GameObject cur2;
    public GameObject cur3;
    public GameObject cur4;
    public GameObject cur5;
    public GameObject cur6;
    public GameObject cur7;

    public Text m_text;
    //public GameObject finishcavcas;
    public GameObject door;
    public GameObject PluzzCavcas;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (PluzzCavcas.activeSelf)
        {
            if (img.transform.position.x == cur.transform.position.x && img.transform.position.y == cur.transform.position.y)
            {

                if (img1.transform.position.x == cur1.transform.position.x && img1.transform.position.y == cur1.transform.position.y)
                {

                    if (img2.transform.position.x == cur2.transform.position.x && img2.transform.position.y == cur2.transform.position.y)
                    {

                        if (img3.transform.position.x == cur3.transform.position.x && img3.transform.position.y == cur3.transform.position.y)
                        {

                            if (img4.transform.position.x == cur4.transform.position.x && img4.transform.position.y == cur4.transform.position.y)
                            {

                                if (img5.transform.position.x == cur5.transform.position.x && img5.transform.position.y == cur5.transform.position.y)
                                {
                                    if (img6.transform.position.x == cur6.transform.position.x && img6.transform.position.y == cur6.transform.position.y)
                                    {

                                        if (img7.transform.position.x == cur7.transform.position.x && img7.transform.position.y == cur7.transform.position.y)
                                        {
                                            
                                            m_text.text = "謎題已解開，前方道路已開啟";
                                            door.SetActive(true);
                                            PluzzCavcas.SetActive(false);
                                            


                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            m_text.text = "謎題已解開，前方道路已開啟";
            door.SetActive(true);
            PluzzCavcas.SetActive(false);
        }
    }
}
