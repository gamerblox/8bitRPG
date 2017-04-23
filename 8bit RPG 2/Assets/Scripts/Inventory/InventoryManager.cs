using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {

    //private GameObject _inventoryPanel;
    public GameObject SlotPanel;
    public GameObject InventorySlot;
    public GameObject InventoryItem;

    InventoryDatabase database;

    //ammt of slots in HUD inventory
    private int _slotAmmount = 20;
    public List<Item> InvItems = new List<Item>();
    public List<GameObject> InvSlots = new List<GameObject>();

    void Start()
    {
        //_inventoryPanel = GameObject.Find("Inv Panel");
        //_slotPanel = _inventoryPanel.transform.FindChild("Slot Panel").gameObject;
        database = this.GetComponent<InventoryDatabase>();

        for (int i = 0; i < _slotAmmount; i++)
        {
            InvItems.Add(new Item());
            GameObject tempItem = Instantiate(InventorySlot);
            tempItem.transform.SetParent(SlotPanel.transform, false);
            InvSlots.Add(tempItem);
            InvSlots[i].transform.SetParent(SlotPanel.transform);
            //sets up slot[i] slotmanager
            SlotManager tempSlot = InvSlots[i].GetComponent<SlotManager>();
            tempSlot.InventoryMgr = this;
            tempSlot.SlotID = i;

        }

        //test to add items to inventory
        AddItem(0);
        AddItem(1);
        AddItem(1);
        AddItem(0, 3);
        AddItem(1, 48);
        AddItem(2);

    }

    public void AddItem(int id, int ammount = 1)
    {
        //grabs item from id and then adds it to inventory
        Item itemToAdd = database.FetchItemByID(id);

        //if stackable then add 1 to inventory if already inventory
        int tempIndex = CheckItemInInv(itemToAdd);
        if (itemToAdd.Stackable && tempIndex != -1)
        {
            ItemData data = InvSlots[tempIndex].transform.GetChild(0).GetComponent<ItemData>();
            data.Ammout += ammount;
            data.transform.GetChild(0).GetComponent<Text>().text = data.Ammout.ToString();
            return;

        }

        //if not stackable, add item to inventory according to the ammount given
        for (int j = 0; j < ammount; j++)
            for(int i = 0; i < InvItems.Count; i++)
            {
                //adds item if there is a free spot
                if (InvItems[i].ID == -1)
                {
                    InvItems[i] = itemToAdd;
                    GameObject tempItem = Instantiate(InventoryItem);
                    ItemData tempData = tempItem.GetComponent<ItemData>();
                    tempData._Item = itemToAdd;
                    tempData.InvSlotID = i;
                    tempData.InventoryMgr = this;
                    tempItem.transform.SetParent(InvSlots[i].transform, false);
                    break;

                }

            }

    }

    //checks if item is in inventory, if so then return index, if not then return null
    int CheckItemInInv(Item item)
    {
        for (int i = 0; i < InvItems.Count; i++)
            if (InvItems[i].ID == item.ID)
                return i;
        return -1;

    }

}
