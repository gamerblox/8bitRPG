using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAttack : MonoBehaviour {

    public int attack_power;
    public float attack_speed;
    public float attack_range;

    bool is_attacking = false;
    bool can_attack = false;
    public GameObject attacking_who;
    public List<GameObject> all_in_attack_range;

    public bool Debugger;

    void Start ()
    {
        this.GetComponent<CircleCollider2D>().radius = attack_range;    

	}
	
	void Update ()
    {
        //Regulates the all_in_attack_range list
        if (all_in_attack_range.Count > 0)
        {
            can_attack = true;

        }
        else
        {
            can_attack = false;
            attacking_who = null;

        }

        //When the space bar is pressed, Attack()
        if (Input.GetButton("Jump"))
        {
            Attack();

        }
	
	}

    void Attack()
    {
        //Animation stuff
        //Do in future

        //Starts the corountine if can_attack and not currently is_attack
        if (!is_attacking && can_attack)
        {
            //Randomly picks a gameobject from the list to attack if past enemy died
            if (attacking_who == null)
            {
                attacking_who = all_in_attack_range[Random.Range(0, all_in_attack_range.Count)];

            }

            StartCoroutine(Attacking());

        }

    }

    //Handles list when enemy dies
    public void EnemyDied(GameObject enemy)
    {
        all_in_attack_range.Remove(enemy);

    }

    IEnumerator Attacking()
    {
        //is_attacking is only to make sure the coroutine is called once at a time
        is_attacking = true;
        //Gets attacking_who health manager and lowers gameobjects health by attack_power
        attacking_who.GetComponent<HealthManager>().Damage(attack_power, this.gameObject);
        //Waits for attack_speed seconds before finishing the coroutine
        yield return new WaitForSeconds(attack_speed);
        is_attacking = false;

    }

    void OnTriggerEnter2D(Collider2D thing)
    {
        //Sets for attacking
        if (thing.gameObject.tag == "Enemy" && thing.GetType() == typeof(BoxCollider2D))
        {
            attacking_who = thing.gameObject;
            all_in_attack_range.Add(thing.gameObject);

            //Debugger stuff
            if (Debugger == true)
            {
                Debug.Log("Item " + thing.name + " entered the collider.");

                if (thing.gameObject.tag == "Enemy")
                {
                    Debug.Log("Item is enemy!");
                    Debug.Log(attacking_who);

                }

            }

        }

    }

    void OnTriggerExit2D(Collider2D thing)
    {
        //Sets for attacking
        if (thing.gameObject.tag == "Enemy" && thing.GetType() == typeof(BoxCollider2D))
        {
            all_in_attack_range.Remove(thing.gameObject);

            //Debugger stuff
            if (Debugger == true)
            {
                Debug.Log("Item " + thing.name + " exited the collider.");

                if (thing.gameObject.tag == "Enemy")
                {
                    Debug.Log("Item is enemy!");

                }

            }

        }

    }

}
