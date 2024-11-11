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
    [SerializeField] private FloatingPoints floatingText;

    private SpriteRenderer spriteRenderer;
    private Material baseMaterial;

    [SerializeField] private List<FloatingPoints> floatingPointsPool = new List<FloatingPoints>();

    public List<FloatingPoints> Pool => floatingPointsPool;


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
        ShowFloatingPoint(damage);

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void ShowFloatingPoint(int damage)
    {
        var temp = CheckForAvailabeText();

        if (!temp)
        {
            temp = AddToPool();
        }

        temp.Text.text = damage.ToString();

        temp.gameObject.SetActive(true);
        StartCoroutine(temp.Float(1f, 6f, 2f));
    }
    private FloatingPoints CheckForAvailabeText()
    {
        foreach(var text in floatingPointsPool)
        {
            if (text.IsAvailable)
            {
                return text;
            }
        }
        return null;
    }
    private FloatingPoints AddToPool()
    {
        var temp = Instantiate(floatingText,transform.position + new Vector3(0f, 1.5f, 0f), Quaternion.identity, transform);
        floatingPointsPool.Add(temp);

        temp.gameObject.SetActive(false);
        return temp;
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
