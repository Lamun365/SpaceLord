using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Weapon : MonoBehaviour
{
    private ObjectPooler bulletPooler, bulletPooler1, bulletPooler2;
    public Transform[] firePoint;

    private void Awake()
    {
        bulletPooler = GameObject.Find("EnemBulletPooler").GetComponent<ObjectPooler>();
        bulletPooler1 = GameObject.Find("BossBulletPol1").GetComponent<ObjectPooler>();
        bulletPooler2 = GameObject.Find("BossBulletPol2").GetComponent<ObjectPooler>();
    }
    /*private void OnEnable()
    {
        Invoke("BosShoot", 0.1f);
        
    }
    private void OnDisable()
    {
        CancelInvoke();
    }*/
    private void Start()
    {
        bulletPooler = GameObject.Find("EnemBulletPooler").GetComponent<ObjectPooler>();
        bulletPooler1 = GameObject.Find("BossBulletPol1").GetComponent<ObjectPooler>();
        bulletPooler2 = GameObject.Find("BossBulletPol2").GetComponent<ObjectPooler>();
        //Invoke("Shoot", 1f);
    }
    private void Update()
    {
        Invoke("BosShoot", 2f);
    }
    private void BosShoot()
    {
        //1st bullet
        GameObject bosBul1 = bulletPooler1.GetPooledObject();
        if(bosBul1 == null) return;
        bosBul1.transform.position = firePoint[0].position;
        bosBul1.transform.rotation = firePoint[0].rotation;
        bosBul1.SetActive(true);

        //2nd bullet
        GameObject bosBul2 = bulletPooler.GetPooledObject();
        if(bosBul2 == null) return;
        bosBul2.transform.position = firePoint[1].position;
        bosBul2.transform.rotation = firePoint[1].rotation;
        bosBul2.SetActive(true);
        //3rd bullet
        GameObject bosBul3 = bulletPooler2.GetPooledObject();
        if(bosBul3 == null) return;
        bosBul3.transform.position = firePoint[2].position;
        bosBul3.transform.rotation = firePoint[2].rotation;
        bosBul3.SetActive(true);
    }
}
