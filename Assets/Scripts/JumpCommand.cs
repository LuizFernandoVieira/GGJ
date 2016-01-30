using UnityEngine;
using System.Collections;

public class JumpCommand : Command {

	public override void Execute(GameActor ga)
    {
        ga.Jump();
    }
    
}