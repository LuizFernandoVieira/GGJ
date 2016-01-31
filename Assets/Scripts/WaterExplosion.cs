using UnityEngine;
using System.Collections;

public class WaterExplosion : MonoBehaviour {
	    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }  
    
}
