using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

    private SpriteRenderer spriteRenderer;

    bool currentFacing = true;
    bool changeFacing = true;
    
    RaycastHit2D hitL;
    RaycastHit2D hitR;
    
    float distanceL;
    float distanceR;
    
    float speed = 1f;

    void Awake () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameObject player = GameObject.Find("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 vectorR  = new Vector2(transform.position.x+0.17f, transform.position.y);
        Vector2 vectorL  = new Vector2(transform.position.x-0.17f, transform.position.y);

        hitR = Physics2D.Raycast(vectorR  , Vector2.right);
        hitL = Physics2D.Raycast(vectorL  , Vector2.left );
        
        bool ignore = false;
        
        if (hitR.collider != null && hitR.collider.attachedRigidbody != null)
        {
            if(hitR.collider.attachedRigidbody.name == "Player") {
                ignore = true;
            }
        }

        if (hitL.collider != null && hitL.collider.attachedRigidbody != null)
        {
            if(hitL.collider.attachedRigidbody.name == "Player") {
                ignore = true;
            }
        }

        distanceR  = Mathf.Abs(hitR.point.x  - vectorR.x);
        distanceL  = Mathf.Abs(hitL.point.x  - vectorL.x);

	    if (distanceR <= 0.01f && !ignore) {
            currentFacing = false;
            changeFacing = true;
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        
        if (distanceL <= 0.01f && !ignore) {
            currentFacing = true;
            changeFacing = true;
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        
        if (currentFacing) 
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        
        SetAnimation();
	}
    
    private void SetAnimation() {
        if (changeFacing)
        {
            Vector2 scale = spriteRenderer.transform.localScale;
            scale.x = -scale.x;
            spriteRenderer.transform.localScale = scale;
            changeFacing = false;
            speed = 1f;
        }
    }
}
