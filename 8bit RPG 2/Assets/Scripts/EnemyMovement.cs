using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    Rigidbody2D rbody;
    CircleCollider2D circ_collide;

    public float speed_multiplier;
    public float aggro_range;
    public float stopping_range;
    public bool is_following = false;
    public GameObject following_who;

    public bool Debugger;

	void Start () {
        rbody = GetComponent<Rigidbody2D>();
        circ_collide = GetComponent<CircleCollider2D>();
        circ_collide.radius = aggro_range;

    }

    void FixedUpdate()
    {
        //Make sure if following_who suddenly disapears then to set to null
        if (!following_who)
        {
            is_following = false;
            following_who = null;

        }

        //Animation stuff
        //Code here, do in future

        //Enemy follows player
        if (is_following && Vector3.Distance(transform.position, following_who.transform.position) > stopping_range)
        {
            //Rotates according to face player
            if (transform.position.x < following_who.transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);

            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);

            }

            //Moves enemy
            Vector2 distance = new Vector2(following_who.GetComponent<Rigidbody2D>().position.x - rbody.position.x, following_who.GetComponent<Rigidbody2D>().position.y - rbody.position.y);
            distance = distance.normalized;

            rbody.position += distance * speed_multiplier * Time.deltaTime;

        }

    }

    void OnTriggerEnter2D(Collider2D thing)
    {
        //Sets for following
        if (thing.gameObject.tag == "Player" && thing.GetType() == typeof(BoxCollider2D))
        {
            is_following = true;
            following_who = thing.gameObject;

            //Debugger stuff
            if (Debugger == true)
            {
                Debug.Log("Item " + thing.name + " entered the collider.");

                if (thing.gameObject.tag == "Player")
                {
                    Debug.Log("Item is player!");
                    Debug.Log(following_who);

                }

            }

        }

    }

    void OnTriggerExit2D(Collider2D thing)
    {
        //Sets for following
        if (thing.gameObject.tag == "Player" && thing.GetType() == typeof(BoxCollider2D))
        {
            is_following = false;
            following_who = null;

            //Debugger stuff
            if (Debugger == true)
            {
                Debug.Log("Item " + thing.name + " exited the collider.");

                if (thing.gameObject.tag == "Player")
                {
                    Debug.Log("Item is player!");

                }

            }

        }

    }

}
