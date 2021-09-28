using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletSystem : MonoBehaviour
{

    public GameObject mother;

    // Start is called before the first frame update
    void Start()
    {
        GameObject cam = GameObject.Find("Main Camera");
        GetComponent<Rigidbody>().AddForce(cam.transform.forward * 100, ForceMode.Impulse);
        Invoke("AutoDestroy", 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (mother.GetComponent<PayerLeveling>().myLevel == 0)
            {
                other.GetComponent<EnemyBattle>().damagedHp = 5;
            }
            if (mother.GetComponent<PayerLeveling>().myLevel == 1)
            {
                other.GetComponent<EnemyBattle>().damagedHp = 7;
            }
            if (mother.GetComponent<PayerLeveling>().myLevel == 2)
            {
                other.GetComponent<EnemyBattle>().damagedHp = 9;
            }
            if (mother.GetComponent<PayerLeveling>().myLevel == 3)
            {
                other.GetComponent<EnemyBattle>().damagedHp = 11;
            }
            if (mother.GetComponent<PayerLeveling>().myLevel == 4)
            {
                other.GetComponent<EnemyBattle>().damagedHp = 14;
            }
            if (mother.GetComponent<PayerLeveling>().myLevel == 5)
            {
                other.GetComponent<EnemyBattle>().damagedHp = 18;
            }
            if (mother.GetComponent<PayerLeveling>().myLevel == 6)
            {
                other.GetComponent<EnemyBattle>().damagedHp = 22;
            }
            if (mother.GetComponent<PayerLeveling>().myLevel == 7)
            {
                other.GetComponent<EnemyBattle>().damagedHp = 27;
            }
            if (mother.GetComponent<PayerLeveling>().myLevel == 8)
            {
                other.GetComponent<EnemyBattle>().damagedHp = 32;
            }
            if (mother.GetComponent<PayerLeveling>().myLevel == 9)
            {
                other.GetComponent<EnemyBattle>().damagedHp = 38;
            }

            if (mother.GetComponent<PayerLeveling>().myLevel == 10)
            {
                other.GetComponent<EnemyBattle>().damagedHp = 40;
            }
            other.GetComponent<EnemyBattle>().GunDamaged();
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "LastBoss")
        {
            other.gameObject.GetComponent<LastBossController>().ArrowDamaged();
        }
    }
    void AutoDestroy()
    {
        Destroy(this.gameObject);
    }
}
