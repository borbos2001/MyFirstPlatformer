using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToFire : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _enemyPoint;
    [SerializeField] private Animator _animatorEnemy;
    [SerializeField] private float _fiteSpeed;
    [SerializeField] private Transform _firePoint ;
    private Walk _walk;
    int i = 1;
    private bool _attack = true;
    private void Awake()
    {
        _walk = _enemyPoint.GetComponent<Walk>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
       
        if (other.gameObject.name == "adventurer")
        {
            
            if (_attack == true)
            {
                _walk.enabled = false;
                StartCoroutine(DilayBeforeAttack());
                _attack = false;
            }
        }
    }
    private IEnumerator DilayBeforeAttack()
    {
        _animatorEnemy.SetTrigger("fire");
        yield return new WaitForSeconds(1.5f);
        GameObject currentBullet = Instantiate(_bullet,_firePoint.position,Quaternion.identity);
        Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();
        if (_enemyPoint.transform.rotation.y == 0)
        {
            currentBulletVelocity.velocity = new Vector2(_fiteSpeed * -1,0);
        }
        else
        {
            currentBulletVelocity.velocity = new Vector2(_fiteSpeed * 1, 0);
        }
        yield return new WaitForSeconds(1.5f);
        _attack = true;
        _walk.enabled = true;

    }
}
