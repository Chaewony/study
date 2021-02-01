using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteManager : MonoBehaviour
{

    public int bpm = 0;
    double currentTime = 0d;
    //float fades = 1.0f; //���̵� ��
    //bool doDestroy = false; //��Ʈ �ı� ����
    bool isRhythmKey = false;  //�����̽� 

    //int skill_stack = 0;    // (�ӽÿ�)���� �Է��� ����ϱ� ���� �ʿ� ���� ����(���߿� ���ڷ� �޾ƿ� ��)

    public List<GameObject> NoteList = new List<GameObject>();  // ��Ʈ���� ����Ʈ�� �����Ű�� ���� NoteList ����Ʈ ����

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

        // ���� �ֱ⸶�� ��Ʈ ����(���� ���� ���ڿ� ���� ��Ʈ �������� ���� ����)
        if (currentTime >= 60d / bpm)
        {
            CreateNote();
            currentTime -= 60d / bpm;
        }

        // ����
        if (NoteList.Count > 0) // ������ ���� ��Ʈ ����Ʈ�� 0�� �ʰ��̸�
        {
            if (Input.GetKeyDown(KeyCode.G) && !isRhythmKey)    // Ű �Է��� �޾��� ��
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
                //fades = 1.0f;   // fades �� 1.0���� �ʱ�ȭ
            }
            else if (NoteList[0].transform.localScale.x <= 0.8f)    // Ű �Է��� ���� ������ ��
            {
                Debug.Log("No HIT");
                theEffect.JudgementEffect(4);
                Destroy(NoteList[0]);
                NoteList.Remove(NoteList[0]);
                isRhythmKey = false;
            }
        }
    }

    /* // ������
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

    void RemoveNote()   // ��Ʈ ���� �Լ�
    {
        isRhythmKey = false;
        Destroy(NoteList[0]);
        NoteList.Remove(NoteList[0]);
    }

    IEnumerator Fade()  // ���̵� �ƿ� �� ��Ʈ ���� �Լ�
    {
        for (float i = 1.0f; i >= 0f; i -= 0.01f)
        {
            NoteList[0].GetComponent<Image>().color = new Color(1f, 1f, 1f, i);
            yield return null;
        }
        RemoveNote();
    }
}
