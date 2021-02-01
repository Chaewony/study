using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    //소드 공격
    [SerializeField]
    private Collider2D swordCol; //칼 콜리더
    /*[SerializeField]
    private float swordWaitTime; //공격 전까지 걸리는 시간*/
    [SerializeField]
    private float swordAttackTime; //공격 에니메이션 실행 시간

    //파이어볼 공격
    [SerializeField]
    private GameObject fireBall; //불 이펙트 오브젝트
    [SerializeField]
    private GameObject fireBallLeft; //불 이펙트 오브젝트
    /*[SerializeField]
    private float fireWaitTime; //공격 전까지 걸리는 시간*/
    [SerializeField]
    private float fireAttackTime; //공격 에니메이션 실행 시간

    //리듬 공격
    [SerializeField]
    private GameObject rhytnmUI;
    [SerializeField]
    private float rhythmAttackTime; //공격 지속 시간

    private bool isRight;
    public bool isFire;
    public bool isSword;
    public bool isRhythm;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isFire = true;
        isSword = true;
        isRhythm = true;
    }

    void Update()
    {
        if (!this.spriteRenderer.flipX) //우측
        {
            swordCol.transform.eulerAngles = new Vector3(0, 0, 0); //칼 콜리더 우측
            isRight = true;
        }
        if (this.spriteRenderer.flipX) //좌측
        {
            swordCol.transform.eulerAngles = new Vector3(0, 180, 0); //칼 콜리더 좌측
            isRight = false;
        }
    }

    //키 입력 없을 시 콜라이더 비활성화 하는 법
    public IEnumerator Sword() //리턴 값 있어야 함, 업데이트함수와 별개로 작동하는 함수(코루틴), 이 기능이 필요한 예: 쿨타임
    {
        if(isSword)
        {
            swordCol.gameObject.SetActive(true); //어택 컴포넌트 활성화
            anim.SetBool("isAttacking", true);
            //yield return new WaitForSeconds(swordWaitTime);//공격 전 시간동안 모션 중지
            yield return new WaitForSeconds(swordAttackTime);
            anim.SetBool("isAttacking", false);
            StartCoroutine(gameManager.SwordCool());//쿨타임 걸어주기
            isSword = false;//쿨타임동안 다시 못쓰게 하기
            swordCol.gameObject.SetActive(false); //어택 컴포넌트 비활성화
        }
    }

    public IEnumerator FireBall()
    {
        if(isRight&&isFire)//오른쪽 보고 있을 때
        {
            //Instantiate(fire, firePosition.transform.position,Quaternion.identity);//프리팹 사용 시
            fireBall.gameObject.SetActive(true); //활성화
            //yield return new WaitForSeconds(fireWaitTime); 이 다음줄에 다른 모션 중지하는 코드 적으면 됨
            yield return new WaitForSeconds(fireAttackTime);//공격 지속 시간
            StartCoroutine(gameManager.FireCool());//쿨타임 걸어주기
            isFire = false;//쿨타임동안 다시 못쓰게 하기
            fireBall.gameObject.SetActive(false); //어택 컴포넌트 비활성화
            //컴포넌트를 비활성화 시키는 방법으로 해주다 보니까 이 스크립트 밖에서 코루틴을 걸어줘야겠음

        }
        else if(!isRight&&isFire)//왼쪽 보고 있을 때
        {
            fireBallLeft.gameObject.SetActive(true);
            //yield return new WaitForSeconds(fireWaitTime);
            yield return new WaitForSeconds(fireAttackTime);
            StartCoroutine(gameManager.FireCool());//쿨타임 걸어주기
            isFire = false;//쿨타임동안 다시 못쓰게 하기
            fireBallLeft.gameObject.SetActive(false); //어택 컴포넌트 비활성화
        }
    }

    public IEnumerator Rhythm() //여기 고쳐야 됨
    {
        if(isRhythm)
        {
            rhytnmUI.gameObject.SetActive(true);
            //yield return new WaitForSeconds(5);//공격 전 시간동안 모션 중지
            //여기 실행
            yield return new WaitForSeconds(rhythmAttackTime);//공격 지속 시간
            StartCoroutine(gameManager.RhythmCool());//쿨타임 걸어주기
            rhytnmUI.gameObject.SetActive(false); //시간이 지나면 비활성화
        }
    }

    /*private void StopAttack()
    {
        attackRotine = null;
        anim.SetBool("isAttack", false);
    }*/
}
