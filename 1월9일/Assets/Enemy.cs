using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private State currentState; //State를 상속

    // Start is called before the first frame update
    void Start()
    {
        SetState(new MoveState());
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update();
    }

    public void SetState(State nextState)
    {
        if (currentState != null) // 예외처리
        {
            currentState.onExit();
        }

        currentState = nextState; //현재상태를 다음상태로 바꿔줌
        currentState.onEnter(this);
    }
}
