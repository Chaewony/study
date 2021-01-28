using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonType : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public buttonType currentType;
    public Transform buttonScale;
    Vector3 defaultScale;

    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    public void OnButtonClick()
    {
        switch(currentType)
        {
            case buttonType.Start:
                SceneManager.LoadScene("Forest");
                //Debug.Log("게임 시작");
                break;
            case buttonType.Quit:
                Application.Quit();
                //Debug.Log("나가기");
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData) //스크립트가 붙어있는 오브젝트에 마우스가 닿으면 이 함수가 호출됨
    {
        buttonScale.localScale = defaultScale * 1.03f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }
}
