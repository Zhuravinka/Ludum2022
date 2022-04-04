using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DialogueEditor;
using UnityEngine.SceneManagement;
using TMPro;

public class Volcano : MonoBehaviour
{
    [SerializeField] private Animator volcano_animator;
    [SerializeField] private KeyCode key_volcano_stop;

    private bool isMove;
    private float time;
    private float delay = 0.1f;

    [SerializeField] private Sprite space_idle;
    [SerializeField] private Sprite space_press;
    [SerializeField] private SpriteRenderer space_button;

    [SerializeField] private NPCConversation win_dialogue_en;
    [SerializeField] private NPCConversation win_dialogue_ru;
    [SerializeField] private NPCConversation lose_dialogue_en;
    [SerializeField] private NPCConversation lose_dialogue_ru;

    [SerializeField] private Slider slider;
    [SerializeField] private Image back_image;
    [SerializeField] private Sprite win_sprite;
    [SerializeField] private Sprite lose_sprite;
    [SerializeField] private Image text_image;
    [SerializeField] private Sprite win_text_en;
    [SerializeField] private Sprite lose_text_en;
    [SerializeField] private Sprite win_text_ru;
    [SerializeField] private Sprite lose_text_ru;

    [SerializeField] private GameObject result_panel;

    [SerializeField] private TextMeshProUGUI end;
    [SerializeField] private TextMeshProUGUI restart;
    [SerializeField] private TextMeshProUGUI gotomenu;

    private void Start(){
        volcano_animator.enabled = false;
        isMove = true;
        time = 0;
        space_button.sprite = space_idle;
        result_panel.SetActive(false);
    }
    private void Update(){
        
        if(!isMove){
            time += Time.deltaTime;
        }
        if(time >= delay){
            time = 0.0f;
            isMove = true;
            volcano_animator.enabled = true;
            space_button.sprite = space_idle;
        }
        if (Input.GetKeyDown(key_volcano_stop) && isMove)
        {
            volcano_animator.enabled = false;
            isMove = false;
            space_button.sprite = space_press;
        }
    }
    //Если анимация вулкана закончится, то выполнится этот метод, можно добавить проверку
    //по типу, если слайдер равен 1, то значит мы победили, иначе проиграли.
    public void Finish(){
        back_image.gameObject.SetActive(true);
        if(slider.value == 1){
            back_image.sprite = win_sprite;
            if(Localization.language == "EN"){
                text_image.sprite = win_text_en;
                ConversationManager.Instance.StartConversation(win_dialogue_en);
            }else{
                text_image.sprite = win_text_ru;
                ConversationManager.Instance.StartConversation(win_dialogue_ru);
            }
        }else{
            back_image.sprite = lose_sprite;
            if(Localization.language == "EN"){
                text_image.sprite = lose_text_en;
                ConversationManager.Instance.StartConversation(lose_dialogue_en);
            }else{
                text_image.sprite = lose_text_ru;
                ConversationManager.Instance.StartConversation(lose_dialogue_ru);
            }
        }
    }
    public void ActiveReesultPanel(){
        result_panel.SetActive(true);
        if(Localization.language == "EN"){
            end.text = "GAME IS END!";
            restart.text = "RESTART";
            gotomenu.text = "GO TO MENU";
        }else{
            end.text = "Игра окончена!";
            restart.text = "Перезапустить";
            gotomenu.text = "Выйти в меню";
        }
    }
    public void GameRestart(){
        Application.LoadLevel(Application.loadedLevel);
    }
    public void GoToMenu(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
}
