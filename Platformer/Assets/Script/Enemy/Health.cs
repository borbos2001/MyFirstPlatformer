using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private GameObject _wepon;
    private Walk _walk;
    private Rigidbody2D _entity;
    private Collider2D _colliderEntity;
    private Animator _animEntity;
    private float _health;
    private bool _isAlive;


    private void Awake()
    {
        _walk = GetComponent<Walk>();
        _health = _maxHealth;
        _isAlive = true;
        _animEntity = GetComponent<Animator>();
        _colliderEntity = GetComponent<Collider2D>();
        _entity = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        Debug.Log(_health);
        CheckIsAlive();
    }

    private void CheckIsAlive()
    {
        if (_health > 0)
        {
            _isAlive = true;
        }
        else
        {
            
            _animEntity.SetTrigger("dead");
            _isAlive = false;
            _wepon.SetActive(false);
            _entity.bodyType = RigidbodyType2D.Static;
            _colliderEntity.enabled = false;
        }
    }


}

