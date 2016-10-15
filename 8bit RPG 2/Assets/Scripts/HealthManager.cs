using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

    public int max_health;
    public int health;

    //GUI Health Bar stuff
    public GameObject health_bar;

    void Start()
    {
        health = max_health;

    }

    //Updates the GUI Health Bar
    void UpdateHealthBar()
    {
        if (health_bar != null)
        {
            float temp_health = health;
            float temp_max_health = max_health;
            float vector_health = temp_health / temp_max_health;
            health_bar.transform.localScale = new Vector3(vector_health, health_bar.transform.localScale.y, health_bar.transform.localScale.z);

        }

    }

    //Damages gameobject
    public void Damage(int ammt, GameObject player = null)
    {
        health -= ammt;
        UpdateHealthBar();

        //Prepares if death happended
        if (health <= 0)
        {
            Die();

            //Only does this if player killed enemy
            if (player != null)
            {
                DeathMessage(player);

            }

        }

    }

    //Heals gameobject
    public void Heal(int ammt)
    {
        health += ammt;
        UpdateHealthBar();

    }

    //Kills gameobject
    public void Die()
    {
        //This is place for now but work on stuff below in future
        Destroy(this.gameObject);

        //Animation stuff
        //Code here

        //Disable all other scripts
        //Code here

    }

    //Sends message to player that enemy died
    public void DeathMessage(GameObject send)
    {
        send.GetComponent<PlayerAttack>().EnemyDied(this.gameObject);
        
    }

}
