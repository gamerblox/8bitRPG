using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    public Transform target;
    public float lerp_num;
	
	void FixedUpdate () {
        //Optional to keep camera size set pixels
        //Camera.main.orthographicSize = (Screen.height / 100f) / 4f;

        if (target)
        {
            //New lerp camera
            transform.position = Vector3.Lerp(transform.position, target.position, lerp_num) + new Vector3(0, 0, -10);

            //Old code for camera position
            //transform.position = target.position + new Vector3(0, 0, -10);

        }

	}
}
