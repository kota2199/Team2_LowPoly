using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField]
    private bool punch_m, gun_m;

    private bool targetOn;

    private GameObject targetObj;

    [SerializeField]
    private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        targetOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (punch_m)
            {
                if (targetOn)
                {
                    PunchAtttack();
                }
            }
            if (gun_m)
            {
                GameObject bullet_g = Instantiate(bullet, transform.position, Quaternion.identity);
                bullet_g.GetComponent<PlayerBulletSystem>().mother = this.gameObject;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            punch_m = true;
            gun_m = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            punch_m = false;
            gun_m = true;
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
