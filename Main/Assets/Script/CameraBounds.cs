using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    private float maxWeight;
    private float maxHeight;

    private Vector2 screenBounds;

    private float playerWidth, playerHeight;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, transform.position.z));
        playerWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x;
        playerHeight= transform.GetComponent<SpriteRenderer>().bounds.size.y;
        maxHeight = screenBounds.y - playerHeight/2;
        maxWeight = screenBounds.x - playerWidth/2;
    }
    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -maxWeight, maxWeight), Mathf.Clamp(transform.position.y, -maxHeight, maxHeight), transform.position.z);

    }
    /*private Vector2 screenBounds;
    private float playerWidth;
    private float playerHeight;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, transform.position.z));
        playerWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        playerHeight= transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + playerWidth, screenBounds.x * -1 - playerWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + playerHeight, screenBounds.y * -1 - playerHeight);
        transform.position = viewPos;
    } */
}
