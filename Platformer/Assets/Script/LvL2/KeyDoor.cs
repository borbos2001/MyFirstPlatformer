using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    private bool _key = false;
    private bool _stay = false;
    public void HaveKey()
    {
        _key = true;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && _stay ==true)
        {
            Check();
        }
    }
    private void Check()
    {
        if (_key)
        {
            _door.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "adventurer")
        {
            _stay = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "adventurer")
        {
            _stay = false;
        }
    }
}
