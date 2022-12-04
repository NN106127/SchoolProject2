using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnword : MonoBehaviour
{
    public Text m_text;
    public Text s_text;
    public Text t_text;
    public GameObject wordbutton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (gameObject.tag == "spawn")
        {
            m_text.text = "成功逃離迷宮!獲得攻擊能力!";
            s_text.text = "按'E'施放";
            t_text.text = "繼續前行!";


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.tag == "spawn")
        {
            m_text.text = "";
            s_text.text = "";
            t_text.text = "";
            wordbutton.SetActive(false);

        }
    }
}
