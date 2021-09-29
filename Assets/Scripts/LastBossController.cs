using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastBossController : MonoBehaviour
{

    GameObject target;

    bool moving = false;

    Animator animator;

    [SerializeField]
    Slider hpSlider;

    [SerializeField]
    int Hp;

    GameObject attackTarget;

    [SerializeField]
    GameObject dropItem;

    AudioSource audioSource;

    [SerializeField]
    private int itemNum;    //dropItemの配列の番号

    [SerializeField]
    private ItemDataBase itemDataBase;

    [SerializeField]
    bool isItem;

    [SerializeField]
    AudioClip damaged,bauking,attack;

    bool isDeath = false;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            animator.SetBool("move", true);
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(target.transform.position - transform.position), 0.3f);
            transform.localPosition += transform.forward * 0.8f;
        }

        if (Hp <= 0)
        {
            if (!isDeath)
            {
                animator.SetBool("dead", true);
                if (isItem)
                {
                    if (!itemDataBase.GetItemLists()[itemNum].GetStatus())
                    {
                        Instantiate(dropItem, this.transform.position, Quaternion.identity);
                    }
                }
                int deathCount = PlayerPrefs.GetInt("BossCount");
                deathCount++;
                PlayerPrefs.SetInt("BossCount", deathCount);
                isDeath = true;
            }
        }
    }

    public void PunchDamaged()
    {
        Hp -= 10;
    }

    public void SwordDamaged()
    {
        Hp -= 20;
    }

    public void ArrowDamaged()
    {
        Hp -= 25;
    }

    public void FlagDamaged()
    {
        Hp -= 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sercher")
        {
            moving = true;
            attackTarget = GameObject.Find("Player");
            audioSource.PlayOneShot(bauking);
            audioSource.Play();
        }
        if (other.gameObject.tag == "PunchArea")
        {
            StartCoroutine("Attack");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PunchArea")
        {
            StopCoroutine("Attack");
        }
    }

    private IEnumerator Attack()
    {
        yield return null;
        while (true)
        {
            yield return new WaitForSeconds(8);
            attackTarget.GetComponent<BattleSystem>().LastBossAttack();
            Debug.Log("Attack!");
            audioSource.PlayOneShot(attack);
            moving = false;
            animator.SetBool("move", false);
            animator.SetTrigger("attack");
        }
    }
}
