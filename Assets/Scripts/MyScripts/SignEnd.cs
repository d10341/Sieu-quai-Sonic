using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignEnd : MonoBehaviour
{
    public Animator animator;

    public AudioSource audioSource;

    private float oldTime;

    public GameObject _gameObject;
    public GameObject _panel;
    
    private bool music;

    public bool end;

    public int level;
    //

    public int getLevel() { return level; }

    void Update()
    {
        if (!end && music == true && Time.time - oldTime >= 6)
        {
            music = false;
            end = true;
            animator.SetBool("End", false);
            _gameObject.SetActive(true);
            _panel.SetActive(true);
            _gameObject.GetComponent<Text>().text = "score :" + GameManager.gm.calcScore();
            oldTime = Time.time;
        }
        if (end && Time.time - oldTime > 2)
        {
            int totalrings = PlayerPrefs.GetInt("rings") + GameManager.gm.rings;
            if (level == 1)
            {
                if (GameManager.gm.calcScore() > PlayerPrefs.GetInt("score1"))
                    PlayerPrefs.SetInt("score1", GameManager.gm.calcScore());
                else
                    PlayerPrefs.SetInt("score1", PlayerPrefs.GetInt("score1"));
                PlayerPrefs.SetInt("level2", 1);
                PlayerPrefs.SetInt("rings", totalrings);
                PlayerPrefs.Save();
                SceneManager.LoadScene("Level2", LoadSceneMode.Single);
            }
            else if (level == 2)
            {
                if (GameManager.gm.calcScore() > PlayerPrefs.GetInt("score2"))
                    PlayerPrefs.SetInt("score2", GameManager.gm.calcScore());
                else
                    PlayerPrefs.SetInt("score2", PlayerPrefs.GetInt("score2"));
                PlayerPrefs.SetInt("level3", 1);
                PlayerPrefs.SetInt("rings", totalrings);
                PlayerPrefs.Save();
                SceneManager.LoadScene("Level3", LoadSceneMode.Single);
            }
            else if (level == 3)
            {
                if (GameManager.gm.calcScore() > PlayerPrefs.GetInt("score3"))
                    PlayerPrefs.SetInt("score3", GameManager.gm.calcScore());
                else
                    PlayerPrefs.SetInt("score3", PlayerPrefs.GetInt("score3"));
                PlayerPrefs.SetInt("rings", totalrings);
                PlayerPrefs.Save();
                SceneManager.LoadScene("End", LoadSceneMode.Single);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !music)
        {
            animator.SetBool("End", true);
            audioSource.GetComponent<AudioSource>();
            audioSource.Play(1);
            oldTime = Time.time;
            music = true;
        }
    }
}
