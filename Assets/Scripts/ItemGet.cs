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

    [SerializeField]
    AudioClip itemGet_s;

    [SerializeField]
    AudioSource audioSource_getsound;

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
            sort = "工具";
        } else if (ID == 1)
        {
            sort = "消化器";
        }
        else if (ID == 2)
        {
            sort = "燃料";
        }
        else if (ID == 3)
        {
            sort = "加工された鉄";
        }
        else if (ID == 4)
        {
            sort = "電動ドライバー";
        }
        else if (ID == 5)
        {
            sort = "バッテリー";
        }
        else if (ID == 6)
        {
            sort = "酸素ボンベ";
        }
        else if (ID == 7)
        {
            sort = "無線機";
        }
        else if (ID == 8)
        {
            sort = "モーター";
        }
        else if (ID == 9)
        {
            sort = "制御用コンピューター";
        }
        messengers.SetActive(true);
        messageText.text = sort + "を獲得しました！";
        audioSource_getsound.PlayOneShot(itemGet_s);
        Invoke("MessageFalse", 3);
    }

    void MessageFalse()
    {
        messengers.SetActive(false);
        messageText.text = ("");
    }
}
