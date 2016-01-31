using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {
    
    public float speed = 3;
    public bool facingRight = false;
    
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime); 
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
    
}
