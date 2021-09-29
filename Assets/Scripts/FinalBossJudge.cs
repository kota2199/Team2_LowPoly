using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossJudge : MonoBehaviour
{

    [SerializeField]
    GameObject FinalBoss;

    [SerializeField]
    GameObject toEnd;

    int FinalBossCount;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("FinalBossCount") == 1)
        {
            FinalBoss.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("FinalBossCount") == 2)
        {
            toEnd.SetActive(true);
        }
    }
}
