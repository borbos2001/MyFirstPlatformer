using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToAttack : MonoBehaviour
{
    [SerializeField] private GameObject _wepon;
    [SerializeField] private Animator _animatorEnemy;
    [SerializeField] private GameObject _entity;

    private Walk _walk;
    int i = 1;
    private bool _attack = true;
    private void Awake()
    {
       _walk = _entity.GetComponent<Walk>();

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "adventurer")
        {
            
            if (_attack == true)
            {
                _walk.enabled = false;
                _animatorEnemy.SetTrigger("Hit");
                StartCoroutine(Dilay());
                _attack = false;
                _animatorEnemy.SetFloat("Velocity", 0);
            }
        }
    }
    private IEnumerator Dilay()
    {
        yield return new WaitForSeconds(1f);
        _wepon.SetActive(true);
        yield return new WaitForSeconds(0.9f);
        _wepon.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        _attack = true;
        _walk.enabled = true;
    }
}
