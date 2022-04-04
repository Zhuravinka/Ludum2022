using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
   [SerializeField] public KeyCode key;
   [SerializeField] float lifeTime;

    float timer;
    Transform _transform;
    Animator _animator;
    void Awake()
    {
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        
           

        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Space))
        {
            if (Input.GetKeyDown(key))
            {
                GameController.instance.ButtonHit();
                _animator.SetTrigger("Highlight");
                StartCoroutine("Kill");
            }
            else
            {
                if(!Input.GetKeyDown(KeyCode.Space))
                    GameController.instance.ButtonMissed();
            }

        }
        if (timer>=lifeTime)
        {
            timer = 0f;
            GameController.instance.ButtonMissed();
            StartCoroutine("Kill");
        }

    }

    public IEnumerator Kill()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Destroy(gameObject);
       
    }
}
