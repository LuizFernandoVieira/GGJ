using UnityEngine;
using System.Collections;

public class Player : GameActor {
    
    InputHandler inputHandler;
    Command command;

    public void Awake()
    {
        inputHandler = new InputHandler();
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
    }
    
    public override void MoveLeft()
    {
        Debug.Log("MoveLeft");
    }
    
    public override void Jump()
    {
        Debug.Log("Jump");
    }

    public override void FireTotem()
    {
        Debug.Log("FireTotem");        
    }
    
    public override void WaterTotem()
    {
        Debug.Log("WaterTotem");       
    }
    
    public override void EarthTotem()
    {
        Debug.Log("EarthTotem");         
    }
    
    public override void AirTotem()
    {
         Debug.Log("AirTotem");        
    }
   
    
}
