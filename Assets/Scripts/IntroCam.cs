using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCam : MonoBehaviour
{

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(target.transform.position - transform.position), 0.3f);

        if (Input.GetKeyDown(KeyCode.S))
        {
            CamMove();
        }
    }

    void CamMove()
    {
        this.gameObject.transform.parent = null;
    }
}