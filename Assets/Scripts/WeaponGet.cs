using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponGet : MonoBehaviour
{

    public int bombs;

    public bool bomb, weapon2, weapon3;

    int weapon2_i, weapon3_i;

    GameObject dateSaver;

    [SerializeField]
    GameObject messengers;

    [SerializeField]
    Text messageText;

    [SerializeField]
    AudioClip itemGet_s;

    Animator animator;

    [SerializeField]
    AudioSource audioSource_getsound;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        dateSaver = GameObject.Find("DetaSaver");
        weapon2_i = PlayerPrefs.GetInt("we2");
        weapon3_i = PlayerPrefs.GetInt("we3");
        bombs = PlayerPrefs.GetInt("bombs");
        if (weapon2_i < 1)
        {
            weapon2 = false;
        } else
        {
            weapon2 = true;
        }
        if (weapon3_i < 1)
        {
            weapon3 = false;
        }
        else
        {
            weapon3 = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetWeapon2(GameObject item)
    {
        weapon2 = true;
        messengers.SetActive(true);
        messageText.text = "剣を獲得しました！";
        audioSource_getsound.PlayOneShot(itemGet_s);
        Invoke("MessageFalse", 3);
        Destroy(item.gameObject);
    }

    public void GetWeapon3(GameObject item)
    {
        animator.SetTrigger("item");
        weapon3 = true;
        messengers.SetActive(true);
        messageText.text = "銃を獲得しました！";
        audioSource_getsound.PlayOneShot(itemGet_s);
        Invoke("MessageFalse", 3);
        Destroy(item.gameObject);
    }

    public void GetBomb(GameObject item)
    {
        bombs++;
        messengers.SetActive(true);
        messageText.text = "手榴弾を獲得しました！";
        audioSource_getsound.PlayOneShot(itemGet_s);
        Invoke("MessageFalse", 3);
        Destroy(item.gameObject);
    }
    void MessageFalse()
    {
        messengers.SetActive(false);
        messageText.text = ("");
    }

    public void WeaponSave()
    {
        if (weapon2)
        {
            dateSaver.GetComponent<DateHold>().weapon2_s = 1;
            dateSaver.GetComponent<DateHold>().AbleWea2();
        }
        if (weapon3)
        {
            dateSaver.GetComponent<DateHold>().weapon3_s = 1;
            dateSaver.GetComponent<DateHold>().AbleWea3();
        }

        dateSaver.GetComponent<DateHold>().bombs_s = bombs;
        dateSaver.GetComponent<DateHold>().SaveBombs();
    }
}
