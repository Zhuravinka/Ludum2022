using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DialogueEditor;
public class ButtonGenerator : MonoBehaviour
{
    public static ButtonGenerator instance;
    [SerializeField] List<GameObject> buttons;
    [SerializeField] List<Transform> roots;

    public static KeyCode _keyToPress = KeyCode.Space;
    GameObject _button;

    float[] threshhold = new float[] { 0.3f, 0.6f, 0.8f };

    float[] _beats = new float[] { 1.6f, 1.4f, 1.1f };
    float spawnSpeed = 1.7f;

    public bool isStart;
    [SerializeField] private NPCConversation start_dialogue_ru;
    [SerializeField] private NPCConversation start_dialogue_en;
    [SerializeField] private Animator volcano_animator;

    [SerializeField] private Image back_image;
    [SerializeField] private Sprite default_sprite;
    [SerializeField] private Image text_image;
    [SerializeField] private Sprite default_text;

    [SerializeField] private GameObject start_panel;
    void Start()
    {
        instance = this;
        ConversationManager.Instance.StartConversation(start_dialogue_en);
        isStart = false;
        back_image.sprite = default_sprite;
        text_image.sprite = default_text;
        volcano_animator.speed = 1;
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
    public void StartPanelTrue(){
        start_panel.SetActive(true);
    }

    public void StartGame(){
        SpawnButton();
        StartCoroutine("ButtonSpawner");
        isStart = true;
        volcano_animator.enabled = true;
        back_image.gameObject.SetActive(false);
        start_panel.SetActive(false);
    }   
    public void EndGame(){
        isStart = false;
        volcano_animator.speed = 30;
    }


    public IEnumerator ButtonSpawner()
    {
        for(int i=0; i<300; i++)
        {
            SpawnButton();
            yield return new WaitForSeconds(spawnSpeed);
        }
    }
    public void SpawnButton()
    {
        if(isStart){
            GameObject newButton = Instantiate(buttons[Random.Range(0, buttons.Count)], roots[Random.Range(0, roots.Count)].position, Quaternion.identity);
            newButton.GetComponent<Button>().lifeTime = spawnSpeed+0.2f;
        }
    }
}
