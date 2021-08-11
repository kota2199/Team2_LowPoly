using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyBattle : MonoBehaviour
{

    private bool fightning;

    // Start is called before the first frame update
    void Start()
    {
        fightning = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FightStart()
    {
        Debug.Log("start");
        fightning = true;
    }

    public void FightEnd()
    {
        Debug.Log("end");
        fightning = false;
    }
}
