using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyLaser : MonoBehaviour
{
    private float _corutineTime;
    private float _maxTime =2;
    private SpriteRenderer _spriteRenderer;
    private Color _color;
    private BoxCollider2D _boxCollider;
    private bool _demageStart =true;
    private AudioSource _audioSource;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); 
        _boxCollider = GetComponent<BoxCollider2D>();
        _audioSource = GetComponent<AudioSource>();
        _color = _spriteRenderer.color;
        _color.a = 0;
        _spriteRenderer.color = _color;
        _corutineTime = 0;
    }
    private void Update()
    {
        _corutineTime += Time.deltaTime;
        if ( 0.5 >_corutineTime / _maxTime)
        {
            _color.a = _corutineTime/_maxTime;
            _spriteRenderer.color = _color;
        }
        else
        {
            if (_demageStart)
            {
                _demageStart = false;
                StartCoroutine(ThirdDilay());
            }
        }
    }
    private IEnumerator ThirdDilay()
    {
        yield return new WaitForSeconds(0.5f);
        _audioSource.Play();
        _color.a = 1;
        _spriteRenderer.color = _color;
        _boxCollider.enabled = true;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
