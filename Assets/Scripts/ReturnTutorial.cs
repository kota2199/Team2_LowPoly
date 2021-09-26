using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sercher")
        {
            if (GameObject.Find("DetaSaver").GetComponent<DateHold>().boots == 0)
            {
                GameObject.Find("Manager").GetComponent<TutorialManage>().StartCoroutine("BattleTutorial");
            }
        }
    }

    public void ToTutorial()
    {
        GameObject.Find("Manager").GetComponent<TutorialManage>().StartCoroutine("NextTutorial");
    }
}
