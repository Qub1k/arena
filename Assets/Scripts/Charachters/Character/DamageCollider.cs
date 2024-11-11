using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    private Collider2D col;

    public Collider2D Col => col;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        col.gameObject.SetActive(true);
        col.isTrigger = true;
        col.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        int damage = Random.Range(13, 16);

        if (col.CompareTag("Hittable"))
        {
            var Character = col.GetComponent<CharacterStats>();

            if (Character != null)
            {
                Character.TakeDamage(damage);
            }
        }
        
    }
}
