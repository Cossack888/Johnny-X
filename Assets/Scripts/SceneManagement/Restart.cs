using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour

{
    public GameObject gameOverScreen;
    public Scene scene;


    public void Start()
    {
        scene = SceneManager.GetActiveScene();
        
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameOver()
    {
      
            gameOverScreen.SetActive(true);

       
    }

}