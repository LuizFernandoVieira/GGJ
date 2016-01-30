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
            Input.GetKeyDown(KeyCode.D))
        {
            return move_right;
        }
        
        //  WALK LEFT
        if (Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKeyDown(KeyCode.A))
        {
            return move_left;
        }
        
        //  FIRE TOTEM
        if (Input.GetKey(KeyCode.H) ||
            Input.GetKey(KeyCode.Alpha1))
        {
            return fire;
        }
        
        //  WATER TOTEM
        if (Input.GetKey(KeyCode.J) ||
            Input.GetKey(KeyCode.Alpha2))
        {
            return water;
        }
        
        //  EARTH TOTEM
        if (Input.GetKey(KeyCode.K) ||
            Input.GetKey(KeyCode.Alpha3))
        {
            return earth;
        }
        
        //  AIR TOTEM
        if (Input.GetKey(KeyCode.L) ||
            Input.GetKey(KeyCode.Alpha4))
        {
            return air;
        }
        
        return null;
    }

}
