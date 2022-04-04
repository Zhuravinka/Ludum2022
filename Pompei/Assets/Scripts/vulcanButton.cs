using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vulcanButton : MonoBehaviour
{
    [SerializeField] public KeyCode key;


    Animator _animator;
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {

            if (Input.GetKeyDown(key))
            {
            //Lava animation slow down
            _animator.SetTrigger("Highlight");
            }
            else
            {
            //Lava animation normal speed
            }

    }
   
}
