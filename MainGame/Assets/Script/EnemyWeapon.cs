using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    private ObjectPooler bulletPooler;
    public Transform FirePoint;

    private void Awake()
    {
        bulletPooler = GameObject.Find("EnemBulletPooler").GetComponent<ObjectPooler>();
    }
    private void OnEnable()
    {
        Invoke("Shoot", 0.1f);
        
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
    private void Start()
    {
        bulletPooler = GameObject.Find("EnemBulletPooler").GetComponent<ObjectPooler>();
        //Invoke("Shoot", 1f);
    }

    private void Shoot()
    {
        /*GameObject player = GameObject.Find("Player");
        if(player != null)
        {
            GameObject bullet1 = bulletPooler.GetPooledObject();
            if(bullet1 == null) return;
        
            bullet1.transform.position = transform.position;
            Vector2 direction = player.transform.position - bullet1.transform.position;
            bullet1.GetComponent<EnemyBullet>().EnemyBulletDirection(direction);
            bullet1.transform.rotation = transform.rotation;
            bullet1.SetActive(true);
        }*/

        GameObject bullet1 = bulletPooler.GetPooledObject();
        if(bullet1 == null) return;
        bullet1.transform.position = FirePoint.position;
        bullet1.transform.rotation = FirePoint.rotation;
        bullet1.SetActive(true);

    }

}
