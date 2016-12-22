﻿using UnityEngine;
using System.Collections;

public class ProjectileManager : MonoBehaviour {

    //Numbers and info for projectile
    public int attack_power;
    public float attack_range;
    public float projectile_speed;
    public string from;

    //Other variables
    public bool can_start = false;
    Vector2 orig_pos;
    Vector2 end_pos;
    public Rigidbody2D rbody;

    public void SetUp(int a_p, float a_r, float p_s, string from_str)
    {
        //Sets the values
        attack_power = a_p;
        attack_range = a_r;
        projectile_speed = p_s;
        from = from_str;
        can_start = true;

    }

    void Start ()
    {
        //Sets the values
        rbody = GetComponent<Rigidbody2D>();
        orig_pos = transform.position;

        //Gets end_pos
        float r = attack_range;
        float radian = (90 + transform.rotation.eulerAngles.z) * Mathf.Deg2Rad;
        end_pos = new Vector2(orig_pos.x + (r * Mathf.Cos(radian)), orig_pos.y + (r * Mathf.Sin(radian)));
        //Debug.Log(end_pos);

    }

    void FixedUpdate ()
    {
        if (can_start)
        {
            //Tests to see if current projectile is at end_pos before next move frame
            if (new Vector2(transform.position.x, transform.position.y) == end_pos)
                Destroy(this.gameObject);

            //Tests to see if current projectile is below attack_range before next move frame
            if (Vector2.Distance(orig_pos, transform.position) < attack_range)
            {
                Vector2 temp_transform = transform.position + (transform.up * projectile_speed * Time.deltaTime);

                //Tests to see if next move frame is above attack_range and not at end_pos, if so then set next move frame at end_pos, else move one frame
                if (Vector2.Distance(orig_pos, temp_transform) > attack_range && temp_transform != end_pos)
                {
                    transform.position = end_pos;

                }
                else transform.position = temp_transform;

            }

        }

    }

    void OnTriggerEnter2D(Collider2D thing)
    {
        //Deals damage to enemy if projectile is from player, destroys on impact
        if (from == "Player" && thing.gameObject.tag == "Enemy" && thing.GetType() == typeof(BoxCollider2D))
        {
            thing.gameObject.GetComponent<HealthManager>().Damage(attack_power);
            Destroy(this.gameObject);

        }
        
        //Deals damage to player if projectile is from enemy, destroys on impact
        if (from == "Enemy" && thing.gameObject.tag == "Player" && thing.GetType() == typeof(BoxCollider2D))
        {
            thing.gameObject.GetComponent<HealthManager>().Damage(attack_power);
            Destroy(this.gameObject);

        }

    }

}
