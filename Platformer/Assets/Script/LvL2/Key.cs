using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    [SerializeField] private GameObject _key;
    private KeyDoor _keyDoor;
    private void Awake()
    {
        _keyDoor =_door.GetComponent<KeyDoor>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "adventurer")
        {
            _keyDoor.HaveKey();
            Destroy(_key);
        }
    }
}
