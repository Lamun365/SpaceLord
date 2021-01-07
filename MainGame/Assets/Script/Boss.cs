using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Sprite[] bossShips;
    public float speed;
    //public float delayDis;
    private Rigidbody2D rb;
    private float checkScorer;
    private Vector2 screenBounds;
    //private float checkScorer;
    public int bossLife = 100;
    public GameObject bossGun;
    private GameObject poolingObject;


    /*private void OnEnable()
    {
        if(rb != null)
        {
            //rb.velocity = new Vector2(speed, 0);
            
        }

        Invoke("Disable", delayDis);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }*/
    private void Start()
    {
        poolingObject = GameObject.Find("ExplosionPooler3");
        checkScorer = ScoreCounter.instanse.score % 361;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = bossShips[2]; //finally change it to blue
        //note: 0 => blue; 1 => green 2=> lava 3=> purple
        rb = this.GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, transform.position.z));
        //rb.velocity = new Vector2(speed, 0);

    }
    private void OnEnable()
    {
        EnemyCamp();
    }
    private void Update()
    {
        checkScorer = ScoreCounter.instanse.score % 361;
        /*Vector2 currentPos= transform.position;
        currentPos = new Vector2(currentPos.x - speed * Time.deltaTime, currentPos.y);
        transform.position = currentPos;
        if(transform.position.y >= screenBounds.y - (screenBounds.y-3.26f))
        {
            this.gameObject.SetActive(false);
        }*/
        if(transform.position.x > 0.87f)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        /*if(transform.position.x == 0.87f)
        {
            rb.velocity = new Vector2(0, 0);
        }*/
        if(transform.position.x < 0.87f)
        {
            //transform.position = new Vector2(0.8699f, transform.position.y);
            rb.velocity = new Vector2(0, 0);
        }
        //life managing
        if(bossLife <= 0)
        {
            this.gameObject.SetActive(false);
            PlayExplosion();
            bossLife += 100;
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            PlayerController.health -= 1;
            bossLife -= 1;
        }
        if(other.gameObject.tag == "Bullets")
        {
            other.gameObject.SetActive(false);
            bossLife -= 1;
            Debug.Log("life boss:" + bossLife);
        }

    }
    private void EnemyCamp()
    {
        //for enemy Changing
        if(checkScorer >= (80 - 40) && checkScorer < (80*2) + 1)//60
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = bossShips[0];
            bossGun.GetComponent<Boss1Weapon>().enabled = true;
            bossGun.GetComponent<Boss2Weapon>().enabled = false;
            bossGun.GetComponent<Boss3Weapon>().enabled = false;
            bossGun.GetComponent<Boss4Weapon>().enabled = false;
        }
        else if(checkScorer > (80*2) + 1 && checkScorer < (80*3) - 1)//121
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = bossShips[1];
            bossGun.GetComponent<Boss1Weapon>().enabled = false;
            bossGun.GetComponent<Boss2Weapon>().enabled = true;
            bossGun.GetComponent<Boss3Weapon>().enabled = false;
            bossGun.GetComponent<Boss4Weapon>().enabled = false;
        }
        else if(checkScorer > (80*3) + 2 && checkScorer < (80*4) + 3)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = bossShips[2];
            bossGun.GetComponent<Boss1Weapon>().enabled = false;
            bossGun.GetComponent<Boss2Weapon>().enabled = false;
            bossGun.GetComponent<Boss3Weapon>().enabled = true;
            bossGun.GetComponent<Boss4Weapon>().enabled = false;
        }
        else if(checkScorer > (80*4) + 3)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = bossShips[3];
            bossGun.GetComponent<Boss1Weapon>().enabled = false;
            bossGun.GetComponent<Boss2Weapon>().enabled = false;
            bossGun.GetComponent<Boss3Weapon>().enabled = false;
            bossGun.GetComponent<Boss4Weapon>().enabled = true;
        }
    }
    private void PlayExplosion()
    {
        GameObject explosion = poolingObject.GetComponent<ObjectPooler>().GetPooledObject();
        if(explosion == null) return;
        explosion.transform.position = transform.position;
        explosion.transform.rotation = transform.rotation;
        explosion.SetActive(true);
    }
    /*private void BossManager()
    {
        if(checkScorer >= (80 - 40) && checkScorer < (80*2) + 1)
        {
            bossLife += 100;
        }
        else if(checkScorer > (80*2) + 1 && checkScorer < (80*3) - 1)
        {
            bossLife += 100;
        }
        else if(checkScorer > (80*3) + 2 && checkScorer < (80*4) + 3)
        {
            bossLife += 100;
        }
        else if(checkScorer > (80*4) + 3)
        {
            bossLife += 100;
        } 
    }*/
}
