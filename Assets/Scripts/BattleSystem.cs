using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleSystem : MonoBehaviour
{

    public Text hpText;

    public Slider hpSlider;

    private int hp;

    private bool punch;

    [SerializeField]
    private int maxHP;

    public bool isDeath = false;

    [SerializeField]
    AudioSource audioSource_battle;

    [SerializeField]
    AudioClip damaged, die;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("lv") == 0)
        {
            maxHP = 10;
        }
        if (PlayerPrefs.GetInt("lv") == 1)
        {
            maxHP = 13;
        }
        if (PlayerPrefs.GetInt("lv") == 2)
        {
            maxHP = 16;
        }
        if (PlayerPrefs.GetInt("lv") == 3)
        {
            maxHP = 19;
        }
        if (PlayerPrefs.GetInt("lv") == 4)
        {
            maxHP = 23;
        }
        if (PlayerPrefs.GetInt("lv") == 5)
        {
            maxHP = 27;
        }
        if (PlayerPrefs.GetInt("lv") == 6)
        {
            maxHP = 32;
        }
        if (PlayerPrefs.GetInt("lv") == 7)
        {
            maxHP = 36;
        }
        if (PlayerPrefs.GetInt("lv") == 8)
        {
            maxHP = 40;
        }
        if (PlayerPrefs.GetInt("lv") == 9)
        {
            maxHP = 45;
        }
        if (PlayerPrefs.GetInt("lv") == 10)
        {
            maxHP = 50;
        }
        hp = maxHP;
        hpText.text = "HP:" + hp.ToString() + "/" + maxHP.ToString();
        hpSlider.maxValue = maxHP;
        hpSlider.value = hp;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "HP" + hp.ToString();
        hpSlider.value = hp;
        hpSlider.maxValue = maxHP;

        if(hp <= 0)
        {
            hp = 0;
            if (!isDeath)
            {

                GetComponent<SaveSystem>().ResetParts();
                animator.SetBool("Die", true);
                Invoke("daeth", 3);
                audioSource_battle.PlayOneShot(die);
                isDeath = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyPunchArea")
        {
            punch = true;
        }
        //敵のパンチ有効範囲に入ったらパンチを受けるBoolをTrueにする
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "EnemyPunchArea")
        {
            punch = false;
        }
        if (other.gameObject.tag == "Recovery")
        {
            if (hp >= maxHP - 1)
            {
                hp = maxHP;
            }else
            {
                hp += 2;
                SaveHP();
            }
            Destroy(other.gameObject);
        }
    }

    public void ArrowDamaged_Lv1()
    {
        hp -= 5;
        audioSource_battle.PlayOneShot(damaged);
        animator.SetTrigger("damage");
        SaveHP();
    }

    public void PunchDamaged_Lv1()
    {
        if (punch)
        {
            hp -= 3;
            audioSource_battle.PlayOneShot(damaged);
            animator.SetTrigger("damage");
            SaveHP();
        }
    }
    public void ArrowDamaged_Lv2()
    {
        hp -= 6;
        audioSource_battle.PlayOneShot(damaged);
        animator.SetTrigger("damage");
        SaveHP();
    }

    public void PunchDamaged_Lv2()
    {
        if (punch)
        {
            hp -= 4;
            audioSource_battle.PlayOneShot(damaged);
            animator.SetTrigger("damage");
            SaveHP();
        }
    }

    public void PunchDamaged_Lv3()
    {
        if (punch)
        {
            hp -= 6;
            audioSource_battle.PlayOneShot(damaged);
            animator.SetTrigger("damage");
            SaveHP();
        }
    }
    public void ArrowDamaged_Lv3()
    {
        hp -= 10;
        audioSource_battle.PlayOneShot(damaged);
        animator.SetTrigger("damage");
        SaveHP();
    }

    public void LastBossAttack()
    {
        hp -= 30;
        audioSource_battle.PlayOneShot(damaged);
        animator.SetTrigger("damage");
        SaveHP();
    }

    //敵側のEnemyBattle.cs内で指定したインターバルごとに関数が呼び出されてダメージを受ける

    void SaveHP()
    {
        GameObject.Find("DetaSaver").GetComponent<DateHold>().hp = hp;
        GameObject.Find("DetaSaver").GetComponent<DateHold>().HPSave();
    }

    void daeth()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}