using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class EnemyAttack : NetworkBehaviour {

    public GameObject projectile;
    public int attack_power;
    public float attack_speed;
    public float attack_range;
    public float projectile_speed;
    Vector3 projectile_angle;

    bool is_attacking = false;

    GameObject attacking_who;
    EnemyMovement em;

	void Start ()
    {
        em = this.GetComponent<EnemyMovement>();

    }
	
	void Update ()
    {
        //Sets attacking_who to correct gameobject from following_who
        attacking_who = em.following_who;

        //Starts attacking gameobject if in attack_range and if enemy is_following
        if (em.is_following && !is_attacking && Vector3.Distance(transform.position, attacking_who.transform.position) <= attack_range)
            CmdShoot();

    }

    [Command]
    void CmdShoot()
    {
        //Starts the timer
        StartCoroutine(Attacking());
        //gets attacking_who health manager and lowers gameobjects health by attack_power
        //attacking_who.GetComponent<HealthManager>().Damage(attack_power);
        GameObject tempProjectile = Instantiate(projectile, this.transform.position, Quaternion.LookRotation(Vector3.forward, attacking_who.transform.position - transform.position));
        tempProjectile.GetComponent<ProjectileManager>().SetUp(attack_power, attack_range, projectile_speed, this.gameObject);
        //Spawns the bullet in network
        NetworkServer.Spawn(tempProjectile);

    }

    IEnumerator Attacking()
    {
        //is_attacking is only to make sure the coroutine is called 1 at a time
        is_attacking = true;
        //waits for attack_speed seconds before finishing the coroutine
        yield return new WaitForSeconds(attack_speed);
        is_attacking = false;

    }

}
