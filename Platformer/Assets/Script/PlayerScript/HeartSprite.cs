using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HeartSprite : MonoBehaviour
{
    private int _numHeart = 0;
    [SerializeField] private GameObject Heart1;
    [SerializeField] private GameObject Heart2;
    [SerializeField] private GameObject Heart3;
    [SerializeField] private GameObject _deadMessage;
    [SerializeField] private Animator _animator;
    public void HealthSpriteControl()
    {

            switch (_numHeart)
            {
                case (0):
                    Heart3.SetActive(false);
                    _numHeart++;
                    break;
                case (1):
                    Heart2.SetActive(false);
                    _numHeart++;
                    break;
                case (2):
                    Heart1.SetActive(false);
                    _numHeart++;
                    StartCoroutine(DilayDead());
                    break;
            }
        
    }
    private IEnumerator DilayDead()
    {
        _animator.SetTrigger("dead");
        yield return new WaitForSeconds(1.5f);
        _deadMessage.SetActive(true);
    }


}


