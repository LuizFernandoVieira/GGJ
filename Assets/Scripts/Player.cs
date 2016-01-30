﻿using UnityEngine;
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

        Vector2 vectorR  = new Vector2(transform.position.x+0.17f, transform.position.y);
        Vector2 vectorL  = new Vector2(transform.position.x-0.17f, transform.position.y);
        Vector2 vectorD  = new Vector2(transform.position.x      , transform.position.y-0.17f);
        Vector2 vectorDL = new Vector2(transform.position.x-0.16f, transform.position.y-0.17f);
        Vector2 vectorDR = new Vector2(transform.position.x+0.16f, transform.position.y-0.17f);
        
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
        
        canJump  = (distanceDL <= 0.01f) || (distanceDR <= 0.01f);
        canTotem = (distanceD  <= 0.01f);
    }
    
     public override void MoveRight() 
    {    
        Debug.Log("MoveRight");
        
        if(distanceR <= 0.01f)
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
        
        if(distanceL <= 0.01f)
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
}