using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5.5f){
            Destroy(gameObject);
        }
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.tag == "Player" || collider.tag == "Bullet"){
            Destroy(gameObject);
        }
        
    }
}
