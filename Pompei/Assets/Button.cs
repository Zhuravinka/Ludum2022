using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
   [SerializeField] public KeyCode key;
   [SerializeField] float _speed;

    Transform _transform;
    void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _transform.Translate( Vector2.left * _speed * Time.deltaTime); 
        if (Input.GetKeyDown(key))
            print("fdfdf");
    }

       

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
