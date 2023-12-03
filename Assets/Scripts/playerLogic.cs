using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class playerLogic : MonoBehaviour
{   
    //Input buttons
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode shootGun = KeyCode.Space;
    public float playerSpeed;
    public GameObject objBullet;
    public Text livesLeft;
    private int playerLives = 3;
    public Text textScore;
    private int playerScore = 0;
    private Rigidbody2D rb;
    public Text gameOver;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1;
        gameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        playerShoot();
        if (playerLives == 0){
            gameOver.gameObject.SetActive(true);
            Invoke("reloadGame",3f);
            playerSpeed = 0;

        }
    }

    void playerMovement(){
        if (Input.GetKey(moveRight)){
            rb.velocity = new Vector2(playerSpeed,0);
        }else if(Input.GetKey(moveLeft)){
            rb.velocity = new Vector2(-playerSpeed,0);
        }else{
            rb.velocity = new Vector2(0,0);
        }
    }

    void playerShoot(){
        Vector2 force = new Vector2(0,4);
        if (Input.GetKeyDown(shootGun)){
            Vector2 pos = new Vector2(transform.position.x - 0.05f, transform.position.y + 0.5f);
            GameObject temp = Instantiate(objBullet, pos, objBullet.transform.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = force;
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.tag == "Enemy Bullet"){
            playerLives --;
            livesLeft.text = "Lives:" + " " + playerLives.ToString();
        }
    }
    public void addScore(int score){
        playerScore += score;
        textScore.text = "Score: " + playerScore;

    }

    private void reloadGame(){
        SceneManager.LoadScene("StartMenu");
    }
}
