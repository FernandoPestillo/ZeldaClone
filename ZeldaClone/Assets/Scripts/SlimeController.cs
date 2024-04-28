using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour, IDamageable
{
    bool isAlive = true;
    public Animator animator;
    public float Health {
        set
        {
            if (value < _health)
            {
                animator.SetTrigger("hit");
            }

            _health = value;

            if (_health <= 0)
            {
                animator.SetBool("isAlive", false);
                Targetable = false;
                // Destroy(gameObject);
            }
        }
        get
        {
            return _health;
        }
    }

    public bool Targetable { get { return _targetable; }
    set {
            _targetable = value;

            _slimeRB2D.simulated = value;
    } }

    public float _health = 3;
    public bool _targetable = true;

    
    public float        _moveSpeedSlime = 3.5f;
    private Vector2     _slimeDirection;
    private Rigidbody2D _slimeRB2D;

    public DetectionController  _detectionArea;

    private SpriteRenderer      _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", isAlive);
        _slimeRB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _slimeDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));   
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void FixedUpdate()
    {
        if(_detectionArea.detectedObjs.Count > 0)
        {
            _slimeDirection = (_detectionArea.detectedObjs[0].transform.position - transform.position).normalized;

            _slimeRB2D.MovePosition(_slimeRB2D.position +  _slimeDirection * _moveSpeedSlime * Time.fixedDeltaTime);

            if(_slimeDirection.x > 0)
            {
                _spriteRenderer.flipX = false;
            }
            else if(_slimeDirection.x < 0)
            {
                _spriteRenderer.flipX =  true;
            }
        }
    }


    public void OnHit(float damage, Vector2 knockback)
    {
        Health = Health - damage;

        // Aplicando física ao receber ataque
        _slimeRB2D.AddForce(knockback);
        Debug.Log("knockback:" + knockback);
    }

    public void OnHit(float damage)
    {
        Health = Health - damage;
    }

    public void OnObjectDestroyed()
    {
        Destroy(gameObject);
    }
}
