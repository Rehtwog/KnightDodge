using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float minspeed = 10;
    public float maxspeed = 20;

    float speed;
    public int damage = 3;
    Player playerScript;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minspeed, maxspeed);
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D hitObject)
    {
        if(hitObject.tag == "Player" && playerScript.isDashing == false){
            playerScript.TakeDamage(damage);
            Instantiate(explosion,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
        if(hitObject.tag == "Ground"){
            Instantiate(explosion,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
