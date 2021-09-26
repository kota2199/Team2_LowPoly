using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchTurnOn : MonoBehaviour
{

    [SerializeField]
    GameObject player;

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
        if (other.gameObject.tag == "Enemy")
        {
            player.GetComponent<PlayerAttack>().targetOn = true;
            player.GetComponent<PlayerAttack>().targetObj = other.gameObject;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            player.GetComponent<PlayerAttack>().targetOn = false;
            player.GetComponent<PlayerAttack>().targetObj = null;

        }
    }
}
