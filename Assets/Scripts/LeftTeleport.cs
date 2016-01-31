using UnityEngine;
using System.Collections;

public class LeftTeleport : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject player = GameObject.Find("Player");
            if(player != null)
            {
                player.transform.position = new Vector2(3.04f, 0f);   
            }            
        }   
    }

}
