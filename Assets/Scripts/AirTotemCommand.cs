using UnityEngine;
using System.Collections;

public class AirTotemCommand : Command {

	public override void Execute(GameActor ga)
    {
        ga.AirTotem(level);
    }
    
}
