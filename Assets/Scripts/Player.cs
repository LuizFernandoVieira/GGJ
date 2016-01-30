using UnityEngine;
using System.Collections;

public class Player : GameActor {
    
    InputHandler inputHandler;
    Command command;
    
    Rigidbody2D rb;
    
    RaycastHit2D hitL;
    RaycastHit2D hitR;
    
    float distanceRight;
    float distanceLeft;
    float speed = 3f;
    
    bool canJump  = false;
    bool canTotem = false;

    public void Awake()
    {
        inputHandler = new InputHandler();
        
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void Update()
    {
        command = inputHandler.HandleInput();
        
        if (command != null)
        {
            command.Execute(this);
        }

        Vector2 vectorRight = new Vector2(transform.position.x+0.17f, transform.position.y);
        Vector2 vectorLeft  = new Vector2(transform.position.x-0.17f, transform.position.y);
        
        hitR = Physics2D.Raycast(vectorRight, Vector2.right);
        hitL = Physics2D.Raycast(vectorLeft , Vector2.left );
            
        distanceRight = Mathf.Abs(hitR.point.x - vectorRight.x);
        distanceLeft  = Mathf.Abs(hitL.point.x - vectorLeft.x );            
    }
    
     public override void MoveRight() 
    {    
        Debug.Log("MoveRight");
        
        if(distanceRight <= 0.01f)
        {
            speed = 0f;
        }
        else
        {
            speed = 3f;
        }
        
         transform.Translate(Vector3.right * speed * Time.deltaTime);     
    }
    
    public override void MoveLeft()
    {
        Debug.Log("MoveLeft");
        
        if(distanceLeft <= 0.01f)
        {
            speed = 0f;
        }
        else
        {
            speed = 3f;
        }
        
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
    
    public override void Jump()
    {
        Debug.Log("Jump");
        if(canJump)
        {
            rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            canJump = false;
            canTotem = false;
        }
    }

    public override void FireTotem(Level level)
    {
        Debug.Log("FireTotem");
        if(canTotem)
        {
            level.AddFireTotem();
        }
    }
    
    public override void WaterTotem(Level level)
    {
        Debug.Log("WaterTotem");
        if(canTotem)
        { 
            level.AddWaterTotem();
        }  
    }
    
    public override void EarthTotem(Level level)
    {
        Debug.Log("EarthTotem");
        if(canTotem)
        {
            level.AddEarthTotem();
        }     
    }
    
    public override void AirTotem(Level level)
    {
         Debug.Log("AirTotem");  
        if(canTotem)
        {
           level.AddAirTotem();
        }  
    }
   
    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Ground")
        {
            canJump = true;
            canTotem = true;
        }
    }
}
