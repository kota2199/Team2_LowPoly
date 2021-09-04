using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{

    public Text hpText;

    private int hp;

    private bool punch;

    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
        hpText.text = "HP" + hp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "HP" + hp.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyPunchArea")
        {
            punch = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "EnemyPunchArea")
        {
            punch = false;
        }
        if (other.gameObject.tag == "Recovery")
        {
            if (hp >= 9)
            {
                hp = 10;
            }else
            {
                hp += 2;
            }
        }
    }

    public void ArrowDamaged_Lv1()
    {
        hp -= 5;
    }

    public void PunchDamaged_Lv1()
    {
        if (punch)
        {
            hp -= 3;
        }
    }
    public void ArrowDamaged_Lv2()
    {
        hp -= 6;
    }

    public void PunchDamaged_Lv2()
    {
        if (punch)
        {
            hp -= 4;
        }
    }
}