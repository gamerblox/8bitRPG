using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopUpTextManager : MonoBehaviour {

    //The text
    public Text popup_text;

    //Other variables
    float time_len;
    bool can_move = false;

    //Vars for random co-ords on start
    Vector2 rand_pos;

	// Use this for initialization
	void Start()
    {
        popup_text = this.GetComponent<Text>();

    }

    //Sets the text, color and time
    public void PlayPopUp(string text, Color col, float time, float y_pos_off)
    {
        popup_text.text = text;
        popup_text.color = col;
        time_len = time;

        rand_pos = new Vector2(Random.Range(-1.5f, 1.5f), y_pos_off + Random.Range(0, 1f));
        this.GetComponent<RectTransform>().localPosition = rand_pos;

        can_move = true;

    }

    //Updates to animated pop up text
    void Update()
    {
        if (can_move)
        {
            Color temp_col = popup_text.color;
            temp_col.a = 0;
            popup_text.color = Color.Lerp(popup_text.color, temp_col, 4 * Time.deltaTime);
            //Really BS'd my way thru this one, figure out better way in future
            popup_text.transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, transform.position.y + 0.1f), 0.25f);
            //Constant num for how low alpha will be before destroyed
            if (popup_text.color.a <= (5f/255f))
                Destroy(this.gameObject);

        }

    }

}
