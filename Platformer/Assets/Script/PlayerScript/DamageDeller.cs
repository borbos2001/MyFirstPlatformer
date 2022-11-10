
using System.Collections;
using UnityEngine;

public class DamageDeller : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damageable"))
        {
            if (collision.gameObject.name == "adventurer")
            {
                collision.gameObject.GetComponent<HeartSprite>().HealthSpriteControl();
            }
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
    private void Awake()
    {
        StartCoroutine(Dilay());
    }
    private IEnumerator Dilay()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
