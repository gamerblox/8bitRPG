using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthFX : MonoBehaviour {

    Animator hb_anim;
    HealthManager health;

    public GameObject HealthBar;

    private int _HbDisappearWaitTime = 5;

    void Start ()
    {
        hb_anim = HealthBar.GetComponent<Animator>();
        health = this.GetComponent<HealthManager>();

        StartCoroutine(TimeSinceLastDamage());

	}
	
	void Update ()
    {
		

	}

    public void HbAppear()
    {
        hb_anim.SetBool("Disappear", false);
        StopCoroutine("TimeSinceLastDamage");
        StartCoroutine("TimeSinceLastDamage");

    }

    void HbDisappear()
    {
        hb_anim.SetBool("Disappear", true);

    }

    IEnumerator TimeSinceLastDamage()
    {
        //Waits for set seconds before finishing the coroutine
        yield return new WaitForSeconds(_HbDisappearWaitTime);
        HbDisappear();

    }

}
