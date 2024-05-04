using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UI;


public class HeartSystem : MonoBehaviour, IDamageable
{
    public GameObject MenuRestart;
    public float Health
    {
        set
        {
            vida = value;

            if (vida <= 0)
            {
                animator.SetBool("isAlive", false);
                Targetable = false;
                MenuRestart.SetActive(true);
            }
        }
        get
        {
            return vida;
        }
    }

    public float vida = 5f;
    public float vidaMaxima = 5f;
    bool isAlive = true;
    public Animator animator;
    private Rigidbody2D _playerRB2D;

    public Image[] coracao;
    public Sprite cheio;
    public Sprite vazio;

    

    public bool _targetable = true;
    public bool Targetable
    {
        get { return _targetable; }
        set
        {
            _targetable = value;

            _playerRB2D.simulated = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", isAlive);
        _playerRB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthLogic();  
    }
    void HealthLogic()
    {
        if(vida > vidaMaxima) 
        {
            vida = vidaMaxima;
        }

        for (int i = 0; i < coracao.Length; i++)
        {
            if (i< vida)
            {
                coracao[i].sprite = cheio;
            }
            else
            {
                coracao[i].sprite = vazio;
            }

            if (i < vidaMaxima)
            {
                coracao[i].enabled = true;
            }
            else
            {
                coracao[i].enabled = false;
            }
        }
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        Health = Health - damage;
        _playerRB2D.AddForce(knockback, ForceMode2D.Impulse);
    }

    public void OnHit(float damage)
    {
        Health = Health - damage;
    }

    public void OnObjectDestroyed()
    {
        throw new System.NotImplementedException();
    }
}

