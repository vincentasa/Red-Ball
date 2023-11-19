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

    float targetTransitionScale;
    public Transform transition;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        if(FindObjectsOfType<GameManager>().Length > 1)
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        var target = Vector3.one * targetTransitionScale;

        transition.localScale = Vector3.MoveTowards(transition.localScale,target, 60 * Time.deltaTime);
    }

    public void Win()
    {
        if (hasWon) return;

        hasWon = true;
        currentLevel++;
        Invoke("LoadNextScene", 1f);
        targetTransitionScale = 30;

    }

    public void LoadNextScene()
    {
        var levelName = levels[currentLevel];
        currentLevel = 0;
        SceneManager.LoadScene(levelName);
        hasWon = false;
        targetTransitionScale = 0;
    }
    
    public void Lose()
    {
        hp--;
        if (hp > 0)
        {
            // restart
            Invoke("LoadNextScene", 1f);
        }
        else
        {
            // restart to level 0
            currentLevel = 0;
            Invoke("LoadNextScene", 1f);
        }
    }

}
