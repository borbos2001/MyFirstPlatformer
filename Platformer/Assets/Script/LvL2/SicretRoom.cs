using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SicretRoom : MonoBehaviour
{
    [SerializeField] private GameObject _secret;
    [SerializeField] private GameObject _chest1;
    [SerializeField] private GameObject _chest2;
    [SerializeField] private GameObject _key;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "adventurer")
        {
            _secret.SetActive(false);
            StartCoroutine(time());
        }
    }
    private IEnumerator time()
    {
    yield return new WaitForSeconds(1.5f);
    _chest1.SetActive(false);
    _chest2.SetActive(true);
    _key.SetActive(true);
    }
}
