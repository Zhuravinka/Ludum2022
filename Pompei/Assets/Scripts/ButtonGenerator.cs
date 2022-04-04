using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DialogueEditor;
public class ButtonGenerator : MonoBehaviour
{

    [SerializeField] List<GameObject> buttons;
    [SerializeField] List<Transform> roots;
    [SerializeField] GameObject cloudManager;
    public static KeyCode _keyToPress = KeyCode.Space;
    GameObject _button;

    float[] threshhold = new float[] { 0.3f, 0.6f, 0.8f };

    float[] _beats = new float[] { 1.6f, 1.4f, 1.1f };
    float spawnSpeed = 1.7f;

    bool isStart;
    [SerializeField] private NPCConversation start_dialogue;
    [SerializeField] private Animator volcano_animator;


    [SerializeField] private Image back_image;
    [SerializeField] private Sprite default_sprite;
    void Start()
    {
        ConversationManager.Instance.StartConversation(start_dialogue);
        isStart = false;
        back_image.sprite = default_sprite;
    }

    void Update()
    {
        if(isStart){
            for (int i=0; i<3; i++)
            {
                if (ProgressBar.instance.slider.value > threshhold[i])
                {
                    spawnSpeed = _beats[i];
                }
            }
        }
    }

    public void StartGame(){
        SpawnButton();
        StartCoroutine("ButtonSpawner");
        isStart = true;
        volcano_animator.enabled = true;
        back_image.gameObject.SetActive(false);
        cloudManager.SetActive(true);
    }   


    public IEnumerator ButtonSpawner()
    {
        for(int i=0; i<500; i++)
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
