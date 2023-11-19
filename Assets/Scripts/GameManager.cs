using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int hp;
    public int currentLevel;
    bool hasWon;

    public List<string> levels;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }


    public void Win()
    {
        if (hasWon) return; 


        currentLevel++;
        Invoke("LoadNextScene", 1f);
    }

    public void LoadNextScene()
    {
        var levelName = levels[currentLevel];
        SceneManager.LoadScene(levelName);
        hasWon = false;
    }
    
    public void Lose()
    {

    }

}
