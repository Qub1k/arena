using System.Collections;
using System.Net.Http.Headers;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public IEnumerator Shake(float _duration, float _magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while(elapsed < _duration)
        {
            float x = Random.Range(-1f, 1f) * _magnitude;
            float y = Random.Range(-1f, 1f) * _magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);
            
            elapsed += Time.fixedDeltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
