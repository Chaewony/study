using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotType : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public buffSlot currentSlot;
    public Transform buttonScale;
    Vector3 defaultScale;
    public GameObject buffUI;
    public Buff buff; //건드리지 말 것

    public int slotNum;

    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    public void OnButtonClick()
    {
        switch (currentSlot)
        {
            case buffSlot.BuffSlot1:
                slotNum = 0;
                buffUI.SetActive(false);
                break;
            case buffSlot.BuffSlot2:
                slotNum = 1;
                buffUI.SetActive(false);
                break;
            case buffSlot.BuffSlot3:
                slotNum = 4;
                buffUI.SetActive(false);
                break;
        }
        buff.ChooseBuff(slotNum);
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
