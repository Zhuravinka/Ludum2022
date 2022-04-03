using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volcano : MonoBehaviour
{
    [SerializeField] private Animator volcano_animator;
    [SerializeField] private KeyCode key_volcano_stop;

    private bool isMove;
    private float time;
    private float delay = 1.0f;

    [SerializeField] private Sprite space_idle;
    [SerializeField] private Sprite space_press;
    [SerializeField] private SpriteRenderer space_button;

    private void Start(){
        isMove = true;
        time = 0;
        space_button.sprite = space_idle;
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

    }
}
