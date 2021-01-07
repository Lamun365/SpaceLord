using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    //public static ObjectPooler SharedInstance;
    private List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountPool;
    public bool allowGrow;

    /*void Awake()
    {
        SharedInstance = this;
    }*/
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountPool; i++)
        {
            GameObject obj = (GameObject) Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        if(allowGrow)
        {
            GameObject obj = (GameObject) Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            return obj;
        }
        return null;
    }
}
