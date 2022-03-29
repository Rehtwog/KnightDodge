using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float minspeed = 10;
    public float maxspeed = 15;

    float speed;
    public int damage = 5;
    Player playerScript;

    //Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        speed = Random.Range(minspeed, maxspeed);
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        //anim.SetBool("IsRolling",true);
    }

    void OnTriggerEnter2D(Collider2D hitObject)
    {
        if(hitObject.tag == "Player" && playerScript.isDashing == false){
            playerScript.TakeDamage(damage);
            Destroy(gameObject);
        }
        if(hitObject.tag == "Wall"){
            Destroy(gameObject);
        }
    }
}
