using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGet : MonoBehaviour
{

    public int bombs;

    public bool bomb, weapon2, weapon3;

    GameObject dateSaver;

    // Start is called before the first frame update
    void Start()
    {
        dateSaver = GameObject.Find("DetaSaver");
        bombs = dateSaver.GetComponent<DateHold>().bombs_s;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (dateSaver.GetComponent<DateHold>().weapon2_s >= 1)
        {
            weapon2 = true;
        }
        else
        {
            weapon2 = false;
        }
        if (dateSaver.GetComponent<DateHold>().weapon3_s >= 1)
        {
            weapon3 = true;
        }
        else
        {
            weapon3 = false;
        }
        if (other.gameObject.tag == "ArrowItem")
        {
            weapon2 = true;
            dateSaver.GetComponent<DateHold>().weapon2_s = 1;
            dateSaver.GetComponent<DateHold>().AbleWea2();
        }
        if (other.gameObject.tag == "GunItem")
        {
            weapon3 = true;
            dateSaver.GetComponent<DateHold>().weapon3_s = 1;
            dateSaver.GetComponent<DateHold>().AbleWea3();
        }
        if (other.gameObject.tag == "BombItem")
        {
            bombs++;
            dateSaver.GetComponent<DateHold>().bombs_s = bombs;
            dateSaver.GetComponent<DateHold>().SaveBombs();
        }
    }
}
