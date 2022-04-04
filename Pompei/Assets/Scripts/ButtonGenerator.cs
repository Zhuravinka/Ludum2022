using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DialogueEditor;
using TMPro;
public class ButtonGenerator : MonoBehaviour
{
    public static ButtonGenerator instance;
    [SerializeField] List<GameObject> buttons;
    [SerializeField] List<Transform> roots;
   [SerializeField] GameObject cloudManager;
    [SerializeField] GameObject Quotes;

    public static KeyCode _keyToPress = KeyCode.Space;
    GameObject _button;

    float[] threshhold = new float[] { 0.4f, 0.6f, 0.8f };

    float[] _beats = new float[] { 1.8f, 1.5f, 1.3f };
    float spawnSpeed = 2f;

    public bool isStart;
    [SerializeField] private NPCConversation start_dialogue_ru;
    [SerializeField] private NPCConversation start_dialogue_en;
    [SerializeField] private Animator volcano_animator;

    [SerializeField] private Image back_image;
    [SerializeField] private Sprite default_sprite;
    [SerializeField] private Image text_image;
    [SerializeField] private Sprite default_text;

    [SerializeField] private GameObject start_panel;

    [SerializeField] private TextMeshProUGUI tutorial;
    [SerializeField] private TextMeshProUGUI tutorial_title;
    [SerializeField] private TextMeshProUGUI tap;
    void Start()
    {
        instance = this;
        if(Localization.language == "EN"){
            ConversationManager.Instance.StartConversation(start_dialogue_en);
        }else{
            ConversationManager.Instance.StartConversation(start_dialogue_ru);
        }
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
        if(Localization.language == "EN"){
            tutorial.text = "Use the power of slowing down the lava by pressing the SPACE. Citizens can beg for help, so use QWER for the divine power of evacuation";
            tutorial_title.text = "TUTORIAL";
            tap.text = "TAP TO CONTINUE!";
        }else{
            tutorial.text = "Используй силу замедления лавы нажимая на ПРОБЕЛ. Жители могут взмолить о помощи, тогда используй QWER для божественной силы эвакуации";
            tutorial_title.text = "Обучение";
            tap.text = "Нажмите, чтобы продолжить!";
        }
    }

    public void StartGame(){
       cloudManager.SetActive(true);
        Quotes.SetActive(true);
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
        for(int i=0; i<100; i++)
        {
            SpawnButton();
            yield return new WaitForSeconds(spawnSpeed);
        }
    }
    public void SpawnButton()
    {
        if(isStart){
            GameObject newButton = Instantiate(buttons[Random.Range(0, buttons.Count)], roots[Random.Range(0, roots.Count)].position, Quaternion.identity);
            newButton.GetComponent<Button>().lifeTime = spawnSpeed;
        }
    }
}
