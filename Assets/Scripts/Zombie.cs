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
        
        distanceR  = Mathf.Abs(hitR.point.x  - vectorR.x);
        distanceL  = Mathf.Abs(hitL.point.x  - vectorL.x);

	    if (distanceR <= 0.01f && hitR.collider.name != "Player" && hitR.collider.name != "AirTotem(Clone)") {
            if(hitR.collider.name == "Whirlwind(Clone)")
            {
                Destroy(gameObject);
            }
            currentFacing = false;
            changeFacing = true;
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        
        if (distanceL <= 0.01f && hitL.collider.name != "Player" && hitL.collider.name != "AirTotem(Clone)") {
            if(hitR.collider.name == "Whirlwind(Clone)")
            {
                Destroy(gameObject);
            }
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
