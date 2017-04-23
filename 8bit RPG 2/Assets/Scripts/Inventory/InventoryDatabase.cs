﻿using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class InventoryDatabase : MonoBehaviour {

    private List<Item> database = new List<Item>();
    private JsonData itemData;

    //Preparing the Json items for the database, complets the entire database of items
    void Start()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructItemDatabase();
        //Debug.Log(FetchItemByID(2).Title);

    }

    //Returns database item by correct ID
    public Item FetchItemByID(int id)
    {
        for (int i = 0; i < database.Count; i++)
            if (database[i].ID == id)
                return database[i];

        return null;

    }

    //Take Json items and constructs an entire inventory database
    void ConstructItemDatabase()
    {
        for (int i = 0; i < itemData.Count; i++)
        {
            database.Add(new Item((int)itemData[i]["id"], 
                                  itemData[i]["title"].ToString(), 
                                  (int)itemData[i]["value"], 
                                  itemData[i]["stats"]["type"].ToString(), 
                                  (int)itemData[i]["stats"]["power"], 
                                  float.Parse(itemData[i]["stats"]["range"].ToString()), 
                                  float.Parse(itemData[i]["stats"]["range"].ToString()), 
                                  itemData[i]["description"].ToString(), 
                                  itemData[i]["rarity"].ToString(), 
                                  (bool)itemData[i]["stackable"], 
                                  itemData[i]["slug"].ToString()));

        } 

    }

}

public class Item
{
    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public string Type { get; set; }
    public int Power { get; set; }
    public float Speed { get; set; }
    public float Range { get; set; }
    public string Description { get; set; }
    public string Rarity { get; set; }
    public bool Stackable { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }

    public Item(int id, string title, int value, string type, int power, float speed, float range, string description, string rarity, bool stackable, string slug)
    {
        this.ID = id;
        this.Title = title;
        this.Value = value;
        this.Type = type;
        this.Power = power;
        this.Speed = speed;
        this.Range = range;
        this.Description = description;
        this.Rarity = rarity;
        this.Stackable = stackable;
        this.Slug = slug;
        //finds correct sprite for item
        Sprite[] sprites = Resources.LoadAll<Sprite>("maincharacter1spritesheet");
        for (int i = 0; i < sprites.Length; i++)
            if (sprites[i].name == slug)
            {
                this.Sprite = sprites[i];
                return;

            }
        //if sprite not found then load defult sprite
        this.Sprite = Resources.Load<Sprite>("test");

    }

    public Item()
    {
        this.ID = -1;

    }

}
