using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    public Transform target;
    Camera main_camera;

	void Start () {
        main_camera = GetComponent<Camera>();
	
	}
	
	void FixedUpdate () {
        //Optional to keep camera size set pixels
        //main_camera.orthographicSize = (Screen.height / 100f) / 4f;

        if (target)
        {
            //Want to lerp but causes wierd visual glitch (will use for now) 
            transform.position = Vector3.Lerp(transform.position, target.position, 0.1f) + new Vector3(0, 0, -10);
            //Old but good code for camera position
            //transform.position = target.position + new Vector3(0, 0, -10);

        }

	}
}
