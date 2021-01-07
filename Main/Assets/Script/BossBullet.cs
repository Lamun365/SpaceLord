using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed_x, speed_y;
    //private Vector2 _direction;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    private void OnEnable()
    {
        if(rb != null)
        {
            rb.velocity = new Vector2(-speed_x, speed_y);
        }
        Invoke("Disable", 4f);
    }
    private void Start()
    {
        //explosionPooler = GameObject.Find("ExplosionPooler").GetComponent<ObjectPooler>();
        rb = this.GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, transform.position.z));
        rb.velocity = new Vector2(-speed_x, speed_y);

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

        }
    }
}
