using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour
{
    private float speed = 1.4f;
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
        checkScorer = ScoreCounter.instanse.score % 261;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = enemyships[0];
        //note: 0 => blue; 1 => green 2=> lava 3=> purple
        rb = this.GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, transform.position.z));
        //rb.velocity = new Vector2(speed, 0);

    }
    private void Update()
    {
        checkScorer = ScoreCounter.instanse.score % 261;
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
        if(checkScorer >= 0 && checkScorer < 100)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = enemyships[0];
            speed = 1.4f;
        }
        else if(checkScorer > 100 && checkScorer < 160)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = enemyships[1];
            speed = 1.5f;
        }
        else if(checkScorer > 160 && checkScorer < 220)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = enemyships[2];
            speed = 1.6f;
        }
        else if(checkScorer > 220)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = enemyships[3];
            speed = 1.5f;
        }
        
    }
}
