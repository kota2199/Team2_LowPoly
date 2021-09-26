using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManage : MonoBehaviour
{

    [SerializeField]
    GameObject menu;

    bool ismenu = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !ismenu)
        {
            ismenu = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && ismenu)
        {
            ismenu = false;
        }

        if (ismenu)
        {
            menu.SetActive(true);
        }
        else
        {
            menu.SetActive(false);
        }
    }
}
