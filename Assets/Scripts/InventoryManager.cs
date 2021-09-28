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
    private Image i1, i2, i3, i4, i5, i6, i7, i8, i9, i10;

    [SerializeField]
    GameObject player;

    private bool p0, p1, p2, p3, p4, p5, p6, p7, p8, p9;

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
        }
        else if (Input.GetKeyDown(KeyCode.E) && inventoryOn == true)
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

        p0 = itemDataBase.GetItemLists()[0].GetStatus();
        p1 = itemDataBase.GetItemLists()[1].GetStatus();
        p2 = itemDataBase.GetItemLists()[2].GetStatus();
        p3 = itemDataBase.GetItemLists()[3].GetStatus();
        p4 = itemDataBase.GetItemLists()[4].GetStatus();
        p5 = itemDataBase.GetItemLists()[5].GetStatus();
        p6 = itemDataBase.GetItemLists()[6].GetStatus();
        p7 = itemDataBase.GetItemLists()[7].GetStatus();
        p8 = itemDataBase.GetItemLists()[8].GetStatus();
        p9 = itemDataBase.GetItemLists()[9].GetStatus();

        if (p0)
        {
            i1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Gear");
        }
        if (p1)
        {
            i2.GetComponent<Image>().sprite = Resources.Load<Sprite>("syoukaki");
        }
        if (p2)
        {
            i3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Fuel");
        }
        if (p3)
        {
            i4.GetComponent<Image>().sprite = Resources.Load<Sprite>("arrey");
        }
        if (p4)
        {
            i5.GetComponent<Image>().sprite = Resources.Load<Sprite>("ElectricDriver");
        }
        if (p5)
        {
            i6.GetComponent<Image>().sprite = Resources.Load<Sprite>("Battery");
        }
        if (p6)
        {
            i7.GetComponent<Image>().sprite = Resources.Load<Sprite>("O2");
        }
        if (p7)
        {
            i8.GetComponent<Image>().sprite = Resources.Load<Sprite>("musen");
        }
        if (p8)
        {
            i9.GetComponent<Image>().sprite = Resources.Load<Sprite>("motor");
        }
        if (p9)
        {
            i10.GetComponent<Image>().sprite = Resources.Load<Sprite>("computer");
        }

        if (p0 & p1 & p2)
        {
            player.GetComponent<WarpFinalScript>().hasSta2Item = true;
        }

        if (p0 & p1 & p2 & p3 & p4 & p5 & p6)
        {
            player.GetComponent<WarpFinalScript>().hasSta3Item = true;
        }

        if (p0 & p1 & p2 & p3 & p4 & p5 & p6 & p7 & p8)
        {
            player.GetComponent<WarpFinalScript>().hasAllItems = true;
        }
    }
}
