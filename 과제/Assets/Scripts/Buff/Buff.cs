using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buff : MonoBehaviour
{
    [SerializeField]
    private List<BuffInfo> allBuff = new List<BuffInfo>();
    [SerializeField]
    private GameObject buffUI;
    [SerializeField]
    private Text[] buffNames;//빈 리스트 생성
    private List<BuffInfo> selectBuff = new List<BuffInfo>();
    public string choosenBuff;

    private void Start()
    {
        ShowBuff();
    }

    //////////////////////////////////////////////////////////////////////////////////////////
    public void ShowBuff()
    {
        for (int i = 0; i < 5;)
        {
            int rand = Random.Range(0, allBuff.Count);
            if (!selectBuff.Contains(allBuff[rand]) || selectBuff.Count == 0)
            {
                selectBuff.Add(allBuff[rand]);
                i++;
            }
        }

        for (int i = 0; i < selectBuff.Count; i++)
        {
            buffNames[i].text = selectBuff[i].myBuffName;
        }
    }

    public void ChooseBuff(int indexNum)
    {
        choosenBuff = selectBuff[indexNum].myBuffName;
        Debug.Log(choosenBuff);
    }
}
