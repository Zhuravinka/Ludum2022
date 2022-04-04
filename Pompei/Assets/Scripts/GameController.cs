using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] List<GameObject> buttons;
    [SerializeField] List<Transform> roots;

    public static GameController instance;

    public int combo;
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
        combo = 0;
        ProgressBar.instance.AddScore(-0.1f);
    }
}
