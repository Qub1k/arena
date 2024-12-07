using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private float flashDuration;
    [SerializeField] private Material flashMaterial;

    private SpriteRenderer spriteRenderer;
    private Material baseMaterial;



    private void Start()
    {
        currentHealth = maxHealth;

        spriteRenderer = GetComponent<SpriteRenderer>();
        baseMaterial = spriteRenderer.material;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        StartCoroutine(Flash(flashDuration));
        StartCoroutine(CameraController.Instance.Shake(.15f, 0.03f));

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }


    IEnumerator Flash(float duration)
    {
        float elapsed = 0f;

        while(elapsed < flashDuration)
        {
            spriteRenderer.material = flashMaterial;
            elapsed += Time.fixedDeltaTime;
            yield return null;
        }
        spriteRenderer.material = baseMaterial; 
    }

    IEnumerator ShowDamage(int damage)
    {
        yield break;
    }
}
