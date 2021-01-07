using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    //private Vector2 _direction;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    //private bool bulletEnter;

    private void OnEnable()
    {
        if(rb != null)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        Invoke("Disable", 4f);
    }
    private void Start()
    {
        //explosionPooler = GameObject.Find("ExplosionPooler").GetComponent<ObjectPooler>();
        rb = this.GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, transform.position.z));
        rb.velocity = new Vector2(-speed, 0);

    }
    private void Update()
    {
        //Movement();
        if(transform.position.y >= screenBounds.y - (screenBounds.y-3.26f))
        {
            this.gameObject.SetActive(false);
        }
    }
    private void Disable()
    {
        this.gameObject.SetActive(false);
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
        if(other.gameObject.name == "Player")
        {
            PlayerController.health -= 1;
            this.gameObject.SetActive(false);
            /*if(bulletEnter)
            {
                bulletEnter = false;
            }
            if(bulletEnter == false)
            {
                bulletEnter = true;
            }*/

        }
    }

    /*public void EnemyBulletDirection(Vector2 direction)
    {
        _direction = direction.normalized;
        
    }*/
    /*private void Movement()
    {
        Vector2 position = transform.position;
        position += _direction * speed * Time.deltaTime;
        transform.position = position;
    }*/

}
