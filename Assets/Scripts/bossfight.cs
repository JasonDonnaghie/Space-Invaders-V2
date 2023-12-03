using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class bossfight : MonoBehaviour
{
    
    public GameObject bossBullet;
    public float maxWait,minWait;
    private Rigidbody2D rb;
    public float bossSpeed = 1.0f;
    public int bossHealth = 9;
    public int LeftGunHealth = 2;
    public int RightGunHealth = 2;
    private float shootBoss, shootLeft, shootRight;
    public GameObject LeftGun;
    public GameObject RightGun;
    public Text winner;
    

    

    // Start is called before the first frame update
    void Start()
    {   
        shootBoss = UnityEngine.Random.Range(minWait,maxWait);
        shootLeft = UnityEngine.Random.Range(minWait,maxWait);
        shootRight = UnityEngine.Random.Range(minWait,maxWait);
        gameObject.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        shootBoss -= Time.deltaTime;
        if (shootBoss <= 0){
            bossShoot();
            shootBoss = UnityEngine.Random.Range(minWait,maxWait);
        }
        
        shootLeft -= Time.deltaTime;
        if (shootLeft <= 0){
            Vector2 temp = new Vector2(LeftGun.transform.position.x - 0.05f, LeftGun.transform.position.y);
            GameObject p = Instantiate(bossBullet, temp, bossBullet.transform.rotation);
            p.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-4);
            shootLeft = UnityEngine.Random.Range(minWait,maxWait);
        }

        shootRight -= Time.deltaTime;
        if (shootRight <= 0){
            Vector2 temp = new Vector2(RightGun.transform.position.x - 0.05f, RightGun.transform.position.y);
            GameObject p = Instantiate(bossBullet, temp, bossBullet.transform.rotation);
            p.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-4);
            shootRight = UnityEngine.Random.Range(minWait,maxWait);
        }

        


        if (transform.position.y <= 2.3f){
            rb.velocity = new Vector2(0,0);
        }
        
    }
    

    void bossShoot(){
        Vector2 temp = new Vector2(transform.position.x - 0.05f, transform.position.y);
        GameObject p = Instantiate(bossBullet, temp, bossBullet.transform.rotation);
        p.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-4);    
    }

    public void callBoss(){
        
        rb.velocity = new Vector2(0,-bossSpeed);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Bullet" && gameObject.name == "Boss"){
            bossHealth -= 1;
            if (bossHealth <= 0){
            winner.gameObject.SetActive(true);
            Destroy(gameObject);
            reloadGame();
            }
        }
    }

    private void reloadGame(){
        StartCoroutine(waiter());
        SceneManager.LoadScene("StartMenu");
    }
    
    IEnumerator waiter()
    {   
        yield return new WaitForSeconds(3);
        reloadGame();
    }

}
