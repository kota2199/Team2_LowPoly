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
            //itemDataBase.GetItemLists()[myID].SetStatus();
            other.gameObject.GetComponent<SaveSystem>().SetParts(myID);
            other.gameObject.GetComponent<ItemGet>().GetText(myID);
            Destroy(this.gameObject);
        }
    }

    private IEnumerator StartWalk()
    {
        yield return new WaitForSeconds(4);
    }
}
