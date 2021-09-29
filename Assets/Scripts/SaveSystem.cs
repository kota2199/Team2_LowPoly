using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField]
    private ItemDataBase itemDataBase;

    public bool[] savedParts = new bool[10];

    [SerializeField]
    GameObject completeSaveText;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("bootsnum") < 1)
        {
            for (int i = 0; i < 10; i++)
            {
                savedParts[i] = false;
                itemDataBase.GetItemLists()[i].ReturnStatus(savedParts[i]);
            }
        } else
        {
            for (int i = 0; i < 10; i++)
            {
                savedParts[i] = itemDataBase.GetItemLists()[i].GetStatus();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SaveButton()
    {
        for (int i = 0; i < 10; i++)
        {
            itemDataBase.GetItemLists()[i].ReturnStatus(savedParts[i]);
        }

        GetComponent<WeaponGet>().WeaponSave();

        GetComponent<PayerLeveling>().SaveExpLv();

        completeSaveText.SetActive(true);
        Invoke("TextFalse", 1);
    }

    public void SetParts(int savenum)
    {
        savedParts[savenum] = true;
    }

    void TextFalse()
    {
        completeSaveText.SetActive(false);
    }
}
