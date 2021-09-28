using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManage : MonoBehaviour
{

    [SerializeField]
    GameObject menu;

    public bool ismenu = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ismenu)
            {
                ismenu = false;
            }
            else
            {
                ismenu = true;
            }

            if (ismenu)
            {
                menu.SetActive(true);

                Cursor.visible = true;

                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                menu.SetActive(false);

                Cursor.visible = false;

                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
