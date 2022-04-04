using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Replics : MonoBehaviour
{
        public TextMeshProUGUI textComponent;
        public string[] lines;
        public float textSpeed;

        private int index;
        void Start()
        {
            textComponent.text = string.Empty;
            index = 0;
            StartCoroutine(TypeLine());
            
        }

        // Update is called once per frame
        void Update()
        {
           
        }

        
        IEnumerator TypeLine()
        {
           while(true)
            {
            StartCoroutine(Hold());
            yield return new WaitForSeconds(textSpeed);
            }
        }
    IEnumerator Hold()
    {
        textComponent.text = lines[Random.Range(0, lines.Length)];
        yield return new WaitForSeconds(2f);
        textComponent.text = string.Empty;

    }


}
