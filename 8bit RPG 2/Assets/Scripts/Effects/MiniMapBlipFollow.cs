using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapBlipFollow : MonoBehaviour {

    public GameObject Blip;
    private GameObject _instance;
    public GameObject BlipParent;

	void Start ()
    {
        _instance = Instantiate(Blip, transform.position, transform.rotation);
        _instance.transform.SetParent(BlipParent.transform, false);

    }
	
	void FixedUpdate ()
    {
        Vector3 following = this.transform.position;
        Vector3 tempTrans = new Vector3(following.x, following.y, this.transform.position.z);
        _instance.transform.position = tempTrans;

	}

    void OnDestroy()
    {
        Destroy(_instance);

    }

}
