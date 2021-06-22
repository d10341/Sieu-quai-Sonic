using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Again()
    {
        SceneManager.LoadScene("DataSelect", LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
