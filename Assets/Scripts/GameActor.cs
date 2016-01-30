using UnityEngine;
using System.Collections;

public abstract class GameActor : MonoBehaviour {

    public abstract void MoveRight();
    
    public abstract void MoveLeft();

	public abstract void Jump();
    
    public abstract void FireTotem();
    
    public abstract void WaterTotem();
    
    public abstract void EarthTotem();
    
    public abstract void AirTotem();
}
