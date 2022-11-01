using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject TargetPlayer;
    public GameObject posionA;
    public GameObject posionB;
    public float distance;
    public float TraceRadius;  //°l³v¶ZÂ÷
    public float TurnSpeed;
    public string status  = "patrol";
    public float BossSkillTimer = 0;


    public GameObject m_rockPrefab;
    public Transform m_rightHandTransform;

    // Start is called before the first frame update
    void Start()
    {
        posionA.SetActive(false);
        posionB.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, TargetPlayer.transform.position);
        if (distance < 15)
        {
            LookPlayer();
            status = "ATK";
        }

        if (status == "ATK")
        {
            BossSkillTimer += Time.deltaTime;
            if(BossSkillTimer >= 3 )
            {
                RockThrow();
                BossSkillTimer = 0;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, TraceRadius);
    }


    void LookPlayer()
    {
        float dist = Vector3.Distance(transform.position, TargetPlayer.transform.position);
        if (dist < TraceRadius)
        {
            //º¥º¥¬Ý¦Vª±®a
            Vector3 relativePos = TargetPlayer.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(relativePos);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, TurnSpeed * Time.deltaTime);
            Vector3 dir = (TargetPlayer.transform.position - transform.position).normalized;
        }
    }

    void RockThrow()
    {
        GameObject rock = Instantiate(m_rockPrefab, m_rightHandTransform.position, Quaternion.identity);
    }
}
