using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player obj;

    public int lives = 3;
    public bool isGrounded = false;
    public bool isMoving = false;
    public bool isImmune = false;

    public float speed = 8f;
    public float jumpForce = 3f;
    public float movHor;

    public float immuneTimeCnt = 0f;
    public float immuneTime = 0.5f;

    public LayerMask groundLayer;
    public float radius = 0.5f;
    public float groundRayDist = 0.8f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spr;

    private void Awake()
    {
        obj = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();

    }

    
    void Update()
    {
        if (Game.obj.gamePaused)
        {
            movHor = 0f;
            return;
        }

        movHor = Input.GetAxisRaw("Horizontal");
        isMoving = (movHor != 0f);
        isGrounded = Physics2D.CircleCast(transform.position, radius, Vector3.down, groundRayDist, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        if (isImmune)
        {
            spr.enabled = !spr.enabled;
            immuneTimeCnt -= Time.deltaTime;
            
            if(immuneTimeCnt <=0)
            {
                isImmune = false;
                spr.enabled = true;
            }
        }

        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", isGrounded);

        Flip(movHor);

    }

     void FixedUpdate()
    {
        rb.velocity = new Vector2(movHor * speed, rb.velocity.y);
    }

    private void goImmune()
    {
        isImmune = true;
        immuneTimeCnt = immuneTime;
    }


    public void Jump()
    {
        if (!isGrounded) return;
        rb.velocity = Vector2.up * jumpForce;
        AudioManager.obj.PlayJump();
    }

    private void Flip(float _xValue)  /*ACCION PARA QUE EL PJ GIRE AL LADO NEGATIVO DE X*/
    {
        Vector3 theScale = transform.localScale;
        if (_xValue < 0)
            theScale.x = Mathf.Abs(theScale.x) * -1;
        else
            if (_xValue > 0)
            theScale.x = Mathf.Abs(theScale.x);
        transform.localScale = theScale;
    }

    public void getDamage()
    {
        lives--;
        AudioManager.obj.PlayHit();
        UIManager.obj.UpdateLives();
        goImmune();

        if (lives <= 0)
        {
            FXManager.obj.ShowPop(transform.position);
            Game.obj.gameOver();
        }
    }

    public void AddLive()
    {
        lives++;
        if (lives > Game.obj.maxLives)
            lives = Game.obj.maxLives;
    }
    private void OnDestroy()
    {
        obj = null;
    }
}
