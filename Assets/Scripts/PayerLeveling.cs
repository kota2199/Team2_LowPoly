using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PayerLeveling : MonoBehaviour
{

    public int myLevel;

    private int myExp;

    public Text levelText, expText;

    public Slider expSlider;

    // Start is called before the first frame update
    void Start()
    {
        myLevel = 1;
        myExp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Lv." + myLevel.ToString();
        expText.text = "Exp:" + myExp.ToString() + "/500";
        expSlider.value = myExp;
    }
    public void AddExp_Lv1()
    {
        myExp += 50;
        if (myExp >= 1000)
        {
            myLevel++;
            myExp = 0;
        }
    }
    public void AddExp_Lv2()
    {
        myExp += 100;
        if (myExp >= 1200)
        {
            myLevel++;
            myExp = 0;
        }
    }
    public void AddExp_Lv3()
    {
        myExp += 150;
        if (myExp >= 1400)
        {
            myLevel++;
            myExp = 0;
        }
    }
}
