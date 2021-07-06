using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTitle : MonoBehaviour
{
    //[SerializeField] GameObject exitPanel;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Again()
    {
        SceneManager.LoadScene("DataSelect", LoadSceneMode.Single);
    }

    public void Quit()
    {
        //if (exitPanel)
        //{
        //    exitPanel.SetActive(true);
        //}
        Application.Quit();
    }

    //public void onUserClickYesNo(int choice)
    //{
    //    if (choice == 1)
    //    {
    //        Application.Quit();
    //    }
    //    exitPanel.SetActive(false);
    //}
}
