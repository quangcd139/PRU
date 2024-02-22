using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [SerializeField]private GameObject gameOverScreen;
    [SerializeField]private GameObject winScreen;

    [SerializeField]private AudioClip gameOverSound;

    private void Awake() {
        gameOverScreen.SetActive(false);
    }

    public void GameOver(){
        gameOverScreen.SetActive(true);
        Time.timeScale=0;
        SoundManager.instance.PlaySound(gameOverSound,1);
    }

     public void Win(){
        winScreen.SetActive(true);
        Time.timeScale=0;
        SoundManager.instance.PlaySound(gameOverSound,1);
    }

    public void Restart(){
        Time.timeScale=1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu(){
        SceneManager.LoadScene(0);
    }

    public void Quit(){
        Application.Quit();
    }

    public void NextMap(){
        Time.timeScale=1;
        int scen=SceneManager.GetActiveScene().buildIndex+1;
        SceneManager.LoadScene(scen);
    }
}
