using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PayerLeveling : MonoBehaviour
{

    public int myLevel;

    private int myExp, maxExp;

    public Text levelText, expText;

    public Slider expSlider;

    GameObject detaSaver;

    // Start is called before the first frame update
    void Start()
    {
        myLevel = PlayerPrefs.GetInt("lv");
        myExp = PlayerPrefs.GetInt("exp");
        detaSaver = GameObject.Find("DetaSaver");
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Lv." + myLevel.ToString();
        expText.text = "Exp:" + myExp.ToString() + "/" + maxExp.ToString();
        expSlider.value = myExp;
        expSlider.maxValue = maxExp;

        if (myLevel == 0)
        {
            maxExp = 500;
        }
        if (myLevel == 1)
        {
            maxExp = 1000;
        }
        if (myLevel == 2)
        {
            maxExp = 1200;
        }
        if (myLevel == 3)
        {
            maxExp = 1400;
        }
        if (myLevel == 4)
        {
            maxExp = 1500;
        }
        if (myLevel == 5)
        {
            maxExp = 1600;
        }
        if (myLevel == 6)
        {
            maxExp = 1700;
        }
        if (myLevel == 7)
        {
            maxExp = 1800;
        }
        if (myLevel == 8)
        {
            maxExp = 1900;
        }
        if (myLevel == 9)
        {
            maxExp = 2000;
        }
        if (myLevel == 10)
        {
            myExp = maxExp;
            maxExp = 2000;
        }
    }

    public void AddExp_Lv0(int givenExp)
    {
        myExp += 50 + givenExp;
        if (myExp >= 500)
        {
            myLevel++;
            myExp = 0;
        }
    }

    public void AddExp_Lv1(int givenExp)
    {
        myExp += 50 + givenExp;
        if (myExp >= 1000)
        {
            myLevel++;
            myExp = 0;
        }
    }

    public void AddExp_Lv2(int givenExp)
    {
        myExp += 80 + givenExp;
        if (myExp >= 1200)
        {
            myLevel++;
            myExp = 0;
        }
    }
    public void AddExp_Lv3(int givenExp)
    {
        myExp += 120 + givenExp;
        if (myExp >= 1400)
        {
            myLevel++;
            myExp = 0;
        }
    }
    public void AddExp_Lv4(int givenExp)
    {
        myExp += 160 + givenExp;
        if (myExp >= 1500)
        {
            myLevel++;
            myExp = 0;
        }
    }
    public void AddExp_Lv5(int givenExp)
    {
        myExp += 200 + givenExp;
        if (myExp >= 1600)
        {
            myLevel++;
            myExp = 0;
        }
    }
    public void AddExp_Lv6(int givenExp)
    {
        myExp += 230 + givenExp;
        if (myExp >= 1700)
        {
            myLevel++;
            myExp = 0;
        }
    }
    public void AddExp_Lv7(int givenExp)
    {
        myExp += 260 + givenExp;
        if (myExp >= 1800)
        {
            myLevel++;
            myExp = 0;
        }
    }
    public void AddExp_Lv8(int givenExp)
    {
        myExp += 290 + givenExp;
        if (myExp >= 1900)
        {
            myLevel++;
            myExp = 0;
        }
    }
    public void AddExp_Lv9(int givenExp)
    {
        myExp += 320 + givenExp;
        if (myExp >= 2000)
        {
            myLevel++;
        }
    }

    public void SaveExpLv()
    {
        detaSaver.GetComponent<DateHold>().myExp = myExp;
        detaSaver.GetComponent<DateHold>().myLv = myLevel;
        detaSaver.GetComponent<DateHold>().SaveLv();
        detaSaver.GetComponent<DateHold>().SaveExp();
    }
}
