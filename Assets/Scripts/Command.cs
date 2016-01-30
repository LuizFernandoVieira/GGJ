using UnityEngine;
using System.Collections;

public abstract class Command {

    protected GameObject levelObj;
    protected Level level;
    
    public Command()
    {
        levelObj = GameObject.Find("Level");
        if (levelObj != null)
        {
            level = levelObj.GetComponent<Level>();   
        }
    }
    
	public abstract void Execute(GameActor ga);
    
}