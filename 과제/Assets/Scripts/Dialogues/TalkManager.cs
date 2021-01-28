using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    public GameObject buffUI;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
        buffUI.SetActive(false); //버프UI 꺼두기
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] { "안녕?", "이 곳에 처음 왔구나?", "버프를 선택하렴" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            buffUI.SetActive(true); //버프UI 켜주기
            return null;
        }
        else
        {
            return talkData[id][talkIndex];
        }
    }
}
