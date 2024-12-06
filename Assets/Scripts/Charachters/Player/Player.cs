using UnityEngine;

public class Player : MonoBehaviour
{
    private DamageCollider damageCollider;
    private Animator anim;

    private void Start()
    {
        damageCollider = GetComponentInChildren<DamageCollider>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            CutsceneManager.Instance.StartCutscene("1");
        }
    }
}
