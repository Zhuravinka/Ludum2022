using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGenerator : MonoBehaviour
{

    [SerializeField] List<GameObject> buttons;
    [SerializeField] List<Transform> roots;

    public static KeyCode _keyToPress = KeyCode.Space;
    GameObject _button;
   // public static Queue<GameObject> _activeButtons = new Queue<GameObject>();
    float _beats = 2f;
    void Start()
    {

        SpawnButton();
        StartCoroutine("ButtonSpawner");
    }

    void Update()
    {
        
    }


    public IEnumerator ButtonSpawner()
    {
        for(int i=0; i<100; i++)
        {
            SpawnButton();
            yield return new WaitForSeconds(_beats);
        }
    }
    public void SpawnButton()
    {
       GameObject newButton = Instantiate(buttons[Random.Range(0, buttons.Count)], roots[Random.Range(0, roots.Count)].position, Quaternion.identity);
        
        //_activeButtons.Enqueue(newButton);
    }
}
