using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invaderLogic : MonoBehaviour
{
    public GameObject objEnemyBullet;

    public float maxWait,minWait;
    public GameObject objExplosion;
    private float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = UnityEngine.Random.Range(minWait,maxWait);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0){
            invaderShoot();
            spawnTimer = UnityEngine.Random.Range(minWait,maxWait);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.collider.tag == "Bullet"){
            Instantiate(objExplosion,transform.position,transform.rotation);
            transform.parent.SendMessage("invaderDestoyed");
            Destroy(gameObject);
            
        }

    }

    void invaderShoot(){
        Vector2 temp = new Vector2(transform.position.x - 0.05f, transform.position.y);
        GameObject p = Instantiate(objEnemyBullet, temp, objEnemyBullet.transform.rotation);
        p.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-4);
        
    }
}
