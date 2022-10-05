using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int currentSceneIndex;

    void Update()
    {
        TitleScreen();
        GameOverScreen();
    }

    void TitleScreen()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 

        if (currentSceneIndex == 0)
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
    
    public void YouDied()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    
    

    public void GameOverScreen()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 

        if (currentSceneIndex == 2)
        {
            if (Input.anyKey)
            {
                Restart();
            }
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
