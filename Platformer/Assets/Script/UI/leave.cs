using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leave : MonoBehaviour
{
    [SerializeField] private GameObject _boss;
    [SerializeField] private GameObject _hpBoss;
    [SerializeField] private GameObject _hp;
    private BoxCollider2D _box;
    private void Awake()
    {
        _box = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "adventurer")
        {
            _boss.SetActive(true);
            _box.isTrigger = false;
            _hpBoss.SetActive(true);
            _hp.SetActive(true);
        }
    }
}
