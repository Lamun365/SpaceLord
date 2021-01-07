using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Weapon : MonoBehaviour
{
    private ObjectPooler bulletPooler;
    public Transform FirePoint1;

    private void Awake()
    {
        bulletPooler = GameObject.Find("EnemBulletPooler").GetComponent<ObjectPooler>();
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
        //Invoke("Shoot", 1f);
    }
    private void Update()
    {
        Invoke("BosShoot", 2f);
    }
    private void BosShoot()
    {
        //1st bullet
        GameObject bosBul1 = bulletPooler.GetPooledObject();
        if(bosBul1 == null) return;
        bosBul1.transform.position = FirePoint1.position;
        bosBul1.transform.rotation = FirePoint1.rotation;
        bosBul1.SetActive(true);

        //2nd bullet
        /*GameObject bosBul2 = bulletPooler.GetPooledObject();
        if(bosBul2 == null) return;
        bosBul2.transform.position = FirePoint2.position;
        bosBul2.transform.rotation = FirePoint2.rotation;
        bosBul2.SetActive(true);*/
    }
}
