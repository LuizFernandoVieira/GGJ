using UnityEngine;
using System.Collections;

public class Player : GameActor {
    
    InputHandler inputHandler;
    Command command;
    
    Rigidbody2D rb;
    
    RaycastHit2D hitL;
    RaycastHit2D hitR;
    RaycastHit2D hitD;
    RaycastHit2D hitDL;
    RaycastHit2D hitDR;
    
    float distanceL;
    float distanceR;
    float distanceD;
    float distanceDL;
    float distanceDR;
    
    public float initSpeed = 3f;
    float speed = 3f;
    
    bool canJump  = false;
    bool canTotem = false;
    
    private Animator animator;
    
    private SpriteRenderer spriteRenderer;
    
    bool currentFacing = true;
    bool changeFacing = false;
    
    public void Awake()
    {
        inputHandler = new InputHandler();
        rb = GetComponent<Rigidbody2D>();
        
        animator = GetComponent<Animator>();
        
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void Update()
    {
        command = inputHandler.HandleInput();
        
        if (command != null)
        {
            command.Execute(this);
        }

        Vector2 vectorR  = new Vector2(transform.position.x+0.13f, transform.position.y);
        Vector2 vectorL  = new Vector2(transform.position.x-0.13f, transform.position.y);
        Vector2 vectorD  = new Vector2(transform.position.x      , transform.position.y-0.17f);
        Vector2 vectorDL = new Vector2(transform.position.x-0.12f, transform.position.y-0.17f);
        Vector2 vectorDR = new Vector2(transform.position.x+0.12f, transform.position.y-0.17f);
        
        hitR = Physics2D.Raycast(vectorR  , Vector2.right);
        hitL = Physics2D.Raycast(vectorL  , Vector2.left );
        hitD = Physics2D.Raycast(vectorD  , Vector2.down );
        hitDL = Physics2D.Raycast(vectorDL, Vector2.down );
        hitDR = Physics2D.Raycast(vectorDR, Vector2.down );
            
        distanceR  = Mathf.Abs(hitR.point.x  - vectorR.x);
        distanceL  = Mathf.Abs(hitL.point.x  - vectorL.x);
        distanceD  = Mathf.Abs(hitD.point.y  - vectorD.y);
        distanceDL = Mathf.Abs(hitDL.point.y - vectorDL.y);
        distanceDR = Mathf.Abs(hitDR.point.y - vectorDR.y);
        
        SetAnimation();

        canJump  = (distanceDL <= 0.01f) || (distanceDR <= 0.01f);
        canTotem = (distanceD  <= 0.01f);
        
    }
    
    public void FixedUpdate()
    {
    }
    
    private void SetAnimation() {
        int horizontal = 0;
        
        horizontal = (int) Input.GetAxisRaw("Horizontal");
        
        if (horizontal == 1)
        {
            animator.SetTrigger("walk");
            if (!currentFacing) {
                changeFacing = true;
            }
            currentFacing = true;
        }
        else if (horizontal == -1)
        {
            animator.SetTrigger("walk");
            if (currentFacing) {
                changeFacing = true;
            }
            currentFacing = false;
        }
        else
        {
            animator.SetTrigger("stop");
        }

        if (changeFacing)
        {
            Vector2 scale = spriteRenderer.transform.localScale;
            scale.x = -scale.x;
            spriteRenderer.transform.localScale = scale;
            changeFacing = false;
        }
    }
    
    public override void MoveRight() 
    {    
        if(distanceR <= 0.01f && hitR.collider.name != "Zombie(Clone)")
        {
            if( hitR.collider.name != "EarthTotem(Clone)" && 
                hitR.collider.name != "AirTotem(Clone)"   &&
                hitR.collider.name != "WaterTotem(Clone)" &&
                hitR.collider.name != "RightTeleport")
            {
                speed = 0f;
            }
        }
        else
        {
            speed = initSpeed;
        }
        
         transform.Translate(Vector3.right * speed * Time.deltaTime);     
    }
    
    public override void MoveLeft()
    {
        
        if(distanceL <= 0.01f && hitL.collider.name != "Zombie(Clone)")
        {
            if( hitL.collider.name != "EarthTotem(Clone)" && 
                hitL.collider.name != "AirTotem(Clone)"   &&
                hitL.collider.name != "WaterTotem(Clone)" &&
                hitL.collider.name != "LeftTeleport")
            {
                speed = 0f;
            }
        }
        else
        {
            speed = initSpeed;
        }
        
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
    
    public override void Jump()
    {
        if(canJump)
        {
            rb.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
            canJump = false;
            canTotem = false;
        }
    }

    public override void FireTotem(Level level)
    {
        if(canTotem)
        {
            level.AddFireTotem();
        }
    }
    
    public override void WaterTotem(Level level)
    {
        if(canTotem)
        { 
            level.AddWaterTotem();
        }  
    }
    
    public override void EarthTotem(Level level)
    {
        if(canTotem)
        {
            level.AddEarthTotem();
        }     
    }
    
    public override void AirTotem(Level level)
    { 
        if(canTotem)
        {
           level.AddAirTotem();
        }  
    }
}
