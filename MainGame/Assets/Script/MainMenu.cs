using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public GameObject creditPan;
    public GameObject menuPan;
    public GameObject welcomePan;

    public void StartButton()
    {
        //SceneChanger(1);
        SceneManager.LoadSceneAsync(1);
    }
    public void CreditButton()
    {
        menuPan.gameObject.SetActive(false);
        creditPan.gameObject.SetActive(true);
    }
    public void RetButton()
    {
        menuPan.gameObject.SetActive(true);
        creditPan.gameObject.SetActive(false);
    }
    public void QuitGame()
    {
        welcomePan.gameObject.SetActive(false);
        Debug.Log("Quit");
        Application.Quit();
    }
    public void SceneChanger( int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }
    public void ExitMenu()
    {
        menuPan.gameObject.SetActive(false);
        welcomePan.gameObject.SetActive(true);
        Invoke("QuitGame", 1f);
    }
}
