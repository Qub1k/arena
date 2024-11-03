using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    public PolygonCollider2D damageCollider;

    private void Awake()
    {
        damageCollider = GetComponent<PolygonCollider2D>();
        damageCollider.gameObject.SetActive(true);
        damageCollider.isTrigger = true;
        damageCollider.enabled = false;
    }

    public void EnableDamageCollider()
    {
        damageCollider.enabled = true;
    }
    public void DisableDamageCollider()
    {
        damageCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("thy");
        if (col.CompareTag("Hittable"))
        {
            var Character = col.GetComponent<CharacterStats>();

            if (Character != null)
            {
                Character.TakeDamage(15);
            }
        }
        
    }
}
