using UnityEngine;
using System.Collections;

public class CursorResources : MonoBehaviour {

    //Cursor textures
    public Texture2D default_cursor;
    public Texture2D attack_cursor;
    public Texture2D select_cursor;

    //Other variables
    public Vector2 cursor_default_pos;
    public CursorMode cur_mode;


    //Sets the default cursor texture
    void Start()
    {
        Cursor.SetCursor(default_cursor, cursor_default_pos, cur_mode);

    }

    //Sets up cursor texture if on player
    public void OnPlayer()
    {
        Cursor.SetCursor(select_cursor, cursor_default_pos, cur_mode);

    }

    //Sets up cursor texture if on enemy
    public void OnEnemy()
    {
        Cursor.SetCursor(attack_cursor, cursor_default_pos, cur_mode);

    }

    //Sets the default cursor texture upon exit
    public void OnExit()
    {
        Cursor.SetCursor(default_cursor, cursor_default_pos, cur_mode);

    }

}
