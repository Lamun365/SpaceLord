using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids: MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    public float delay;

    private void OnEnable()
    {
        if(rb != null)
        {
            //rb.velocity = new Vector2(speed, 0);
            
        }
        Invoke("Disable", delay);
    }
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, transform.position.z));
        //rb.velocity = new Vector2(speed, 0);

    }
    private void Update()
    {
        Vector2 currentPos= transform.position;
        currentPos = new Vector2(currentPos.x - speed * Time.deltaTime, currentPos.y);
        transform.position = currentPos;
        if(transform.position.y >= screenBounds.y - (screenBounds.y-3.26f))
        {
            this.gameObject.SetActive(false);
        }
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
}
