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

    private bool isDeath = false;

    AudioSource audioSource;

    [SerializeField]
    AudioClip damaged;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
        hpText.text = "HP:" + hp.ToString() + "/" + maxHP.ToString();
        hpSlider.maxValue = maxHP;
        hpSlider.value = hp;
        audioSource = GetComponent<AudioSource>();
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
            if (!isDeath)
            {

                GetComponent<SaveSystem>().ResetParts();
                animator.SetBool("Die", true);
                Invoke("daeth", 3);
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
        audioSource.PlayOneShot(damaged);
        animator.SetTrigger("damage");
        SaveHP();
    }

    public void PunchDamaged_Lv1()
    {
        if (punch)
        {
            hp -= 3;
            audioSource.PlayOneShot(damaged);
            animator.SetTrigger("damage");
            SaveHP();
        }
    }
    public void ArrowDamaged_Lv2()
    {
        hp -= 6;
        audioSource.PlayOneShot(damaged);
        animator.SetTrigger("damage");
        SaveHP();
    }

    public void PunchDamaged_Lv2()
    {
        if (punch)
        {
            hp -= 4;
            audioSource.PlayOneShot(damaged);
            animator.SetTrigger("damage");
            SaveHP();
        }
    }

    public void PunchDamaged_Lv3()
    {
        if (punch)
        {
            hp -= 6;
            audioSource.PlayOneShot(damaged);
            animator.SetTrigger("damage");
            SaveHP();
        }
    }
    public void ArrowDamaged_Lv3()
    {
        hp -= 10;
        audioSource.PlayOneShot(damaged);
        animator.SetTrigger("damage");
        SaveHP();
    }

    //敵側のEnemyBattle.cs内で指定したインターバルごとに関数が呼び出されてダメージを受ける

    void SaveHP()
    {
        GameObject.Find("DetaSaver").GetComponent<DateHold>().hp = hp;
        GameObject.Find("DetaSaver").GetComponent<DateHold>().HPSave();
    }

    void death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}