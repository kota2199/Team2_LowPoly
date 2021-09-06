using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGet : MonoBehaviour
{

    //　アイテムデータベース
    [SerializeField]
    private ItemDataBase itemDataBase;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            int id = other.GetComponent<ItemIdentify>().myID;
            itemDataBase.GetItemLists()[id].SetStatus();
            other.GetComponent<ItemIdentify>().deleteThis();
        }
    }
}
