using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossJudge : MonoBehaviour
{

    [SerializeField]
    GameObject FinalBoss;

    int FinalBossCount;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("FinalBossCount")>0)
        {
            FinalBoss.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
