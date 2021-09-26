using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIdentify : MonoBehaviour
{
    public int myID;

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

    //public void deleteThis()
    //{
    //    Destroy(this.gameObject);
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //int id = other.GetComponent<ItemIdentify>().myID;
            itemDataBase.GetItemLists()[myID].SetStatus();
            Destroy(this.gameObject);
            other.gameObject.GetComponent<ItemGet>().GetText(myID);
        }
    }
}
