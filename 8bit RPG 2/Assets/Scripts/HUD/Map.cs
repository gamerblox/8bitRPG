using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public RectTransform ViewPort;
    public Transform Corner1, Corner2;
    public GameObject BlipPrefab;
    public static Map Current;

    public float xOffset;
    public float yOffset;

    private Vector2 mapSize;

    private RectTransform mapRect;

    public Vector2 WorldPositionToMap(Vector3 point)
    {
        //var pos = point - Corner1.position;
        Vector2 tempPos = new Vector2(
            (point.x / mapSize.x) * mapRect.rect.width ,//* 0.5f,
            (point.y / mapSize.y) * mapRect.rect.height);//* 0.5f);
        /*Vector2 mapPos = new Vector2(
            tempPos.x + xOffset,
            tempPos.y + yOffset);*/
        return tempPos;

    }

	void Start ()
    {
        mapSize = new Vector2(
            Corner2.position.x - Corner1.position.x,
            Corner1.position.y - Corner2.position.y);

        mapRect = this.GetComponent<RectTransform>();

	}
	
	void Update ()
    {
        Vector2 viewPos = WorldPositionToMap(Camera.main.transform.position);
        ViewPort.GetComponent<RectTransform>().position = viewPos;

	}

}
