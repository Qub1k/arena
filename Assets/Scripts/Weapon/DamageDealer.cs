using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        var character = col.GetComponent<CharacterStats>();

        if (character != null)
        {
            character.TakeDamage(14);
        }
    }
}
