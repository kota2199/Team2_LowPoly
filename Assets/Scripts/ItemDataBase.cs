using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "CreateItemDataBase")]
public class ItemDataBase : ScriptableObject {
 
    [SerializeField]
    private List<Item> itemLists = new List<Item>();

    //アイテムリストを返す

    //　アイテムの種類
    public enum ItemType 
    {
        Sword,
        Gun,
        Parts1,
        Parts2,
        Parts3
    }

    public List<Item> GetItemLists()
    {
        return itemLists;
    }
    //　アイテムデータのリスト
    /*public List<ItemData> itemDataList = new List<ItemData>(); 
 
    void Awake() 
    {
        //　アイテムの全情報を作成
        itemDataList.Add(new ItemData(Resources.Load("Sword", typeof(Sprite)) as Sprite, "FlashLight", ItemType.Sword, "あれば便利な辺りを照らすライト"));
        itemDataList.Add(new ItemData(Resources.Load("Sword", typeof(Sprite)) as Sprite, "BroadSword", ItemType.Sword, "普通の剣"));
        itemDataList.Add(new ItemData(Resources.Load("Gun", typeof(Sprite)) as Sprite, "HandGun", ItemType.Gun, "標準のハンドガン"));
    }

    //　全アイテムデータを返す
    public List<ItemData> GetItemDataList() 
    {
        return itemDataList;
    }

    //　個々のアイテムデータを返す
    public ItemData GetItemData(string itemName) 
    {
        foreach (var item in itemDataList) 
        {
            if(item.GetItemName() == itemName) 
            {
                return item;
            }
        }
        return null;
    }
    */
}