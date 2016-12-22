using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {

    GameObject inventory_panel;
    GameObject slot_panel;
    public GameObject inventory_slot;
    public GameObject inventory_item;

    int slot_ammount;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        slot_ammount = 20; 
        inventory_panel = GameObject.Find("Inv Panel");
        slot_panel = inventory_panel.transform.FindChild("Slot Panel").gameObject;
        for (int i = 0; i < slot_ammount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventory_slot));
            slots[i].transform.SetParent(slot_panel.transform);

        }

    }

    public void AddItem(int id)
    {


    }

}
