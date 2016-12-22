using UnityEngine;
using System.Collections;

public class AttackManager : MonoBehaviour {

    public GameObject projectile;
    public int attack_power;
    public float attack_speed;
    public float attack_range;
    public float projectile_speed;
    Vector3 projectile_angle;

    bool is_attacking = false;

    void Update ()
    {
        //When the space bar is pressed, Attack()
        if (Input.GetButton("Jump"))
            Attack();

        //Everything below is for preparing the projectile to point to the mouse
        projectile_angle = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    void Attack()
    {
        //Animation stuff
        //Do in future

        //Starts the corountine if can_attack and not currently is_attack
        if (!is_attacking)
            StartCoroutine(Attacking());

    }

    IEnumerator Attacking()
    {
        //is_attacking is only to make sure the coroutine is called once at a time
        is_attacking = true;
        //Instantiates the projectile and prepares it's scripts
        Instantiate(projectile, this.transform.position, Quaternion.LookRotation(Vector3.forward, projectile_angle - transform.position));
        projectile.GetComponent<ProjectileManager>().SetUp(attack_power, attack_range, projectile_speed, this.tag);
        //Waits for attack_speed seconds before finishing the coroutine
        yield return new WaitForSeconds(attack_speed);
        is_attacking = false;

    }

}
