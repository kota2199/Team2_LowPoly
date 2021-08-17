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
    }

    public void ArrowDamaged()
    {
        hp -= 1;
    }

    public void PunchDamaged()
    {
        if (punch)
        {
            hp -= 2;
        }
    }
}