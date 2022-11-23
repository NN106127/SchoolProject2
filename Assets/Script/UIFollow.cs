using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollow : MonoBehaviour
{
    public Enmey mon;
    public GameObject MonBar;

    //血量設定
    public const int maxHealth = 350;  //怪物血量總量
    public int currentHealth = maxHealth; // maxHealth = LifePoint

    //血量條
    public RectTransform HealthBar, Hurt;

    //血條跟隨
    public float xOffset;
    public float yOffset;
    public RectTransform barSet;

    void Update()
    {
        Vector2 Monster2DPosition = Camera.main.WorldToScreenPoint(mon.transform.position);
        barSet.position = Monster2DPosition + new Vector2(xOffset, yOffset);

        if (Monster2DPosition.x > Screen.width || Monster2DPosition.x < 0 || Monster2DPosition.y > Screen.height || Monster2DPosition.y < 0)
        {
            barSet.gameObject.SetActive(false);
        }
        else
        {
            barSet.gameObject.SetActive(true);
        }

        //按下H鈕扣血
        if (Input.GetKeyDown(KeyCode.H))
        {
            //接受傷害
            currentHealth = currentHealth - 80;
        }

        //將綠色血條同步到當前血量長度
        HealthBar.sizeDelta = new Vector2(mon.currHp, HealthBar.sizeDelta.y);

        //呈現傷害量
        if (Hurt.sizeDelta.x > HealthBar.sizeDelta.x)
        {
            //讓傷害量(紅色血條)逐漸追上當前血量
            Hurt.sizeDelta += new Vector2(-10, 0) * Time.deltaTime * 10;
        }
        if (Hurt.sizeDelta.x <= 0)
        {
            MonBar.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("Deeeee");
            Destroy(gameObject);
        }
    }
}
