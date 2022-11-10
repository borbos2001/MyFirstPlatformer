using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpText : MonoBehaviour
{
    [SerializeField] private GameObject _text;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _text.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _text.SetActive(false);
    }
}
