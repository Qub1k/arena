using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FloatingPoints : MonoBehaviour
{
    private TextMesh text;
    private bool isAvailable = true;
    public TextMesh Text => text;
    public bool IsAvailable => isAvailable;

    private void OnEnable()
    {
        text = GetComponent<TextMesh>();
    }

    public IEnumerator Float(float duration, float displacement, float speed)
    {
        isAvailable = false;

        float elapsed = 0f;
        Vector3 initialPos = transform.position;
        Vector3 targetPos = new Vector3(initialPos.x, initialPos.y + displacement, initialPos.z);

        while(elapsed < duration){
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.fixedDeltaTime * speed);
            elapsed += Time.fixedDeltaTime;

            yield return null;
        }

        gameObject.SetActive(false);
        transform.position = initialPos;

        isAvailable = true;
    }
}
