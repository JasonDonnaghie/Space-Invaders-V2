using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class invadersSpawn : MonoBehaviour
{
    public GameObject objBoss;
    public GameObject objInvader;
    public float invaderSpeed = 2.0f;
    public Text winner;
    private Rigidbody2D rb;
    private int numInvaders = 0;
    private bool bossSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnInvaders();
        winner.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * invaderSpeed * Time.deltaTime);
        if (numInvaders == 0 && bossSpawned == false){
            if (objBoss != null){ 
                objBoss.gameObject.SetActive(true);
                objBoss.transform.SendMessage("callBoss");
                bossSpawned = true;
            }

        }
        
    }

    void spawnInvaders(){
        Vector2 pos;
        for (float x = -5; x < 6; x += 1.5f ){
            for (int y = 5; y < 9; y += 2){
                pos = new Vector2(x,y);
                GameObject temp = Instantiate(objInvader, pos, objInvader.transform.rotation);
                temp.transform.parent = transform;
                numInvaders++;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.tag == "Wall"){
            invaderSpeed *= -1;
            transform.Translate(Vector2.down * 10 * Time.deltaTime);
        }
    }

    void invaderDestoyed(){
        numInvaders--;
        if (invaderSpeed < 0){
            invaderSpeed -= 1.0f;
        }else{
            invaderSpeed += 1.0f;
        }
    }

    
}
