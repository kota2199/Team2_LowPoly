using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField]
    private bool punch_m, gun_m;

    private bool targetOn;

    private GameObject targetObj;

    // Start is called before the first frame update
    void Start()
    {
        targetOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (punch_m)
            {
                if (targetOn)
                {
                    PunchAtttack();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            targetObj = other.gameObject;
            targetOn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            targetObj = null;
            targetOn = false;
        }
    }

    void PunchAtttack()
    {
        targetObj.GetComponent<EnemyBattle>().PunchDamaged();
    }
}
