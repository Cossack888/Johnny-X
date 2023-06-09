using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject LoadingScreen;
    public float transitionTime = 3f;
    public GameObject changeLevels;
   // public GameObject player;




    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");
    }


    // Update is called once per frame
    void Update()
    {
        if (changeLevels.activeSelf)
        {
            LoadNextLevel();
            changeLevels.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            LoadNextLevel();

        }

    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        //player.SetActive(false);
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        LoadingScreen.SetActive(true);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
