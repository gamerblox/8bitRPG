using UnityEngine;
using System.Collections;

public class CursorManager : MonoBehaviour {

    //Whenever mouse enters object
    void OnMouseEnter()
    {
        if (gameObject.tag == "Player")
        {
            Camera.main.GetComponent<CursorResources>().OnPlayer();

        }

        if (gameObject.tag == "Enemy")
        {
            Camera.main.GetComponent<CursorResources>().OnEnemy();

        }

    }

    //Whenever mouse exits object
    void OnMouseExit()
    {
        Camera.main.GetComponent<CursorResources>().OnExit();

    }

    //If object dies when mouse is over
    void OnDestroy()
    {
        if (Camera.main == null)
            return;
        Camera.main.GetComponent<CursorResources>().OnExit();

    }

}
