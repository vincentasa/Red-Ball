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

    AudioSource source;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip gameoverSound;

    void Start()
    {
        Application.targetFrameRate = 60;

        source = GetComponent<AudioSource>();
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

        source.PlayOneShot(winSound);

    }

    public void LoadNextScene()
    {
        var levelName = levels[currentLevel];
        SceneManager.LoadScene(levelName);
        hasWon = false;
        targetTransitionScale = 0;
    }
    
    public void Lose()
    {
        hp--;
        if (hp > 0)
        {

            Invoke("LoadNextScene", 1f);
            source.PlayOneShot(loseSound);
        }
        else
        {
            currentLevel = 0;
            Invoke("LoadNextScene", 1f);
            source.PlayOneShot(gameoverSound);
        }
        
    }

}
