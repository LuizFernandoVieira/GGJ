using UnityEngine;
using System.Collections;

public abstract class GameActor : MonoBehaviour {

    public abstract void MoveRight();
    
    public abstract void MoveLeft();

	public abstract void Jump();
    
    public abstract void FireTotem(Level level);
    
    public abstract void WaterTotem(Level level);
    
    public abstract void EarthTotem(Level level);
    
    public abstract void AirTotem(Level level);
}
