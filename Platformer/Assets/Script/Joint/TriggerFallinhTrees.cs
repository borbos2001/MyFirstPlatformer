using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFallinhTrees : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "adventurer")
        {
            _rigidbody2D.constraints = RigidbodyConstraints2D.None;
        }
    }
}
