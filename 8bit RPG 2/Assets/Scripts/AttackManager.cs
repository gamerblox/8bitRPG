using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class AttackManager : NetworkBehaviour {

    SoundManager sm;

    public GameObject projectile;
    public int attack_power;
    public float attack_speed;
    public float attack_range;
    public float projectile_speed;
    private Vector3 projectile_angle;

    bool is_attacking = false;

    void Start()
    {
        sm = this.GetComponent<SoundManager>();

    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;

        }

        //Below is for preparing the projectile to point to the mouse
        projectile_angle = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //When the left mouse button is pressed, Attack()
        if (Input.GetMouseButton(0))
        {
            Attack();

        }

    }

    void Attack()
    {
        //Animation stuff
        //Do in future

        //Starts the corountine if can_attack and not currently is_attack
        if (!is_attacking)
        {
            //Stars the timer
            StartCoroutine(Attacking());
            //Play hit FX
            sm.PlaySound(0);
            //Spawns the bullet in network
            CmdNetworkSpawn(Quaternion.LookRotation(Vector3.forward, projectile_angle - transform.position));

        }

    }

    [Command]
    void CmdNetworkSpawn(Quaternion temp)
    {
        //Instantiates the projectile and prepares it's scripts
        GameObject tempProjectile = (GameObject)Instantiate(projectile, transform.position, temp);
        tempProjectile.GetComponent<ProjectileManager>().SetUp(attack_power, attack_range, projectile_speed, this.gameObject);
        NetworkServer.Spawn(tempProjectile);

    }

    IEnumerator Attacking()
    {
        //is_attacking is only to make sure the coroutine is called once at a time
        is_attacking = true;
        //Waits for attack_speed seconds before finishing the coroutine
        yield return new WaitForSeconds(attack_speed);
        is_attacking = false;

    }

}
