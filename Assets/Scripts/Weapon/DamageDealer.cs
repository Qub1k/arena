using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        var character = col.GetComponent<CharacterStats>();

        if (character != null)
        {
            character.TakeDamage(14);
        }
    }
}
