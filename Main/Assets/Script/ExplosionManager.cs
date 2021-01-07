using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    private void ExplosionDestroyer()
    {
        gameObject.SetActive(false);
        ScoreCounter.instanse.score += 1;
        Debug.Log(ScoreCounter.instanse.score);
    }
    private void ExplosionDestroyer2()
    {
        gameObject.SetActive(false);
    }
}
