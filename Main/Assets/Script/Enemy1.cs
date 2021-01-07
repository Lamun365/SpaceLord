using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float speed;
    public float delayDis;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    public Sprite[] enemyships;
    private float checkScorer;


    private void OnEnable()
    {
        if(rb != null)
        {
            //rb.velocity = new Vector2(speed, 0);
            
        }
        EnemyCamp();
        Invoke("Disable", delayDis);
    }
    private void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = enemyships[2];
        checkScorer = ScoreCounter.instanse.score % 41;
        //note: 0 => blue; 1 => green 2=> lava 3=> purple
        rb = this.GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, transform.position.z));
        //rb.velocity = new Vector2(speed, 0);

    }
    private void Update()
    {
        checkScorer = ScoreCounter.instanse.score % 41;
        Vector2 currentPos= transform.position;
        currentPos = new Vector2(currentPos.x - speed * Time.deltaTime, currentPos.y);
        transform.position = currentPos;
        if(transform.position.y >= screenBounds.y - (screenBounds.y-3.26f))
        {
            this.gameObject.SetActive(false);
        }
        //EnemyCamp();
    }

    private void Disable()
    {
        if(transform.position.x <= screenBounds.x)
        {
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
            
        }
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            PlayerController.health -= 1;
            this.gameObject.SetActive(false);
        }

    }
    private void EnemyCamp()
    {
        //for enemy Changing
        if(checkScorer >= 0 && checkScorer < 10 )
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = enemyships[0];
            speed = 2;
        }
        else if(checkScorer > 10 && checkScorer < 20)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = enemyships[1];
            speed = 2.2f;
        }
        else if(checkScorer > 20 && checkScorer < 30)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = enemyships[2];
            speed = 2.5f;
        }
        else if(checkScorer > 30)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = enemyships[3];
            speed = 2.9f;
        }
        
    }
}
