using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CloudFollow : MonoBehaviour
{
    public Transform Target;
    public float dist = 5f;
    public float height = 5.0f;
    public float dampTrace = 10.0f;
    public Transform Cloud;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cloud.position = Vector3.Lerp(Cloud.position, Target.position - (Target.forward * dist) + (Vector3.up * height), Time.deltaTime * dampTrace);
    }
}
