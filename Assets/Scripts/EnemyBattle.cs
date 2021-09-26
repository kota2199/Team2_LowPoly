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

    [SerializeField]
    private GameObject dropItem;

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

    [SerializeField]
    private int itemNum;    //dropItemの配列の番号

    [SerializeField]
    private ItemDataBase itemDataBase;

    [SerializeField]
    int maxHP;

    [SerializeField]
    bool isItem;

    // Start is called before the first frame update
    void Start()
    {
        fightning = false;
        hp = maxHP;
        damagedHp = 0;
        //初期化
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

        //Bool値がTrueなら回転と前進でプレイヤーを追尾

        if (hp <= 0)
        {
            GameObject player = GameObject.Find("Player");

            if (lv == 1)
            {
                int givingExp = 50;

                if (player.GetComponent<PayerLeveling>().myLevel == 1)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv1(givingExp);
                }
                if (player.GetComponent<PayerLeveling>().myLevel == 2)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv2(givingExp);
                }
                if (player.GetComponent<PayerLeveling>().myLevel == 3)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv3(givingExp);
                }
                if (player.GetComponent<PayerLeveling>().myLevel == 4)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv4(givingExp);
                }
                if (player.GetComponent<PayerLeveling>().myLevel == 5)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv5(givingExp);
                }
                if (player.GetComponent<PayerLeveling>().myLevel == 6)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv6(givingExp);
                }
                if (player.GetComponent<PayerLeveling>().myLevel == 7)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv7(givingExp);
                }
                if (player.GetComponent<PayerLeveling>().myLevel == 8)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv8(givingExp);
                }
                if (player.GetComponent<PayerLeveling>().myLevel == 9)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv9(givingExp);
                }

            } else if (lv == 2)
            {
                int givingExp = 100;

                if (player.GetComponent<PayerLeveling>().myLevel == 1)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv1(givingExp);
                }
                if (player.GetComponent<PayerLeveling>().myLevel == 2)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv2(givingExp);
                }
                if (player.GetComponent<PayerLeveling>().myLevel == 3)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv3(givingExp);
                }
                if (player.GetComponent<PayerLeveling>().myLevel == 4)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv4(givingExp);
                }
                if (player.GetComponent<PayerLeveling>().myLevel == 5)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv5(givingExp);
                }
                if (player.GetComponent<PayerLeveling>().myLevel == 6)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv6(givingExp);
                }
                if (player.GetComponent<PayerLeveling>().myLevel == 7)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv7(givingExp);
                }
                if (player.GetComponent<PayerLeveling>().myLevel == 8)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv8(givingExp);
                }
                if (player.GetComponent<PayerLeveling>().myLevel == 9)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv9(givingExp);
                }
            }

            else if (lv == 3)
            {

                int givingExp = 150;

                if (player.GetComponent<PayerLeveling>().myLevel == 1)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv1(givingExp);
                }
                if (player.GetComponent<PayerLeveling>().myLevel == 2)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv2(givingExp);
                }
                if (player.GetComponent<PayerLeveling>().myLevel == 3)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv3(givingExp);
                }
                if (player.GetComponent<PayerLeveling>().myLevel == 4)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv4(givingExp);
                }
                if (player.GetComponent<PayerLeveling>().myLevel == 5)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv5(givingExp);
                }
                if (player.GetComponent<PayerLeveling>().myLevel == 6)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv6(givingExp);
                }
                if (player.GetComponent<PayerLeveling>().myLevel == 7)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv7(givingExp);
                }
                if (player.GetComponent<PayerLeveling>().myLevel == 8)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv8(givingExp);
                }
                if (player.GetComponent<PayerLeveling>().myLevel == 9)
                {
                    player.GetComponent<PayerLeveling>().AddExp_Lv9(givingExp);
                }
            }
            if (isItem)
            {
                if (!itemDataBase.GetItemLists()[itemNum].GetStatus())
                {
                    Instantiate(dropItem, this.transform.position, Quaternion.identity);
                }
            } else if (!isItem)
            {
                Instantiate(dropItem, this.transform.position, Quaternion.identity);
            }

            if (GameObject.Find("DetaSaver").GetComponent<DateHold>().boots <= 0)
            {
                GetComponent<ReturnTutorial>().ToTutorial();
            }

            Destroy(this.gameObject);

            //もしHPが0を下回った際、レベルに応じて得られるExpを変えて付与
        }
    }

    public void PunchDamaged()
    {
        hp -= damagedHp;
        damagedHpText_go.SetActive(true);
        damagedHpText.text = damagedHp.ToString();
        Invoke("DamagedHPFalse",2);

        //この敵がパンチを受けたら、HPから減算し、受けたダメージをTextに表示。2秒後に消す関数を実行
    }

    public void GunDamaged()
    {
        hp -= damagedHp;
        damagedHpText_go.SetActive(true);
        damagedHpText.text = damagedHp.ToString();
        Invoke("DamagedHPFalse", 2);

        //この敵が銃によるダメージを受けたら、HPから減算し、受けたダメージをTextに表示。2秒後に消す関数を実行
    }

    void DamagedHPFalse()
    {
        damagedHpText_go.SetActive(false);
        damagedHp = 0;

        //受けたダメージのTextを消す
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sercher")
        {
            fightning = true;
            target = other.gameObject;
            StartCoroutine("Attack");

            //プレイヤーの子であるColliderに接触すると戦闘が始まる。
        }
        if (other.gameObject.tag == "PunchArea")
        {
            StartCoroutine("PunchStart");

            //プレイヤーの子であるColliderに接触するとパンチが始まる。
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

        //プレイヤーの子であるColliderから離脱すると戦闘モード終了
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

        //もしarrowがTrueなら、指定したインターバルごとに球を発射
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
            if (lv == 2)
            {
                GameObject.Find("Player").GetComponent<BattleSystem>().PunchDamaged_Lv2();
            }
            if (lv == 3)
            {
                GameObject.Find("Player").GetComponent<BattleSystem>().PunchDamaged_Lv1();
            }
        }
        //punch_mがTrueなら、指定したインターバルごとにパンチ関数を実行する。敵のレベルごとに与えるダメージを変える

    }
}
