using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlace : MonoBehaviour
{
    private HeartSprite _sprite;
    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "adventurer")
        {
            _sprite = collision.gameObject.GetComponent<HeartSprite>();
            for (int i = 0; i < 3; i++)
            {
                _sprite.HealthSpriteControl();
            }
        }
    }
}
