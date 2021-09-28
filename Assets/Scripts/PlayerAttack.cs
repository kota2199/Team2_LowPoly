using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField]
    private bool punch_m, sword_m, gun_m, bomb_m;

    public bool targetOn;

    public GameObject targetObj;

    [SerializeField]
    private GameObject bullet;

    private bool gunInterval;

    Animator animator;

    [SerializeField]
    AudioSource audioSource_attack;

    [SerializeField]
    AudioClip punch_s,sword_s, gun_s, bomb_s;

    [SerializeField]
    GameObject sword_o, gun_o;

    [SerializeField]
    GameObject launchPoint;

    // Start is called before the first frame update
    void Start()
    {
        punch_m = true;
        gun_m = false;
        targetOn = false;
        gunInterval = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!GameObject.Find("Manager").GetComponent<MenuManage>().ismenu)
            {
                if (punch_m)
                {
                    PunchSound();
                    StartCoroutine("PunchInterval");
                    animator.SetTrigger("punch");
                    punch_m = false;
                    if (targetOn)
                    {
                        PunchAtttack();
                    }
                }

                if (sword_m)
                {
                    SwordSound();
                    StartCoroutine("SowrdInterval");
                    sword_m = false;
                    animator.SetTrigger("sword");
                    if (targetOn)
                    {
                        SwordAttack();
                    }
                }

                if (gun_m && gunInterval == true)
                {
                    GameObject bullet_g = Instantiate(bullet, launchPoint.transform.position, Quaternion.identity);
                    bullet_g.GetComponent<PlayerBulletSystem>().mother = this.gameObject;
                    gunInterval = false;
                    StartCoroutine("Interval");
                    animator.SetTrigger("punch");
                }
                if (bomb_m)
                {
                    audioSource_attack.PlayOneShot(bomb_s);
                    GetComponent<WeaponGet>().bombs--;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            punch_m = true;
            sword_m = false;
            gun_m = false;
            bomb_m = false;
            gun_o.SetActive(false);
            sword_o.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (GetComponent<WeaponGet>().weapon2)
            {
                Debug.Log("seordmode");
                punch_m = false;
                sword_m = true;
                gun_m = false;
                bomb_m = false;
                gun_o.SetActive(false);
                sword_o.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (GetComponent<WeaponGet>().weapon3)
            {
                punch_m = false;
                sword_m = false;
                gun_m = true;
                bomb_m = false;
                gun_o.SetActive(true);
                sword_o.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(GetComponent<WeaponGet>().bombs > 0)
            {
                punch_m = false;
                sword_m = false;
                gun_m = false;
                bomb_m = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy"|| other.gameObject.tag == "LastBoss")
        {
            targetObj = other.gameObject;
            Debug.Log(other.gameObject.name);
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
        if (targetObj.gameObject.tag == "LastBoss")
        {
            targetObj.GetComponent<LastBossController>().SwordDamaged();
        }
        else
        {
            if (GetComponent<PayerLeveling>().myLevel == 0)
            {
                targetObj.GetComponent<EnemyBattle>().damagedHp = 2;
            }
            if (GetComponent<PayerLeveling>().myLevel == 1)
            {
                targetObj.GetComponent<EnemyBattle>().damagedHp = 3;
            }
            if (GetComponent<PayerLeveling>().myLevel == 2)
            {
                targetObj.GetComponent<EnemyBattle>().damagedHp = 4;
            }
            if (GetComponent<PayerLeveling>().myLevel == 3)
            {
                targetObj.GetComponent<EnemyBattle>().damagedHp = 6;
            }
            if (GetComponent<PayerLeveling>().myLevel == 4)
            {
                targetObj.GetComponent<EnemyBattle>().damagedHp = 8;
            }
            if (GetComponent<PayerLeveling>().myLevel == 5)
            {
                targetObj.GetComponent<EnemyBattle>().damagedHp = 13;
            }
            if (GetComponent<PayerLeveling>().myLevel == 6)
            {
                targetObj.GetComponent<EnemyBattle>().damagedHp = 15;
            }
            if (GetComponent<PayerLeveling>().myLevel == 7)
            {
                targetObj.GetComponent<EnemyBattle>().damagedHp = 18;
            }
            if (GetComponent<PayerLeveling>().myLevel == 8)
            {
                targetObj.GetComponent<EnemyBattle>().damagedHp = 21;
            }
            if (GetComponent<PayerLeveling>().myLevel == 9)
            {
                targetObj.GetComponent<EnemyBattle>().damagedHp = 23;
            }
            if (GetComponent<PayerLeveling>().myLevel == 10)
            {
                targetObj.GetComponent<EnemyBattle>().damagedHp = 27;
            }
            targetObj.GetComponent<EnemyBattle>().PunchDamaged();

            //プレイヤーのレベルに応じて与えるダメージを変えて付与
        }
    }

    void SwordAttack()
    {
        if (targetObj.gameObject.tag == "LastBoss")
        {
            targetObj.GetComponent<LastBossController>().PunchDamaged();
        }
        else
        {
            if (GetComponent<PayerLeveling>().myLevel == 0)
            {
                targetObj.GetComponent<EnemyBattle>().damagedHp = 4;
            }
            if (GetComponent<PayerLeveling>().myLevel == 1)
            {
                targetObj.GetComponent<EnemyBattle>().damagedHp = 6;
            }
            if (GetComponent<PayerLeveling>().myLevel == 2)
            {
                targetObj.GetComponent<EnemyBattle>().damagedHp = 8;
            }
            if (GetComponent<PayerLeveling>().myLevel == 3)
            {
                targetObj.GetComponent<EnemyBattle>().damagedHp = 10;
            }
            if (GetComponent<PayerLeveling>().myLevel == 4)
            {
                targetObj.GetComponent<EnemyBattle>().damagedHp = 12;
            }
            if (GetComponent<PayerLeveling>().myLevel == 5)
            {
                targetObj.GetComponent<EnemyBattle>().damagedHp = 15;
            }
            if (GetComponent<PayerLeveling>().myLevel == 6)
            {
                targetObj.GetComponent<EnemyBattle>().damagedHp = 18;
            }
            if (GetComponent<PayerLeveling>().myLevel == 7)
            {
                targetObj.GetComponent<EnemyBattle>().damagedHp = 21;
            }
            if (GetComponent<PayerLeveling>().myLevel == 8)
            {
                targetObj.GetComponent<EnemyBattle>().damagedHp = 24;
            }
            if (GetComponent<PayerLeveling>().myLevel == 9)
            {
                targetObj.GetComponent<EnemyBattle>().damagedHp = 29;
            }
            if (GetComponent<PayerLeveling>().myLevel == 10)
            {
                targetObj.GetComponent<EnemyBattle>().damagedHp = 34;
            }
            targetObj.GetComponent<EnemyBattle>().SwordDamaged();
        }
        }

    private IEnumerator Interval()
    {
        yield return new WaitForSeconds(3);
        gunInterval = true;
    }

    private IEnumerator PunchInterval()
    {
        yield return new WaitForSeconds(3);
        punch_m = true;
    }

    private IEnumerator SowrdInterval()
    {
        yield return new WaitForSeconds(5);
        sword_m = true;
    }

    void PunchSound()
    {
        audioSource_attack.PlayOneShot(punch_s);
    }

    void SwordSound()
    {
        audioSource_attack.PlayOneShot(sword_s);
    }
}
