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
        if (ID == 1)
        {
            sort = "消化器";
            messengers.SetActive(true);
            messageText.text = sort + "を獲得しました！";
            Invoke("MessageFalse", 3);
        }
        else if (ID == 2)
        {
            sort = "燃料";
            messengers.SetActive(true);
            messageText.text = sort + "を獲得しました！";
            Invoke("MessageFalse", 3);
        }
        else if (ID == 3)
        {
            sort = "加工された鉄";
            messengers.SetActive(true);
            messageText.text = sort + "を獲得しました！";
            Invoke("MessageFalse", 3);
        }
        else if (ID == 4)
        {
            sort = "電動ドライバー";
            messengers.SetActive(true);
            messageText.text = sort + "を獲得しました！";
            Invoke("MessageFalse", 3);
        }
        else if (ID == 5)
        {
            sort = "バッテリー";
            messengers.SetActive(true);
            messageText.text = sort + "を獲得しました！";
            Invoke("MessageFalse", 3);
        }
        else if (ID == 6)
        {
            sort = "酸素ボンベ";
            messengers.SetActive(true);
            messageText.text = sort + "を獲得しました！";
            Invoke("MessageFalse", 3);
        }
        else if (ID == 7)
        {
            sort = "無線機";
            messengers.SetActive(true);
            messageText.text = sort + "を獲得しました！";
            Invoke("MessageFalse", 3);
        }
        else if (ID == 8)
        {
            sort = "モーター";
            messengers.SetActive(true);
            messageText.text = sort + "を獲得しました！";
            Invoke("MessageFalse", 3);
        }
        else if (ID == 9)
        {
            sort = "制御用コンピューター";
            messengers.SetActive(true);
            messageText.text = sort + "を獲得しました！";
            Invoke("MessageFalse", 3);
        }
        audioSource_getsound.PlayOneShot(itemGet_s);
    }

    void MessageFalse()
    {
        messengers.SetActive(false);
        messageText.text = ("");
    }
}
