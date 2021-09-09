using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private ItemDataBase itemDataBase;

    private bool inventoryOn;

    [SerializeField]
    private GameObject inventory;

    [SerializeField]
    private Image i1, i2, i3;

    private bool p1, p2, p3;

    // Start is called before the first frame update
    void Start()
    {
        inventoryOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inventoryOn == false)
        {
            inventoryOn = true;
        } else if(Input.GetKeyDown(KeyCode.E) && inventoryOn == true)
        {
            inventoryOn = false;
        }

        if (inventoryOn)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }
        p1 = itemDataBase.GetItemLists()[0].GetStatus();
        p2 = itemDataBase.GetItemLists()[1].GetStatus();
        p3 = itemDataBase.GetItemLists()[2].GetStatus();
        if (p1)
        {
            i1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Battery");
        }
    }
}
