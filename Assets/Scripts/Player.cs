using UnityEngine;
using System.Collections;

public class Player : GameActor {
    
    InputHandler inputHandler;
    Command command;
    
    Rigidbody2D rb;
    
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
    }
    
     public override void MoveRight() 
    {    
         Debug.Log("MoveRight");
         transform.Translate(Vector3.right * 3 * Time.deltaTime);              
    }
    
    public override void MoveLeft()
    {
        Debug.Log("MoveLeft");
        transform.Translate(-Vector3.right * 3 * Time.deltaTime);
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
