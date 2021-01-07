using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public ObjectPooler[] ObjectPooler;
    public Transform firePoint1, firePoint2, firePoint3, firePoint4;
    public ObjectPooler[] asterPooler;
    public float asterTimer;
    private bool isFiring = false;
    private AudioSource audioSource;
    public AudioClip fire;
    
    

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        InvokeRepeating("AsteroidManager", 5f, asterTimer);
    }

    // Update is called once per frame
    void Update()
    {
        //computer
        /*
        if(Input.GetKey("f"))
        {
            Shoot();
        }
        */

        //mobile
        if(isFiring == true)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        //play shoot audio
        //shooting bullet
        //Object pooler 1
        GameObject bullet1 = ObjectPooler[0].GetPooledObject();
        if(bullet1 == null) return;
        
        bullet1.transform.position = firePoint1.position;
        bullet1.transform.rotation = firePoint1.rotation;
        bullet1.SetActive(true);
        //Object pooler 2
        GameObject bullet2 = ObjectPooler[1].GetPooledObject();
        if(bullet2 == null) return;
        
        bullet2.transform.position = firePoint2.position;
        bullet2.transform.rotation = firePoint2.rotation;
        bullet2.SetActive(true);
        //Object pooler3
        GameObject bullet3 = ObjectPooler[2].GetPooledObject();
        if(bullet3 == null) return;
        
        bullet3.transform.position = firePoint3.position;
        bullet3.transform.rotation = firePoint3.rotation;
        bullet3.SetActive(true);
        //Object pooler 4
        GameObject bullet4 = ObjectPooler[3].GetPooledObject();
        if(bullet4 == null) return;
        
        bullet4.transform.position = firePoint4.position;
        bullet4.transform.rotation = firePoint4.rotation;
        bullet4.SetActive(true);
        
        /*Instantiate(bulletprefab1, firePoint1.position, firePoint1.rotation);
        Instantiate(bulletprefab1, firePoint2.position, firePoint2.rotation);
        Instantiate(bulletprefab1, firePoint3.position, firePoint3.rotation);
        Instantiate(bulletprefab1, firePoint4.position, firePoint4.rotation); */
    }
    private void AsteroidManager()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        GameObject asteroid1 = asterPooler[0].GetPooledObject();
        if(asteroid1 == null) return;
        asteroid1.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));
        asteroid1.SetActive(true);
    
        //ScheduleAsterSpawn();
    }
    public void PointerDown()
    {
        isFiring = true;
    }
    public void PointerUp()
    {
        isFiring = false;
    }
    public void FireAudio()
    {
        audioSource.PlayOneShot(fire);
    }
    /*private void ScheduleAsterSpawn()
    {
        float spawnInSeconds;
        if(asterMaxSpawnRate > 1f)
        {
            spawnInSeconds = Random.Range(1f, asterMaxSpawnRate);
        }
        else
        {
            spawnInSeconds = 1f;
            Invoke("AsteroidManager", spawnInSeconds);
        }
    }
    private void IncreaseAsterSpawnRate()
    {
        if(asterMaxSpawnRate > 1f)
        {
            asterMaxSpawnRate--;
        }
        if(asterMaxSpawnRate == 1f)
        {
            CancelInvoke("IncreaseAsterSpawnRate");
        }
    }*/

}
