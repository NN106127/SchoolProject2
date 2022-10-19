using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillColdDown : MonoBehaviour
{
    public Image ICON;
    //public Image ICONB;
    public float skillcolddown;
    public Button skillbutton;
    public float currentCoolDown;//�ثe�ޯ�N�o�ɶ�
    public GameObject Effect;    //�t�X�ޯ��S��
    // Start is called before the first frame update
    void Start()
    {
        currentCoolDown = skillcolddown;
    }

    public void useskillQ()
    {
        Debug.LogFormat("�A�ϥΤF{0}","A�ޯ�");
        ICON.gameObject.SetActive(true);
        currentCoolDown = 0;
        skillbutton.interactable = false;
    }
    public void useskillATK()
    {
        Debug.LogFormat("�A�ϥΤF{0}", "B�ޯ�");
        ICON.gameObject.SetActive(true);
        currentCoolDown = 0;
        skillbutton.interactable = false;
    }

    public bool isCoolingDown()
    {
        if(currentCoolDown < skillcolddown)
        {
            return true;
        }

        return false;
    }
    // Update is called once per frame
    void Update()
    {
        if(currentCoolDown < skillcolddown)
        {
            Effect.SetActive(true);
            currentCoolDown += Time.deltaTime;
            float fillAmountValue = 1 - (currentCoolDown / skillcolddown);
            ICON.fillAmount = fillAmountValue;
            if(ICON.fillAmount<=0)
            {
                skillbutton.interactable = true;
                ICON.gameObject.SetActive(false);
                Effect.SetActive(false);
            }
        }
    }
}
