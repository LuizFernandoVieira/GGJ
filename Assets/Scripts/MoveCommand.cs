using UnityEngine;
using System.Collections;

public class MoveCommand : Command {
    
    bool moveRight = false;
    
    public MoveCommand(int num)
    {
        if (num == 1)
        {
            moveRight = true;
        }
    }

	public override void Execute(GameActor ga)
    {
        if(moveRight)
        {
            ga.MoveRight();
        }
        else
        {
            ga.MoveLeft();    
        }
    }
}
