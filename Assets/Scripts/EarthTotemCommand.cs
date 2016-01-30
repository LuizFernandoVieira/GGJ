using UnityEngine;
using System.Collections;

public class EarthTotemCommand : Command {

	public override void Execute(GameActor ga)
    {
        ga.EarthTotem(level);
    }
    
}
