using System.Collections;
using UnityEngine;

public class SpecialAttacks : MonoBehaviour
{
    [SerializeField] private LayerMask damageMask;

    private DamageCollider damageCollider;

    private void Start()
    {
        damageCollider = GetComponentInChildren<DamageCollider>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            StartCoroutine(HandleUppercut());
        }
    }
    public IEnumerator HandleUppercut()
    {
        Collider2D enemy = Physics2D.OverlapCircle(damageCollider.transform.position, .5f, damageMask);

        if (enemy != null) 
        {
            enemy.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 20 + Vector2.right*10, ForceMode2D.Impulse);
        }

        yield return null;
    }
}
