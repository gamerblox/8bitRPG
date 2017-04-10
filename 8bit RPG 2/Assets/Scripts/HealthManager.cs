using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    SoundManager sm;

    //Basic health variables
    public int max_health;
    public int health;

    //Regen variables
    bool can_regen = true;
    public int regen_ammt;
    public float regen_time;

    //GUI Health Bar stuff
    public GameObject health_bar;
    public GameObject border_bar;
    Color hb_orig_color;
    bool hb_damage = false;

    //Popup Text
    public GameObject popup_text;
    public GameObject health_bar_parent;

    //Sets up variables
    void Start()
    {
        health = max_health;
        hb_orig_color = health_bar.GetComponent<Image>().color;
        hb_orig_color.a = 1;
        popup_text = Resources.Load("Prefabs/Pop-Up Text") as GameObject;

        sm = this.GetComponent<SoundManager>();

    }

    //Updates for health regen
    void Update()
    {
        if (health < max_health && can_regen)
            StartCoroutine(Regen());

        if (hb_damage)
            if (health_bar.GetComponent<Image>().color.a < 1)
            {
                float temp_health = health;
                float temp_max_health = max_health;
                float diff = (temp_health / temp_max_health);

                //Constant for how low a color the healthbar can go
                if (diff < 0.25f)
                    diff = 0.25f;
                Color temp_col = hb_orig_color;
                temp_col.a = diff;
                //Constant for how fast health bar fades
                health_bar.GetComponent<Image>().color = Color.Lerp(health_bar.GetComponent<Image>().color, temp_col, 4 * Time.deltaTime);

            }
            else hb_damage = false;

    }

    //Regen timer
    IEnumerator Regen()
    {
        can_regen = false;
        yield return new WaitForSeconds(regen_time);
        this.Heal(regen_ammt);
        can_regen = true;

    }

    //Border flashes when healed, timer
    IEnumerator BorderHealFlash(Color col)
    {
        Color temp_col = border_bar.GetComponent<Image>().color;
        border_bar.GetComponent<Image>().color = col;
        //Constant for flash time
        yield return new WaitForSeconds(0.1f);
        border_bar.GetComponent<Image>().color = temp_col;

    }

    //Updates the GUI Health Bar
    void UpdateHealthBarGUI()
    {
        if (health_bar != null)
        {
            float temp_health = health;
            float temp_max_health = max_health;
            float vector_health = temp_health / temp_max_health;

            health_bar.transform.localScale = new Vector3(vector_health, health_bar.transform.localScale.y, health_bar.transform.localScale.z);

        }

    }

    //Changes health_bar to show damage
    void DamageHealthBarGUI()
    {
        if (health_bar != null)
        {
            hb_damage = true;
            //Constant for alpha num for how much health bar should fade
            Color temp_color = health_bar.GetComponent<Image>().color;
            temp_color.a = 0;
            health_bar.GetComponent<Image>().color = temp_color;

        }

    }

    //Changes health_bar to show healing
    void HealHealthBarGUI()
    {
        if (border_bar != null)
        {
            //Color constant for border heal flash
            Color temp_col = border_bar.GetComponent<Image>().color;
            temp_col.g += 0.3334f;
            temp_col.a += 0.1f;
            StartCoroutine(BorderHealFlash(temp_col));

        }
        
    }

    //Damages gameobject, remembers gameobject which damage came from
    public void Damage(int ammt, GameObject player = null)
    {
        health -= ammt;
        UpdateHealthBarGUI();
        DamageHealthBarGUI();

        //Play hurt FX
        sm.PlaySound(1);

        //Pops up the damage text
        GameObject instance = Instantiate(popup_text, transform.position, transform.rotation) as GameObject;
        instance.transform.SetParent(health_bar_parent.transform, false);
        instance.GetComponent<RectTransform>().localPosition = Vector2.zero;

        string temp = "-";
        temp += ammt.ToString();
        instance.GetComponent<PopUpTextManager>().PlayPopUp(temp, Color.red, 1f, 1.5f);

        //Prepares if death happended
        if (health <= 0)
        {
            Die();

        }

    }

    //Heals gameobject
    public void Heal(int ammt)
    {
        int temp_health = health + ammt;
        if (temp_health > max_health)
            health = max_health;
        else health = temp_health;
        UpdateHealthBarGUI();
        HealHealthBarGUI();

        //Play heal FX
        sm.PlaySound(2);

        //Pops up the heal text
        GameObject instance = Instantiate(popup_text, transform.position, transform.rotation) as GameObject;
        instance.transform.SetParent(health_bar_parent.transform, false);
        instance.GetComponent<RectTransform>().localPosition = Vector2.zero;

        string temp = "+";
        temp += ammt.ToString();
        instance.GetComponent<PopUpTextManager>().PlayPopUp(temp, Color.green, 1f, 1.5f);

    }

    //Kills gameobject
    public void Die()
    {
        //This works for now, work on stuff below in future
        Destroy(this.gameObject);

        //Animation stuff
        //Code here

        //Disable all other scripts
        //Code here

    }

}
