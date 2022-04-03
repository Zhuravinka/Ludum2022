using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public static ProgressBar instance;
    public Slider slider;
    float newScore;
    float fillSpeed = 0.5f;
    void Start()
    {
        instance = this;
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < newScore)
            slider.value += fillSpeed * Time.deltaTime;
        else
            slider.value -= fillSpeed * Time.deltaTime;
    }
    public void AddScore(float score)
    {
       newScore = slider.value + score;
    }
}
