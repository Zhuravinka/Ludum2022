using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kolesnicy : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] List<Transform> roots;
    GameObject newButton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.combo>3)
        {
            newButton = Instantiate(button, roots[Random.Range(0, roots.Count)].position, Quaternion.identity);
            GameController.instance.combo = 0;
           StartCoroutine( Kill());
        }
    }
    public IEnumerator Kill()
    {
        yield return new WaitForSeconds(1f);
        Destroy(newButton);
    }
}
