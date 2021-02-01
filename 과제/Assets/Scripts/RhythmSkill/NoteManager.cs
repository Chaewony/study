using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteManager : MonoBehaviour
{

    public int bpm = 0;
    double currentTime = 0d;
    //float fades = 1.0f; //페이드 값
    //bool doDestroy = false; //노트 파괴 여부
    bool isRhythmKey = false;  //스페이스 

    //int skill_stack = 0;    // (임시용)리듬 입력을 사용하기 위핸 필요 스택 개수(나중에 인자로 받아올 것)

    public List<GameObject> NoteList = new List<GameObject>();  // 노트들을 리스트에 저장시키기 위해 NoteList 리스트 선언

    [SerializeField] Transform tfNoteAppear = null;
    [SerializeField] GameObject goNote = null;

    EffectManager theEffect;

    void Start()
    {
        theEffect = FindObjectOfType<EffectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        // 일정 주기마다 노트 생성(이후 랜덤 박자에 따른 노트 생성으로 변경 예정)
        if (currentTime >= 60d / bpm)
        {
            CreateNote();
            currentTime -= 60d / bpm;
        }

        // 판정
        if (NoteList.Count > 0) // 판정을 받을 노트 리스트가 0개 초과이면
        {
            if (Input.GetKeyDown(KeyCode.G) && !isRhythmKey)    // 키 입력을 받았을 때
            {
                isRhythmKey = true;
                if (NoteList[0].transform.localScale.x >= 0.9f && NoteList[0].transform.localScale.x <= 1.1f)  // Perfect
                {
                    Debug.Log("Perfect!");
                    theEffect.JudgementEffect(0);
                    NoteList[0].GetComponent<Note>().enabled = false;
                    StartCoroutine(Fade());
                    //doDestroy = true;
                }
                else if (NoteList[0].transform.localScale.x > 1.1f && NoteList[0].transform.localScale.x <= 1.3f)   // Great
                {
                    Debug.Log("Great!");
                    theEffect.JudgementEffect(1);
                    NoteList[0].GetComponent<Note>().enabled = false;
                    StartCoroutine(Fade());
                }
                else if (NoteList[0].transform.localScale.x > 1.3f && NoteList[0].transform.localScale.x <= 1.7f)   // Good
                {
                    Debug.Log("Good!");
                    theEffect.JudgementEffect(2);
                    NoteList[0].GetComponent<Note>().enabled = false;
                    StartCoroutine(Fade());
                }
                else if (NoteList[0].transform.localScale.x > 1.7f && NoteList[0].transform.localScale.x <= 2.1f)   // Bad
                {
                    Debug.Log("Bad!");
                    theEffect.JudgementEffect(3);
                    NoteList[0].GetComponent<Note>().enabled = false;
                    StartCoroutine(Fade());
                }
                else if (NoteList[0].transform.localScale.x > 2.1f) // Miss
                {
                    Debug.Log("Miss!");
                    theEffect.JudgementEffect(4);
                    NoteList[0].GetComponent<Note>().enabled = false;
                    StartCoroutine(Fade());
                }
                //fades = 1.0f;   // fades 값 1.0으로 초기화
            }
            else if (NoteList[0].transform.localScale.x <= 0.8f)    // 키 입력을 받지 못했을 때
            {
                Debug.Log("No HIT");
                theEffect.JudgementEffect(4);
                Destroy(NoteList[0]);
                NoteList.Remove(NoteList[0]);
                isRhythmKey = false;
            }
        }
    }

    /* // 구버전
    private void FixedUpdate()
    {
        if (doDestroy)
        {
            if (fades > 0)
            {
                fades -= 0.1f;
                NoteList[0].GetComponent<Image>().color = new Color(1f, 1f, 1f, fades);
            }
            else
            {
                doDestroy = false;
                getSpace = false;
                Destroy(NoteList[0]);
                NoteList.Remove(NoteList[0]);
            }
        }
    }
    */

    void CreateNote()   //Create Note
    {
        GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);
        t_note.AddComponent<SpriteRenderer>();
        NoteList.Add(t_note);
        t_note.transform.SetParent(this.transform);
    }

    void RemoveNote()   // 노트 제거 함수
    {
        isRhythmKey = false;
        Destroy(NoteList[0]);
        NoteList.Remove(NoteList[0]);
    }

    IEnumerator Fade()  // 페이드 아웃 및 노트 제거 함수
    {
        for (float i = 1.0f; i >= 0f; i -= 0.01f)
        {
            NoteList[0].GetComponent<Image>().color = new Color(1f, 1f, 1f, i);
            yield return null;
        }
        RemoveNote();
    }
}
