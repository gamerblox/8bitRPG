using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {

	//Sets up local player
    public override void OnStartLocalPlayer()
    {
        //this.tag = "Player";
        this.GetComponent<PlayerMovement>().enabled = true;
        //this.GetComponent<HealthManager>().enabled = true;
        //this.GetComponent<AttackManager>().enabled = true;
        //this.GetComponent<SoundManager>().enabled = true;
        Camera.main.GetComponent<CameraManager>().target = this.transform;

    }

}
