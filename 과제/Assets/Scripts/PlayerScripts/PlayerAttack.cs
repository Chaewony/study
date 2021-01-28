using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Collider2D attackCol; //칼 콜리더

    [SerializeField]
    private float waitTime; //공격 전까지 걸리는 시간
    [SerializeField]
    private float attackTime; //공격 에니메이션 실행 시간

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!this.spriteRenderer.flipX) //우측
        {
            attackCol.transform.eulerAngles = new Vector3(0, 0, 0); //칼 콜리더 우측
        }
        if (this.spriteRenderer.flipX) //좌측
        {
            attackCol.transform.eulerAngles = new Vector3(0, 180, 0); //칼 콜리더 좌측
        }
    }

    //키 입력 없을 시 콜라이더 비활성화 하는 법
    public IEnumerator Attack() //리턴 값 있어야 함, 업데이트함수와 별개로 작동하는 함수(코루틴), 이 기능이 필요한 예: 쿨타임
    {
        attackCol.gameObject.SetActive(true); //어택 컴포넌트 활성화

        anim.SetBool("isAttacking", true);

        yield return new WaitForSeconds(waitTime);//공격 전 시간동안 모션 중지

        //여기 실행
        yield return new WaitForSeconds(attackTime);//공격 애니메이션 진행시간동안 중지
        
        anim.SetBool("isAttacking", false);

        attackCol.gameObject.SetActive(false); //어택 컴포넌트 비활성화
    }
}
