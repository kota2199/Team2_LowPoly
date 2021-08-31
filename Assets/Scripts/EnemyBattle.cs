using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBattle : MonoBehaviour
{

    private bool fightning;

    private GameObject target;

    [SerializeField]
    private bool arrow_m, punch_m, sword_m, bodyBrow_m;

    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject arrow;

    private int hp;

    [HideInInspector]
    public int damagedHp;

    [SerializeField]
    private GameObject damagedHpText_go;

    [SerializeField]
    private Text damagedHpText;


    [SerializeField]
    private int raunchInterval;

    [SerializeField]
    private int punchInterval;

    public int lv;

    // Start is called before the first frame update
    void Start()
    {
        fightning = false;
        hp = 10;
        damagedHp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (fightning)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(target.transform.position - transform.position), 0.3f);
            transform.localPosition += transform.forward * speed;
        }
        if (hp <= 0)
        {
            GameObject player = GameObject.Find("Player");
            if (lv == 1)
            {
                player.GetComponent<PayerLeveling>().AddExp_Lv1();
            } else if (lv == 2)
            {
                player.GetComponent<PayerLeveling>().AddExp_Lv2();
            }
            else if (lv == 3)
            {
                player.GetComponent<PayerLeveling>().AddExp_Lv3();
            }
            Destroy(this.gameObject);
        }
    }

    public void PunchDamaged()
    {
        hp -= damagedHp;
        damagedHpText_go.SetActive(true);
        damagedHpText.text = damagedHp.ToString();
        Invoke("DamagedHPFalse",2);
    }

    public void GunDamaged()
    {
        hp -= damagedHp;
        damagedHpText_go.SetActive(true);
        damagedHpText.text = damagedHp.ToString();
        Invoke("DamagedHPFalse", 2);
    }

    void DamagedHPFalse()
    {
        damagedHpText_go.SetActive(false);
        damagedHp = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sercher")
        {
            fightning = true;
            target = other.gameObject;
            StartCoroutine("Attack");
        }
        if (other.gameObject.tag == "PunchArea")
        {
            StartCoroutine("PunchStart");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Sercher")
        {
            fightning = false;
            target = null;
            StopCoroutine("Attack");
        }
        if (other.gameObject.tag == "PunchArea")
        {
            StopCoroutine("PunchStart");
        }
    }

    private IEnumerator Attack()
    {
        yield return null;
        if (arrow_m)
        {
            while (true)
            {
                yield return new WaitForSeconds(raunchInterval);
                GameObject arrow_g = Instantiate(arrow, transform.position, Quaternion.identity);
                arrow_g.GetComponent<BulletSystem>().mother = this.gameObject;
            }
        }
    }

    private IEnumerator PunchStart()
    {
        yield return null;
        if (punch_m)
        {
            yield return new WaitForSeconds(punchInterval);
            if (lv == 1)
            {
                GameObject.Find("Player").GetComponent<BattleSystem>().PunchDamaged_Lv1();
            }
            if (lv >= 2)
            {
                GameObject.Find("Player").GetComponent<BattleSystem>().PunchDamaged_Lv2();
            }
        }
    }
}
