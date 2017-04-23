using UnityEngine;
using System.Collections;

public class ProjectileManager : MonoBehaviour {

    //Numbers and info for projectile
    public int attack_power;
    public float attack_range;
    public float projectile_speed;
    public GameObject fromWho;
    private string _strFromWho;

    //Other variables
    public bool can_start = false;
    Vector2 orig_pos;
    Vector2 start_pos;
    Vector2 end_pos;
    public Rigidbody2D rbody;

    public void SetUp(int a_p, float a_r, float p_s, GameObject from)
    {
        //Sets the values
        attack_power = a_p;
        attack_range = a_r;
        projectile_speed = p_s;
        fromWho = from;
        can_start = true;

    }

    void Start ()
    {
        //Sets the values
        rbody = GetComponent<Rigidbody2D>();
        orig_pos = transform.position;
        _strFromWho = fromWho.tag;

        //Gets end_pos
        float r = attack_range;
        float radian = (90 + transform.rotation.eulerAngles.z) * Mathf.Deg2Rad;
        end_pos = new Vector2(orig_pos.x + (r * Mathf.Cos(radian)), orig_pos.y + (r * Mathf.Sin(radian)));

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
                    rbody.MovePosition(end_pos);

                }
                else rbody.MovePosition(temp_transform);//rbody.velocity = (Vector2)transform.up * projectile_speed;

            }

        }

    }

    void OnTriggerEnter2D(Collider2D thing)
    {
        //Return immediatly if entity trying to hit is null. kinda redundant but a precaution
        if (thing.gameObject == null)
            return;

        //Deals damage to enemy if projectile is from player, destroys on impact
        if (_strFromWho == "Player" && thing.gameObject.tag == "Enemy" && thing.GetType() == typeof(BoxCollider2D))
        {
            thing.gameObject.GetComponent<HealthManager>().Damage(attack_power);
            Destroy(this.gameObject);
            return;

        }
        
        //Deals damage to player if projectile is from enemy, destroys on impact
        if (_strFromWho == "Enemy" && thing.gameObject.tag == "Player" && thing.GetType() == typeof(BoxCollider2D))
        {
            thing.gameObject.GetComponent<HealthManager>().Damage(attack_power);
            Destroy(this.gameObject);
            return;

        }

        //Deal damage to player if projectile is from enemy player, destroys on impact
        if (_strFromWho == "Player" && thing.gameObject.tag == "Player" && fromWho != thing.gameObject && thing.GetType() == typeof(BoxCollider2D))
        {
            thing.gameObject.GetComponent<HealthManager>().Damage(attack_power);
            Destroy(this.gameObject);
            return;

        }

        //Destroys object on impact to wall
        if (thing.gameObject.tag == "Wall" && thing.GetType() == typeof(PolygonCollider2D))
        {
            Destroy(this.gameObject);
            return;

        }

    }

}
