using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverer : MonoBehaviour
{
    public GameObject gOverPan;
    public Slider slider;
    public Gradient grad;
    public Text gOverScore;
    public Text scoreOnGame;
    public Text highScoreTxt;
    public Image fill;
    public GameObject scoreBoard;
    public GameObject resumePanel;
    private AudioSource audioSource;
    public AudioClip fire;
    private GameObject poolingObject;
    private GameObject player;
    private bool done = true;
    // Start is called before the first frame update
    
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        poolingObject = GameObject.Find("ExplosionPooler2");
        player = GameObject.Find("Player");
        fill.color = grad.Evaluate(1f);
        slider.maxValue = PlayerController.health;
        slider.value = PlayerController.health;
        highScoreTxt.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        gOverPan.gameObject.SetActive(false);
        resumePanel.gameObject.SetActive(false);
        player.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        scoreOnGame.text = ScoreCounter.instanse.score.ToString();
        fill.color = grad.Evaluate(slider.normalizedValue);
        gOverScore.text = ScoreCounter.instanse.score.ToString(); //score in gameOver
        scoreOnGame.text = ScoreCounter.instanse.score.ToString();
        //HighScore
        if(ScoreCounter.instanse.score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", ScoreCounter.instanse.score);
            highScoreTxt.text = ScoreCounter.instanse.score.ToString();
        }
        
        slider.value = PlayerController.health;
        if(PlayerController.health <= 0 && done == true)
        {
                Debug.Log("Game Over");

                scoreBoard.gameObject.SetActive(false);
                gOverPan.gameObject.SetActive(true);
                //deactive player here
                player.gameObject.SetActive(false);
                GameOverAudio(); //play gameOver Audio
                PlayExplosion();
                PlayerController.health = 10;
                done = false;
        }
    }
    private void PlayExplosion()
    {
        GameObject explosion = poolingObject.GetComponent<ObjectPooler>().GetPooledObject();
        if(explosion == null) return;
        explosion.transform.position = player.transform.position;
        explosion.transform.rotation = player.transform.rotation;
        explosion.SetActive(true);
    }
    public void AgainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    
    public void ResumeMenu()
    {
        resumePanel.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void PuaseMenu()
    {
        resumePanel.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void RetToMenu() //not working
    {
        SceneManager.LoadSceneAsync(0);
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gOverPan.gameObject.SetActive(false);


    }
    public void OnApplicationQuit() //when minimize android app
    {
        Time.timeScale = 0f;
    }

    private void GameOverAudio()
    {
        audioSource.PlayOneShot(fire);
    }
}
