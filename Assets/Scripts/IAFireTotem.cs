using UnityEngine;
using System.Collections;

public class IAFireTotem : MonoBehaviour {
    
    public GameObject fireBall;
    
    void CreateFireBallRight()
    {   
        GameObject clone = Instantiate (fireBall, this.transform.position, Quaternion.identity) as GameObject;   
    }
    
    void CreateFireBallLeft()
    {   
        GameObject clone = Instantiate (fireBall, this.transform.position, Quaternion.AngleAxis(180, Vector3.up)) as GameObject;   
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {   
            if(other.transform.position.x > this.transform.position.x)
            {
                CreateFireBallRight();
            }
            
            if(other.transform.position.x < this.transform.position.x)
            {
                CreateFireBallLeft();
            }
        }
    }
}
