using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollow : MonoBehaviour
{
    public Enmey mon;
    public GameObject MonBar;

    //��q�]�w
    public const int maxHealth = 350;  //�Ǫ���q�`�q
    public int currentHealth = maxHealth; // maxHealth = LifePoint

    //��q��
    public RectTransform HealthBar, Hurt;

    //������H
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

        //���UH�s����
        if (Input.GetKeyDown(KeyCode.H))
        {
            //�����ˮ`
            currentHealth = currentHealth - 80;
        }

        //�N������P�B���e��q����
        HealthBar.sizeDelta = new Vector2(mon.currHp, HealthBar.sizeDelta.y);

        //�e�{�ˮ`�q
        if (Hurt.sizeDelta.x > HealthBar.sizeDelta.x)
        {
            //���ˮ`�q(������)�v���l�W��e��q
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
