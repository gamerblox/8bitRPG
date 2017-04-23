using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTime : MonoBehaviour {

    Text text;

    public string StandardText;

    public float time;

	void Start ()
    {
        text = this.GetComponent<Text>();
        text.text = StandardText;

        time = 0;

	}
	
	void Update ()
    {
        //Sets up the post fix
        string postFix;
        if (GameTimeManager.GameTime.IsDayime)
            postFix = "PM";
        else postFix = "AM";

        //Does caluations for time
        time = GameTimeManager.GameTime.CurrentTime / GameTimeManager.GameTime.LengthOfDay;
        float hour = (24 * time) - 12;
        if (hour < 1)
        {
            hour += 12;
            if (hour < 1)
                hour += 12;

        }
        float minute = (hour - Mathf.Floor(hour)) * 60;

        //Create string of time
        if (Mathf.Floor(minute) < 10)
        {
            string tempMinute = "0" + Mathf.Floor(minute);
            text.text = Mathf.Floor(hour) + ":" + tempMinute + " " + postFix;

        }
        else text.text = Mathf.Floor(hour) + ":" + Mathf.Floor(minute) + " " + postFix;

    }

}
