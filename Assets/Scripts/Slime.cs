using UnityEngine;
using System.Collections;

public class Slime : MonoBehaviour {
    public GameObject saplin;
    
    private SpriteRenderer spriteRenderer;

    bool currentFacing = true;
    
    bool goUp = false;
    
    bool canJump = false;
    
    RaycastHit2D hitL;
    RaycastHit2D hitR;
    RaycastHit2D hitD;
    
    float distanceL;
    float distanceR;
    float distanceD;
    
    float speed = 1f;
    
    private Rigidbody2D rb;
    
    void Awake () {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameObject player = GameObject.Find("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Invoke("Jump", 3);
        canJump = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (saplin == null) {
            saplin = GameObject.Find("Saplin(Clone)");
        } else {
            if (transform.position.y < saplin.transform.position.y) {
                goUp = true;
            } else {
                goUp = false;
            }
        }
        
        Vector2 vectorR  = new Vector2(transform.position.x+0.17f, transform.position.y);
        Vector2 vectorL  = new Vector2(transform.position.x-0.17f, transform.position.y);
        Vector2 vectorD  = new Vector2(transform.position.x, transform.position.y+0.17f);

        hitR = Physics2D.Raycast(vectorR  , Vector2.right);
        hitL = Physics2D.Raycast(vectorL  , Vector2.left );
        hitD = Physics2D.Raycast(vectorD  , Vector2.down );
        
        if (hitR.collider.name == "Zombie(Clone)") {
            Physics2D.IgnoreCollision(hitR.collider, GetComponent<Collider2D>());
        }
        
        if (hitL.collider.name == "Zombie(Clone)") {
            Physics2D.IgnoreCollision(hitL.collider, GetComponent<Collider2D>());
        }
        
        if (hitD.collider.name == "Zombie(Clone)") {
            Physics2D.IgnoreCollision(hitD.collider, GetComponent<Collider2D>());
        }
        
        distanceR  = Mathf.Abs(hitR.point.x  - vectorR.x);
        distanceL  = Mathf.Abs(hitL.point.x  - vectorL.x);
        
	    if (distanceR <= 0.01f && 
                hitR.collider.name != "Player" && 
                hitR.collider.name != "AirTotem(Clone)" && 
                hitR.collider.name != "FireTotem(Clone)" && 
                hitR.collider.name != "Zombie(Clone)") {
            if(hitR.collider.name == "Whirlwind(Clone)")
            {
                Destroy(gameObject);
            }
            currentFacing = true;
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            SetAnimation();
        }
        
        if (distanceL <= 0.01f && 
                hitL.collider.name != "Player" && 
                hitL.collider.name != "AirTotem(Clone)" && 
                hitL.collider.name != "FireTotem(Clone)" && 
                hitL.collider.name != "Zombie(Clone)") {
            if(hitL.collider.name == "Whirlwind(Clone)")
            {
                Destroy(gameObject);
            }
            currentFacing = false;
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            SetAnimation();
        }
        
        if (!currentFacing) 
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
	}
    
    private void SetAnimation() {
        Vector2 scale = spriteRenderer.transform.localScale;
        scale.x = -scale.x;
        spriteRenderer.transform.localScale = scale;
    }
    
    public void Jump()
    {
        if(canJump)
        {
            rb.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
            canJump = false;
        }
    }

}
