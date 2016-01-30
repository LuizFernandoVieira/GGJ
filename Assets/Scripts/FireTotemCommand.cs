using UnityEngine;
using System.Collections;

public class FireTotemCommand : Command {

	public override void Execute(GameActor ga)
    {
        ga.FireTotem(level);
    }
    
}
