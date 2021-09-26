using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField]
    private ItemDataBase itemDataBase;

    bool[] savedParts = new bool[10];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.P))
        {
            for(int i = 0; i < 3; i++)
            {
                savedParts[i] = itemDataBase.GetItemLists()[i].GetStatus();
            }
        }
        */
    }

    public void ResetParts()
    {
        for(int i = 0; i < 10; i++)
        {
            itemDataBase.GetItemLists()[i].ReturnStatus(savedParts[i]);
        }
    }

    public void SaveButton()
    {
        for (int i = 0; i < 10; i++)
        {
            savedParts[i] = itemDataBase.GetItemLists()[i].GetStatus();
        }
    }
}
