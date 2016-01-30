using UnityEngine;
using System.Collections;

public class WaterTotemCommand : Command {

	public override void Execute(GameActor ga)
    {
        ga.WaterTotem(level);
    }
    
}
