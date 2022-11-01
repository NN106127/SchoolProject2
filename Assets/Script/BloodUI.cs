using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodUI : MonoBehaviour
{
    public float MaxHp = 100;
    public float Hp = 0;
    //public Transform SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localPosition = new Vector3(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.localPosition = new Vector3((-505 + 505 * (Hp / MaxHp)), 0.0f, 0.0f);
    }
}
