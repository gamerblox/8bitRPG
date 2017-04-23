using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{

    public GameObject ToolTipMgr;
    private ToolTipManager tooltip;

    void Start ()
    {
        tooltip = ToolTipMgr.GetComponent<ToolTipManager>();

    }

    //enables tooltip info for item
    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.Activate("Inventory");

    }

    //disables tooltip info for item
    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.Deactivate();

    }

}
