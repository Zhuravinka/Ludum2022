using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGenerator : MonoBehaviour
{

    [SerializeField] List<GameObject> buttons;
    [SerializeField] List<Transform> roots;

    public static KeyCode _keyToPress = KeyCode.Space;
    GameObject _button;

    float[] threshhold = new float[] { 0.4f, 0.6f, 0.8f };

    float[] _beats = new float[] { 1.8f, 1.5f, 1.3f };
    float spawnSpeed = 2f;
    void Start()
    {

        SpawnButton();
        StartCoroutine("ButtonSpawner");
    }

    void Update()
    {
        for (int i=0; i<3; i++)
        {
            if (ProgressBar.instance.slider.value > threshhold[i])
            {
                spawnSpeed = _beats[i];
            }
        }

    }


    public IEnumerator ButtonSpawner()
    {
        for(int i=0; i<100; i++)
        {
            SpawnButton();
            yield return new WaitForSeconds(spawnSpeed);
        }
    }
    public void SpawnButton()
    {
       GameObject newButton = Instantiate(buttons[Random.Range(0, buttons.Count)], roots[Random.Range(0, roots.Count)].position, Quaternion.identity);
    }
}
