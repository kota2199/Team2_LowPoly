using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateHold : MonoBehaviour
{

    [HideInInspector]
    public int bombs_s, myLv, myExp, weapon2_s, weapon3_s, hp, maxhp, boots;

    // Start is called before the first frame update
    void Start()
    {
        myLv = PlayerPrefs.GetInt("lv");
        myExp = PlayerPrefs.GetInt("exp");
        bombs_s = PlayerPrefs.GetInt("bombs");
        weapon2_s = PlayerPrefs.GetInt("we2");
        weapon3_s = PlayerPrefs.GetInt("we3");
        hp = PlayerPrefs.GetInt("myhp");
        maxhp = PlayerPrefs.GetInt("mymaxhp");
        boots = PlayerPrefs.GetInt("bootsnum");
        Debug.Log(boots);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Backspace))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            Debug.Log("DELETE");
        }
    }

    public void SaveLv()
    {
        PlayerPrefs.SetInt("lv", myLv);
        PlayerPrefs.Save();
    }

    public void SaveExp()
    {
        PlayerPrefs.SetInt("exp", myExp);
        PlayerPrefs.Save();
    }

    public void SaveBombs()
    {
        PlayerPrefs.SetInt("bombs", bombs_s);
        PlayerPrefs.Save();
    }

    public void AbleWea2()
    {
        PlayerPrefs.SetInt("we2",weapon2_s);
        PlayerPrefs.Save();
    }

    public void AbleWea3()
    {
        PlayerPrefs.SetInt("we3", weapon3_s);
        PlayerPrefs.Save();
    }

    public void Boot()
    {
        boots++;
        PlayerPrefs.SetInt("bootsnum", boots);
        PlayerPrefs.Save();
    }

    public void HPSave()
    {
        PlayerPrefs.SetInt("myhp", hp);
        PlayerPrefs.Save();
    }

    public void MaxHPSave()
    {
        PlayerPrefs.SetInt("mymaxhp", maxhp);
        PlayerPrefs.Save();
    }
}
