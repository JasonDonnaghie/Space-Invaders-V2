using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletLogic : MonoBehaviour
{
    
    private playerLogic player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<playerLogic>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 5.5f){
            Destroy(gameObject);
        }
         
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.collider.tag == "Enemy"){
            player.addScore(50);
            Destroy(gameObject);
            
        }
        
    }
    void OnTriggerEnter2D(Collider2D collider){
        if (collider.name == "LeftGun"){
            player.addScore(100);
            Destroy(gameObject);
            GameObject.Find("Boss").GetComponent<bossfight>().LeftGunHealth -= 1;
            if (GameObject.Find("Boss").GetComponent<bossfight>().LeftGunHealth <= 0){
                Destroy(GameObject.Find("LeftGun"));
            }
        }

        if (collider.name == "RightGun"){
            player.addScore(100);
            Destroy(gameObject);
            GameObject.Find("Boss").GetComponent<bossfight>().RightGunHealth -= 1;
            if (GameObject.Find("Boss").GetComponent<bossfight>().RightGunHealth <= 0){
                Destroy(GameObject.Find("RightGun"));
            }
        }

        if (collider.tag == "Enemy Bullet" || collider.tag == "Enemy"){
            Destroy(gameObject);
        }
    }
}
