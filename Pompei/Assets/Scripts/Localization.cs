using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localization : MonoBehaviour
{
    public static string language = "RU";
    public string Language = language;
    
    public void SetRU(){
        language = "RU";
    }
    public void SetEN(){
        language = "EN";
    }
}
