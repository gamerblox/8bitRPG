using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D rbody;
    Animator anim;

    public float speed_multiplier;
    float orig_speed_mult;
    float speed_sideways_cut;

    public Vector2 movement_vector;
    //public string dir_facing;


    void Start () {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        orig_speed_mult = speed_multiplier;
        speed_sideways_cut = speed_multiplier * 0.75f;

	}
	
	void FixedUpdate () {
        movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //Animation stuff
        if (movement_vector != new Vector2(0, 0))
        {
            anim.SetBool("is_walking", true);
            anim.SetFloat("input_x", movement_vector.x);
            anim.SetFloat("input_y", movement_vector.y);
            if (movement_vector.x != 0 && movement_vector.y != 0)
                speed_multiplier = speed_sideways_cut;
            else
                speed_multiplier = orig_speed_mult;

        }
        else
            anim.SetBool("is_walking", false);

        //Actual movement stuff
        //rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime * speed_multiplier);

        //New movement stuff
        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
            rbody.velocity = movement_vector * speed_multiplier;

    }

}
