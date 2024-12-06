using Unity.VisualScripting;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField] private string key;

    private void OnTriggerEnter2D(Collider2D col){
        CutsceneManager.Instance.StartCutscene(key);
        this.enabled = false;
    }
}
