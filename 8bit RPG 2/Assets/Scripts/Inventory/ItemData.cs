using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemData : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler{

    public int InvSlotID;
    public Item _Item;
    public int Ammout;

    public InventoryManager InventoryMgr;
    public GameObject ToolTipMgr;
    private ToolTipManager tooltip;

    private bool _mouseOver = false;
    private bool _canDrag = false;
    private bool _canDrop = false;
    public bool CanDrop { get { return _canDrop; } }

    void Start()
    {
        ToolTipMgr = GameObject.Find("_ToolTipManager");
        tooltip = ToolTipMgr.GetComponent<ToolTipManager>();

        //Enables the ammount text if the item is stackable
        if (_Item.Stackable)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(0).GetComponent<Text>().text = Ammout.ToString();

        }

        //Sets sprite and gameobject name to fit to item
        this.GetComponent<Image>().sprite = _Item.Sprite;
        this.name = _Item.Title;

    }

    //If item is stackable then change text to match Ammout
    //Change in future to update on a function call, update is super ineffecient
    void Update()
    {
        if (_Item.Stackable)
        {
            this.transform.GetChild(0).GetComponent<Text>().text = Ammout.ToString();

        }

        //Cleanly closes inv if I was pressed
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (_mouseOver)
            {
                _mouseOver = false;
                tooltip.Deactivate();

            }
            _canDrag = false;
            _canDrop = false;
            this.transform.SetParent(InventoryMgr.InvSlots[InvSlotID].transform);
            this.transform.position = InventoryMgr.InvSlots[InvSlotID].transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;

        }

    }

    //enables tooltip info for item
    public void OnPointerEnter(PointerEventData eventData)
    {
        _mouseOver = true;
        tooltip.Activate(_Item);

    }

    //disables tooltip info for item
    public void OnPointerExit(PointerEventData eventData)
    {
        _mouseOver = false;
        tooltip.Deactivate();

    }

    //grabs item in inventory
    public void OnPointerDown(PointerEventData eventData)
    {
        if (_Item.ID != -1)
        {
            _canDrag = true;
            _canDrop = true;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            this.transform.SetParent(this.transform.parent.parent.parent.parent);
            this.transform.position = eventData.position;

        }

    }

    //moves it
    public void OnDrag(PointerEventData eventData)
    {
        if (_Item.ID != -1 && _canDrag)
        {
            this.transform.position = eventData.position;

        }

    }

    //drops it
    public void OnPointerUp(PointerEventData eventData)
    {
        _canDrag = false;
        this.transform.SetParent(InventoryMgr.InvSlots[InvSlotID].transform);
        this.transform.position = InventoryMgr.InvSlots[InvSlotID].transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }

}
