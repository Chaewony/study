using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //추가

[System.Serializable]
[CreateAssetMenu (menuName = "Buff", fileName = "Buff/BuffInfo")] //menuName에 들어간 이름으로 에셋 생성할 수 있음

public class BuffInfo : ScriptableObject
{
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private string buffName;
    [SerializeField]
    private int hp;
    [SerializeField]
    private int defence;

    public Sprite mySprite { get => sprite; }
    public string myBuffName { get => buffName; }
    public int myHp { get => hp; }
    public int myDefence { get => defence; }
}

public enum buffSlot
{
    BuffSlot1,
    BuffSlot2,
    BuffSlot3
}
