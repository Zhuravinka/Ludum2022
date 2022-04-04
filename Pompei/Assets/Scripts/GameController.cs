using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
   public static GameController instance;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonHit()
    {
        ProgressBar.instance.AddScore(0.05f);
    }
   public void ButtonMissed()
    {
        ProgressBar.instance.AddScore(-0.1f);
    }
}
