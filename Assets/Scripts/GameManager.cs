using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int hp;
    public int currentLevel;

    public List<string> levels;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }


    public void Win()
    {
        currentLevel++;
        Invoke("LoadNextScene", 1f);
    }

    public void LoadNextScene()
    {
        var levelName = levels[currentLevel];
        SceneManager.LoadScene(levelName);

    }
    
    public void Lose()
    {

    }

}
