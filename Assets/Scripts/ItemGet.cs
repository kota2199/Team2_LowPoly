using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemGet : MonoBehaviour
{

    //　アイテムデータベース
    [SerializeField]
    private ItemDataBase itemDataBase;

    [SerializeField]
    GameObject messengers;

    [SerializeField]
    Text messageText;

    string sort;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            int id = other.GetComponent<ItemIdentify>().myID;
            itemDataBase.GetItemLists()[id].SetStatus();
            
            //other.GetComponent<ItemIdentify>().deleteThis();
        }
    }*/

    public void GetText(int ID)
    {
        if (ID == 0)
        {
            sort = "バッテリー";
        } else if (ID == 1)
        {

        } else if (ID == 2)
        {
            sort = "";
        }
        else if (ID == 3)
        {
            sort = "";
        }
        else if (ID == 4)
        {
            sort = "";
        }
        else if (ID == 5)
        {
            sort = "";
        }
        else if (ID == 6)
        {
            sort = "";
        }
        else if (ID == 7)
        {
            sort = "";
        }
        else if (ID == 8)
        {
            sort = "";
        }
        else if (ID == 9)
        {
            sort = "";
        }
        messengers.SetActive(true);
        messageText.text = sort + "を獲得しました！";
        Invoke("MessageFalse", 3);
    }

    void MessageFalse()
    {
        messengers.SetActive(false);
        messageText.text = ("");
    }
}
