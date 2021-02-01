﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    public HpBar hpBar;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    public FadeEffect fadeEffect;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (hpBar.playerHp == 0) //게임 종료
        {
            anim.SetTrigger("isDead");
            fadeEffect.StartCoroutine(fadeEffect.Fade(0, 1));//페이드 아웃
            Invoke("LoadGameOver", 5);
        }
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            hpBar.playerHp -= 10; //체력 감소
            spriteRenderer.color = new Color(255, 0, 0, 1); //빨간색
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }
    }
}
