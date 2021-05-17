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
    
    void Update()
    {
        if (!end && music == true && Time.time - oldTime >= 6)
        {
            Debug.Log("score");
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
            if (level == 1)
            {
                PlayerPrefs.SetInt("score1", GameManager.gm.calcScore());
                PlayerPrefs.SetInt("level2", 1);
            }
            else if (level == 2)
            {
                PlayerPrefs.SetInt("score2", GameManager.gm.calcScore());
                PlayerPrefs.SetInt("level3", 1);
            }
            else if (level == 3)
            {
                PlayerPrefs.SetInt("score3", GameManager.gm.calcScore());
            }
            PlayerPrefs.SetInt("rings", PlayerPrefs.GetInt("rings"));
            PlayerPrefs.Save();
            SceneManager.LoadScene("DataSelect", LoadSceneMode.Single);
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
