using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject talkPanel;
    public GameObject bgPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public TalkManager talkManager;
    public int talkIndex;

    public void Update()
    {    
        talkPanel.SetActive(isAction);
        bgPanel.SetActive(isAction);   
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
            talkIndex = 0; //인덱스 초기화, 다시 말 못걸게 하고 싶으면 여기를 지우면 됨
            return;
        }

        if(isNpc)
        {
            talkText.text = scanObject.name + ": "+ talkData;
        }
        else
        {
            talkText.text = talkData;
        }
        talkIndex++;
    }
}
