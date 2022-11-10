using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private bool _canHit = true;
    [SerializeField] private GameObject _triggerSword;
    private Animator _animatorPlayer;
    void Start()
    {
        _animatorPlayer = GetComponent<Animator>();
    }
    public void SwordStrike(bool Impact)
    {
        if (_canHit && Impact == true)
        {
            _canHit = false;
            _animatorPlayer.SetTrigger("Hit");
            StartCoroutine(Dilay());
        }

    }
    private IEnumerator Dilay()
    {
        yield return new WaitForSeconds(0.9f);
        _triggerSword.SetActive(true);
        yield return new WaitForSeconds(1f);
        _triggerSword.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        _canHit = true;

    }
}
