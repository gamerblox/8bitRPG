using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour {

    Text text;

    public string StandardText;

    void Start ()
    {
        text = this.GetComponent<Text>();
        text.text = StandardText;

    }
	
	void Update ()
    {
        text.text = HealthManager.PlayerHealth.health + "/" + HealthManager.PlayerHealth.max_health + " HP";

	}

}
