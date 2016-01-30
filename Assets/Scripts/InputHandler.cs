using UnityEngine;
using System.Collections;

public class InputHandler {
    
    Command jump            = new JumpCommand();
    Command move_left       = new MoveCommand(0);
    Command move_right      = new MoveCommand(1);
    Command fire            = new FireTotemCommand();
    Command water           = new WaterTotemCommand();
    Command earth           = new EarthTotemCommand();
    Command air             = new AirTotemCommand();

    public Command HandleInput() 
    {
        //  JUMP
        if (Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.UpArrow))
        {
            return jump;
        }
        
        //  WALK RIGHT
        if (Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.D))
        {
            return move_right;
        }
        
        //  WALK LEFT
        if (Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.A))
        {
            return move_left;
        }
        
        //  FIRE TOTEM
        if (Input.GetKeyDown(KeyCode.H) ||
            Input.GetKeyDown(KeyCode.Alpha1))
        {
            return fire;
        }
        
        //  WATER TOTEM
        if (Input.GetKeyDown(KeyCode.J) ||
            Input.GetKeyDown(KeyCode.Alpha2))
        {
            return water;
        }
        
        //  EARTH TOTEM
        if (Input.GetKeyDown(KeyCode.K) ||
            Input.GetKeyDown(KeyCode.Alpha3))
        {
            return earth;
        }
        
        //  AIR TOTEM
        if (Input.GetKeyDown(KeyCode.L) ||
            Input.GetKeyDown(KeyCode.Alpha4))
        {
            return air;
        }
        
        return null;
    }

}
