using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter instanse;
    public int score;

    private void Start()
    {
        if(instanse == null)
        {
            instanse = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
