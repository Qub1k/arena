using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FloatingPoints : MonoBehaviour
{
    public IEnumerator Float(float duration, float displacement, float speed)
    {
        gameObject.SetActive(true);

        float elapsed = 0f;
        Vector3 initialPos = transform.position;
        Vector3 targetPos = new Vector3(initialPos.x, initialPos.y + displacement, initialPos.z);

        while(elapsed > duration){
            transform.position = Vector3.Lerp(initialPos, targetPos, speed * Time.fixedDeltaTime);
            elapsed += Time.fixedDeltaTime;

            yield return null;
        }

        gameObject.SetActive(false);
    }
}
