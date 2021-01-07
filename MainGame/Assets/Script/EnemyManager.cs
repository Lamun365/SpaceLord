using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public ObjectPooler[] enemyPooler;
    //private int i;
    public float enemyDelay1;
    private int scoreCheck;
    public float miniBossDelay;
    public float[] bossDelay;

    private void Start()
    {
        scoreCheck = ScoreCounter.instanse.score % 71;
        InvokeRepeating("EnemyCaller1", enemyDelay1, enemyDelay1);
        InvokeRepeating("EnemyCaller2", enemyDelay1+7, enemyDelay1+7);
        InvokeRepeating("miniBoss", miniBossDelay, miniBossDelay);
        InvokeRepeating("Boss", bossDelay[0], bossDelay[0]);
        //bossdelay[0] = boss1; bossdelay[1]= boss2; bossdelay[2]= boss3; bossdelay[3]=boss4;bossdelay[4]= boss5;
        
        /*if(ScoreCounter.instanse.score >= 0)
        {
            i = 0;
            InvokeRepeating("EnemyCaller", enemyDelay1, enemyDelay1);
        }
        if(ScoreCounter.instanse.score > 10)
        {
            i = 1;
            InvokeRepeating("EnemyCaller", enemyDelay1, enemyDelay1);
        }*/
        
    }
    private void Update()
    {
        scoreCheck = ScoreCounter.instanse.score % 71;
    }
    private void EnemyCaller1()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if(scoreCheck >= 0)
        {
            GameObject enemy1 = enemyPooler[0].GetPooledObject();
            if(enemy1 == null) return;
            enemy1.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));
            enemy1.SetActive(true);
    
            //ScheduleAsterSpawn();
            GameObject enemy2 = enemyPooler[1].GetPooledObject();
            if(enemy2 == null) return;
            enemy2.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));
            enemy2.SetActive(true);
        }
        if(scoreCheck >= 40)
        {
            GameObject enemy_1 = enemyPooler[2].GetPooledObject();
            if(enemy_1 == null) return;
            enemy_1.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));
            enemy_1.SetActive(true);
        
            //ScheduleAsterSpawn();
            GameObject enemy_2 = enemyPooler[3].GetPooledObject();
            if(enemy_2 == null) return;
            enemy_2.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));
            enemy_2.SetActive(true);
        }
        if(scoreCheck >= 60)
        {
            GameObject enemy_3 = enemyPooler[4].GetPooledObject();
            if(enemy_3 == null) return;
            enemy_3.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));
            enemy_3.SetActive(true);
        }
        
    }
    private void EnemyCaller2()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        
        if(scoreCheck >= 0)
        {
            GameObject enemy1 = enemyPooler[0].GetPooledObject();
            if(enemy1 == null) return;
            enemy1.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));
            enemy1.SetActive(true);
    
            //ScheduleAsterSpawn();
            GameObject enemy2 = enemyPooler[1].GetPooledObject();
            if(enemy2 == null) return;
            enemy2.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));
            enemy2.SetActive(true);
        }

        if(scoreCheck >= 40)
        {
            GameObject enemy_1 = enemyPooler[2].GetPooledObject();
            if(enemy_1 == null) return;
            enemy_1.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));
            enemy_1.SetActive(true);
        
            //ScheduleAsterSpawn();
            GameObject enemy_2 = enemyPooler[3].GetPooledObject();
            if(enemy_2 == null) return;
            enemy_2.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));
            enemy_2.SetActive(true);
        }
        if(scoreCheck >= 60)
        {
            GameObject enemy_3 = enemyPooler[4].GetPooledObject();
            if(enemy_3 == null) return;
            enemy_3.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));
            enemy_3.SetActive(true);
            Debug.Log(Time.time);
        }
    }
    private void miniBoss()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject miniBoss1 = enemyPooler[5].GetPooledObject();
        if(miniBoss1 == null) return;
        miniBoss1.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));
        miniBoss1.SetActive(true);
    
        //ScheduleAsterSpawn();
        GameObject miniBoss2 = enemyPooler[5].GetPooledObject();
        if(miniBoss2 == null) return;
        miniBoss2.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));
        miniBoss2.SetActive(true);
        //note miniboss calling time every 95seconds
    }
    private void Boss()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject Boss1 = enemyPooler[6].GetPooledObject();
        if(Boss1 == null) return;
        Boss1.transform.position = new Vector2(max.x - 0.01f, 0.02f); //(max.x, Random.Range(min.y, max.y));
        Boss1.SetActive(true);
        //note: call boss1 every 110 seconds
    }
    /*private void EnemyCaller()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        for(i = 0; i < enemyPooler.Length;)
        {
            if(ScoreCounter.instanse.score > 10)
        {
            i ++;
        }
            GameObject enemy = enemyPooler[i].GetPooledObject();
            enemy = enemyPooler[i].GetPooledObject();
            if(enemy == null) return;
            enemy.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));
            enemy.SetActive(true);
            Debug.Log("score" +i);
        }
        
    }*/

}
