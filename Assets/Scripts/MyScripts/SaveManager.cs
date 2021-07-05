using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.GetInt("deapth", 0) == 0)
        {
            PlayerPrefs.SetInt("deapth", 1);
        }
        if (PlayerPrefs.GetInt("rings", 0) == 0 )
        {
            PlayerPrefs.SetInt("rings", 0);
        }
        
        if (PlayerPrefs.GetInt("score1", 0) == 0)
        {
            PlayerPrefs.SetInt("score1", 0);
        }
        
        if (PlayerPrefs.GetInt("score2", 0) == 0)
        {
            PlayerPrefs.SetInt("score2", 0);
        }
        
        if (PlayerPrefs.GetInt("score3", 0) == 0)
        {
            PlayerPrefs.SetInt("score3", 0);
        }    

        if (PlayerPrefs.GetInt("level1", 0) == 0)
        {
            PlayerPrefs.SetInt("level1", 1);
        }
        if (PlayerPrefs.GetInt("level2", 0) == 0)
        {
            PlayerPrefs.SetInt("level2", 0);
        }
        
        
        if (PlayerPrefs.GetInt("level3", 0) == 0)
        {
            PlayerPrefs.SetInt("level3", 0);
        }
        
        if (PlayerPrefs.GetInt("level1") == 1)
        {    
            GameObject.Find("TextStatusLevel1").gameObject.GetComponent<Text>().text = "Open";
        }
        if (PlayerPrefs.GetInt("level2") == 1)
        {
            GameObject.Find("TextStatusLevel2").gameObject.GetComponent<Text>().text = "Open";
        }
        if (PlayerPrefs.GetInt("level3") == 1)
        {    
            GameObject.Find("TextStatusLevel3").gameObject.GetComponent<Text>().text = "Open";
        }
        Save();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            PlayerPrefs.SetInt("score1", 0);
            PlayerPrefs.SetInt("score2", 0);
            PlayerPrefs.SetInt("score3", 0);
            PlayerPrefs.SetInt("deapth", 0);
            PlayerPrefs.SetInt("level2", 0);
            PlayerPrefs.SetInt("level3", 0);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.GetInt("level1") == 0)
        {
            GameObject.Find("TextStatusLevel1").gameObject.GetComponent<Text>().text = "Close";
        }
        if (PlayerPrefs.GetInt("level2") == 0)
        {
            GameObject.Find("TextStatusLevel2").gameObject.GetComponent<Text>().text = "Close";
        }
        if (PlayerPrefs.GetInt("level3") == 0)
        {
            GameObject.Find("TextStatusLevel3").gameObject.GetComponent<Text>().text = "Close";
        }
    }

    public void Save()
    {
        PlayerPrefs.Save();
    }
}
