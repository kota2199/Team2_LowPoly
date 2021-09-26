using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField]
    private bool punch_m, gun_m, bomb_m;

    public bool targetOn;

    public GameObject targetObj;

    [SerializeField]
    private GameObject bullet;

    private bool gunInterval;

    Animator animator;

    AudioSource audioSource;

    [SerializeField]
    AudioClip punch_s, gun_s, bomb_s;

    // Start is called before the first frame update
    void Start()
    {
        punch_m = true;
        gun_m = false;
        targetOn = false;
        gunInterval = true;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (punch_m)
            {
                Invoke("PunchSound",0.5f);
                StartCoroutine("PunchInterval");
                animator.SetTrigger("punch");
                punch_m = false;
                if (targetOn)
                {
                    audioSource.PlayOneShot(punch_s);
                    PunchAtttack();
                }
            }
            if (gun_m && gunInterval == true)
            {
                GameObject bullet_g = Instantiate(bullet, transform.position, Quaternion.identity);
                bullet_g.GetComponent<PlayerBulletSystem>().mother = this.gameObject;
                gunInterval = false;
                StartCoroutine("Interval");
            }
            if (bomb_m)
            {
                audioSource.PlayOneShot(bomb_s);
                GetComponent<WeaponGet>().bombs--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            punch_m = true;
            gun_m = false;
            bomb_m = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (GetComponent<WeaponGet>().weapon2)
            {
                punch_m = false;
                gun_m = true;
                bomb_m = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(GetComponent<WeaponGet>().bombs > 0)
            {
                punch_m = false;
                gun_m = false;
                bomb_m = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("puncharea");
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
        if (GetComponent<PayerLeveling>().myLevel == 1)
        {
            targetObj.GetComponent<EnemyBattle>().damagedHp = 2;
        }
        if (GetComponent<PayerLeveling>().myLevel == 2)
        {
            targetObj.GetComponent<EnemyBattle>().damagedHp = 3;
        }
        if (GetComponent<PayerLeveling>().myLevel == 3)
        {
            targetObj.GetComponent<EnemyBattle>().damagedHp = 4;
        }
        if (GetComponent<PayerLeveling>().myLevel == 4)
        {
            targetObj.GetComponent<EnemyBattle>().damagedHp = 6;
        }
        if (GetComponent<PayerLeveling>().myLevel == 5)
        {
            targetObj.GetComponent<EnemyBattle>().damagedHp = 8;
        }
        if (GetComponent<PayerLeveling>().myLevel == 6)
        {
            targetObj.GetComponent<EnemyBattle>().damagedHp = 11;
        }
        if (GetComponent<PayerLeveling>().myLevel == 7)
        {
            targetObj.GetComponent<EnemyBattle>().damagedHp = 14;
        }
        if (GetComponent<PayerLeveling>().myLevel == 8)
        {
            targetObj.GetComponent<EnemyBattle>().damagedHp = 18;
        }
        if (GetComponent<PayerLeveling>().myLevel == 9)
        {
            targetObj.GetComponent<EnemyBattle>().damagedHp = 22;
        }
        if (GetComponent<PayerLeveling>().myLevel == 10)
        {
            targetObj.GetComponent<EnemyBattle>().damagedHp = 27;
        }
        targetObj.GetComponent<EnemyBattle>().PunchDamaged();

        //プレイヤーのレベルに応じて与えるダメージを変えて付与
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

    void PunchSound()
    {
        audioSource.PlayOneShot(punch_s);
    }
}
