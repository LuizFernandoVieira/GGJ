using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
    
}
