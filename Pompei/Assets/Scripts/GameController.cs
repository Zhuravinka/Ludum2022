using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
   public static GameController instance;
    public int combo;
    public GameObject red;
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
        combo++;
        ProgressBar.instance.AddScore(0.05f);
    }
   public void ButtonMissed()
    {
        StartCoroutine(Red());
        combo = 0;
        ProgressBar.instance.AddScore(-0.1f);
    }
    public IEnumerator Red()
    {
        red.SetActive(true);
        yield return new WaitForSeconds(1f);
        red.SetActive(false);
    }
}
