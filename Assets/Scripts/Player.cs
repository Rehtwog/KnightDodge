using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{   
    public GameObject losePanel;
    public Text healthDisplay;
    public Text scoreDisplay;
    public Text scoreDeadDisplay;
    public float speed;
    private float input;
    public float jumpForce;

    Animator anim;
    Rigidbody2D rb;
    public AudioSource audioGame;

    public int health;
    private float score = 0;

    public float startDashTime;
    private float dashTime;
    public float extraSpeed;
    public bool isDashing;
    public bool isDead = false;
    public bool isJumping = false;
    public float startDashCD;
    private float dashCD=0;
    public float startJumpCD;
    private float jumpCD=0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        healthDisplay.text = health.ToString();
        scoreDisplay.text = score.ToString();
    }

    private void Update()
    {
        //run
        if(input != 0){
            anim.SetBool("IsRunning",true);
        }
        else{
            anim.SetBool("IsRunning",false);
        }

        if(input > 0 && isDead == false){
            transform.eulerAngles = new Vector3(0,0,0);
        }
        else if(input < 0 && isDead == false){
            transform.eulerAngles = new Vector3(0,180,0);
        }
        //Dash
        if(Input.GetKeyDown("e") && isDashing == false && isDead == false && isJumping == false && dashCD <=0){
            speed += extraSpeed;
            isDashing = true;
            dashTime = startDashTime;
            anim.SetBool("IsDash",true);
            dashCD = startDashCD;
        }
        if(dashTime <= 0 && isDashing == true){
            isDashing = false;
            speed -= extraSpeed;
            anim.SetBool("IsDash",false);
        }else {
            dashTime -= Time.deltaTime;
            dashCD -= Time.deltaTime;
        }
        //jump
        if(Input.GetKeyDown("space")&& isDashing == false && isDead == false && jumpCD <= 0){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetBool("IsJumping",true);
            isJumping = true;
            jumpCD = startJumpCD;
        }
        if(transform.position.y <= -3.0704 && isJumping == true){
            anim.SetBool("IsJumping",false);
            isJumping = false;
            jumpCD -= startJumpCD;
        }
        if(isDead == false){
            score += Time.deltaTime;
            scoreDisplay.text = Mathf.RoundToInt(score).ToString();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //input
        input = Input.GetAxisRaw("Horizontal");

        //Moving direction
        if(isDead == false){
            rb.velocity = new Vector2(input *speed, rb.velocity.y);
        }
    }


    public void TakeDamage(int damage)
    {
        health = health - damage;
        healthDisplay.text = health.ToString();
        anim.SetTrigger("TakeDame");
        if(health <= 0){
            anim.SetBool("IsDead",true);
            isDead = true;
            losePanel.SetActive(true);
            scoreDeadDisplay.text = scoreDisplay.text;
            audioGame.Stop();
        }
    }

}
