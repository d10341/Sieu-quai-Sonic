using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public UnityEvent OnValueChange;
    public int rings;
    public int score;
    public int life;

    public float _time;
    
    public static GameManager gm;
    void Start()
    {
        _time = Time.time;
        rings = 0;
        score = 0;
        life = 2;
    }

    void Awake () {
        if (gm == null)
            gm = this;
    }
    
    // Update is called once per frame
    void Update()
    {
        _time = (int)(Time.time);
    }

    public int calcScore()
    {
        int a = (int)Time.time;
        int c = 20000 - a;
        if (c < 0)
        {
            c = 0;
        }
        return score + rings * 100 + c;
    }
}
