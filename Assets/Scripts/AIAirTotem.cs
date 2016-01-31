using UnityEngine;
using System.Collections;

public class AIAirTotem : MonoBehaviour {
    
    public GameObject tornato;
    
    bool goingRight = false;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject clone = Instantiate (tornato, this.transform.position, Quaternion.identity) as GameObject;
            GameObject.Destroy(clone, 2);
            Destroy(gameObject);
        }
    }
}
