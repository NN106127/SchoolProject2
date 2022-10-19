using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera2d : MonoBehaviour
{
    //摄像机于要跟随物体的距离
    Vector3 Dir;
    //要跟随的物体
    public GameObject m_Player;
    // Start is called before the first frame update
    void Start()
    {
        //获取到摄像机于要跟随物体之间的距离
        Dir = m_Player.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //摄像机的位置
        transform.position = m_Player.transform.position - Dir;
    }

}
