using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    private float waitTime; //공격 전까지 걸리는 시간
    [SerializeField]
    private float attackTime; //공격 에니메이션 실행 시간

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    IEnumerator Attack() //리턴 값 있어야 함, 업데이트함수와 별개로 작동하는 함수(코루틴), 이 기능이 필요한 예: 쿨타임
    {
        anim.SetBool("isAttacking",true);

        yield return new WaitForSeconds(waitTime);//공격 전 모션동안 중지

        //여기 실행
        yield return new WaitForSeconds(attackTime);//공격 애니메이션 진행시간동안 중지
        
        anim.SetBool("isAttacking",false);
    }
}
