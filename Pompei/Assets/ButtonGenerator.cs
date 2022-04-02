using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGenerator : MonoBehaviour
{

    [SerializeField] List<GameObject> buttons;
    [SerializeField] Transform root;

    Queue<GameObject> _activeButtons;
    float _spawnSpeed = 1f;
    void Start()
    {
        SpawnButton();
        StartCoroutine("ButtonSpawner");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.D)|| Input.GetKeyDown(KeyCode.W))
        {

        }
    }


    public IEnumerator ButtonSpawner()
    {
        for(int i=0; i<100; i++)
        {
            SpawnButton();
            yield return new WaitForSeconds(_spawnSpeed);
        }
    }
    public void SpawnButton()
    {
       GameObject newButton = Instantiate(buttons[Random.Range(0, buttons.Count)], root.position, Quaternion.identity);
        _activeButtons.Enqueue(newButton);
    }
}
