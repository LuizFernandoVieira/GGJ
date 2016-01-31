using UnityEngine;
using System.Collections;

public class IAWaterTotem : MonoBehaviour {
    
    public GameObject waterExplosion;
    
	void Awake () {
        Invoke("CreateExplosion", 2);
	}
    
    public void CreateExplosion()
    {
        GameObject clone = Instantiate (waterExplosion, this.transform.position, Quaternion.identity) as GameObject;
        GameObject.Destroy(clone, 1);
        Destroy(gameObject);
    }
}
