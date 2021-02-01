using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosenBuff : MonoBehaviour
{
    public Buff buff;
    public Image choosenBuffImage;//사용자가 선택한 버프 이미지 저장할 변수

    public void ChooseBuff(int indexNum)
    {
        //사용자가 고른 버크 카드의 이미지를 출력
        choosenBuffImage.sprite = buff.mySelectBuff[indexNum].mySprite;
    }
}
