using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Replics : MonoBehaviour
{
    public class DialogueSystem : MonoBehaviour
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
            if (index < lines.Length - 1)
            {
                index++;

                textComponent.text = lines[index];
                yield return new WaitForSeconds(textSpeed);
                textComponent.text = string.Empty;
            }
        }
        
    }

}
