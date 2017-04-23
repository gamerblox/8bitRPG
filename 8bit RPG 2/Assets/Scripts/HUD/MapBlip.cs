using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapBlip : MonoBehaviour {

    //public GameObject MiniMap;

    private GameObject blip;    

	void Start ()
    {
        blip = GameObject.Instantiate(FindObjectOfType<Map>().BlipPrefab);
        blip.transform.parent = FindObjectOfType<Map>().transform;
        //var color = GetComponent<Player>().info.AccentColor;
        //blip.GetComponent<Image>().color = color;

	}
	
	void Update ()
    {
        blip.transform.position = FindObjectOfType<Map>().WorldPositionToMap(transform.position);

	}

    void OnDestroy()
    {
        GameObject.Destroy(blip);

    }

}
