using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipManager : MonoBehaviour {

    //item for inventory
    private Item _item;

    //string data
    private string _data;

    //reference to tooltip object
    public GameObject ToolTip;
    private GameObject _tooltip;

    void Start()
    {
        _tooltip = ToolTip;
        _tooltip.SetActive(false);

    }

    void Update()
    {
        if (_tooltip.activeSelf)
        {
            _tooltip.transform.position = Input.mousePosition;

        }

    }

    public void Activate(Item item)
    {
        _item = item;
        ConstructItemDataString();
        _tooltip.SetActive(true);

    }

    public void Activate(string str)
    {
        string tempStr = "yellow";
        _data = "<color=" + tempStr + "><b><size=24>" + str + "</size></b></color>";
        _tooltip.SetActive(true);
        _tooltip.transform.GetChild(0).GetComponent<Text>().text = _data;

    }

    public void Deactivate()
    {
        _tooltip.SetActive(false);

    }

    public void ConstructItemDataString()
    {
        //gets color depending on item rarity
        string tempStr;
        if (_item.Rarity == "Common")
            tempStr = "silver";
        else if (_item.Rarity == "Semi-Rare")
            tempStr = "yellow";
        else if (_item.Rarity == "Rare")
            tempStr = "red";
        else tempStr = "blue";
        //construct data string
        _data = "<b><size=20>" + _item.Title + "</size></b>\n\n" + 
                "<size=17>" + _item.Description + "</size>\n" +
                "<color=" + tempStr + "><i>" + _item.Rarity + "</i></color>";

        _tooltip.transform.GetChild(0).GetComponent<Text>().text = _data;

    }

}
