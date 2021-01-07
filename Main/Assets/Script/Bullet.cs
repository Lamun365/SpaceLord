using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private GameObject poolingObject; //for explosion pooler
    //public ObjectPooler explosionPooler;

    private void OnEnable()
    {
        if(rb != null)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        Invoke("Disable", 2f);
    }
    private void Start()
    {
        poolingObject = GameObject.Find("ExplosionPooler");
        //explosionPooler = GameObject.Find("ExplosionPooler").GetComponent<ObjectPooler>();
        rb = this.GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, transform.position.z));
        rb.velocity = new Vector2(speed, 0);

    }

    private void Disable()
    {
        if(transform.position.x >= screenBounds.x)
        {
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
        if(other.gameObject.tag == "Asteroid")
        {
            PlayExplosion();
            other.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
        if(other.gameObject.tag == "Enemy")
        {
            PlayExplosion();
            other.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
        if(other.gameObject.tag == "Boss")
        {
            ScoreCounter.instanse.score += 5;
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
}
