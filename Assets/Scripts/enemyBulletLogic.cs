using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletLogic : MonoBehaviour
{
    public bool isFromLeftGun = false;
    public float speed = 1.0f;
    public float amplitude = 1.0f;
    public float frequency = 1.0f;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFromLeftGun)
        {
            float x = Mathf.Sin((transform.position.y - startPos.y) * frequency) * amplitude;
            transform.position = new Vector3(x + startPos.x, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

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
