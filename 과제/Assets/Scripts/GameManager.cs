using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public TalkManager talkManager;
    public int talkIndex;
    public GameObject choosenBuff;
    public PlayerAttack playerAttack; //이 스크립트에서 쿨타임 적용
    
    [SerializeField]
    private Image swordCoolImg; //소드 쿨타임 이미지
    [SerializeField]
    private float swordCool; //소드 쿨타임

    public Image fireCoolImg; //파이어볼 쿨타임 이미지
    [SerializeField]
    private float fireCool; //파이어볼 쿨타임

    public Image rhythmCoolImg; //리듬입력 쿨타임 이미지
    [SerializeField]
    private float rhythmCool; //리듬입력 쿨타임

    WaitForSeconds seconds = new WaitForSeconds(0.1f);

    public void Awake()
    {
        choosenBuff.SetActive(false); //선택된 버프창 꺼두기
    }

    public void Update()
    {    
        dialogueUI.SetActive(isAction);
    }

    public void Action(GameObject scanObj)
    {
        if (isAction)
        {
            isAction = true;
            scanObject = scanObj;
            ObjData objData = scanObject.GetComponent<ObjData>();
            Dialogue(objData.id, objData.isNpc);
        }
    }

    void Dialogue(int id, bool isNpc)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);
        if (talkData == null)
        {
            isAction = false;
            //talkIndex = 0; //인덱스 초기화, 다시 말 못걸게 하고 싶으면 여기를 지우면 됨
            return;
        }

        if(isNpc) //NPC일 경우
        {
            talkText.text = scanObject.name + ": "+ talkData; //대화창 앞에 이름 띄우기
        }
        else //사물일 경우
        {
            talkText.text = talkData;
        }
        talkIndex++;
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    public IEnumerator SwordCool() //소드 쿨타임 관리
    {
        StartCoroutine(CoolImg(swordCool, swordCoolImg)); //쿨타임 이미지 관리
        yield return new WaitForSeconds(swordCool);//쿨타임 진행
        playerAttack.isSword = true; //5초가 지나고 난 후에 바꿔줌
    }
    public IEnumerator FireCool() //파이어볼 쿨타임 관리
    {
        StartCoroutine(CoolImg(fireCool, fireCoolImg)); //쿨타임 이미지 관리
        yield return new WaitForSeconds(fireCool);//쿨타임 진행
        playerAttack.isFire = true;
    }
    public IEnumerator RhythmCool() //리듬입력 쿨타임 관리
    {
        StartCoroutine(CoolImg(rhythmCool, rhythmCoolImg)); //쿨타임 이미지 관리
        yield return new WaitForSeconds(rhythmCool);//쿨타임 진행
        playerAttack.isRhythm = true;
    }

    public IEnumerator CoolImg(float time, Image img) //쿨타임 이미지 관리
    {
        float duration = time;
        while(time>0)
        {
            time -= 0.1f;
            img.fillAmount = time / duration;
            yield return seconds;
        }
        img.fillAmount = 0;
        time = 0;
    }
}
