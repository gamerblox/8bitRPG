using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotManager : MonoBehaviour, IDropHandler {

    public int SlotID;
    public InventoryManager InventoryMgr;

    public void OnDrop(PointerEventData eventData)
    {
        //Puts item in new empty slot
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        if (droppedItem.CanDrop)
            if (InventoryMgr.InvItems[SlotID].ID == -1)
            {
                InventoryMgr.InvItems[droppedItem.InvSlotID] = new Item();
                InventoryMgr.InvItems[SlotID] = droppedItem._Item;
                droppedItem.InvSlotID = SlotID;
                droppedItem.transform.SetParent(this.transform);
                droppedItem.transform.position = this.transform.position;

            }
            else if(droppedItem.InvSlotID != SlotID)
            {
                //if not empty then switch items
                Transform item = this.transform.GetChild(0);
                item.GetComponent<ItemData>().InvSlotID = droppedItem.InvSlotID;
                item.transform.SetParent(InventoryMgr.InvSlots[droppedItem.InvSlotID].transform);
                item.transform.position = InventoryMgr.InvSlots[droppedItem.InvSlotID].transform.position;

                droppedItem.InvSlotID = this.SlotID;
                droppedItem.transform.SetParent(this.transform);
                droppedItem.transform.position = this.transform.position;

                InventoryMgr.InvItems[droppedItem.InvSlotID] = item.GetComponent<ItemData>()._Item;
                InventoryMgr.InvItems[SlotID] = droppedItem._Item;

            }

    }

}
