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
        if (Input.GetMouseButtonDown(0)) 
        {
            ChangeAnimation("attack1", 0f);
        }

        if (Input.GetMouseButtonDown(1))
        {
            ChangeAnimation("attack3", 0f);
        }
    }

    private void ChangeAnimation(string animation, float duration)
    {
        anim.CrossFade(animation, duration);
    }
    public void EnableDamageCollider()
    {
        damageCollider.Col.enabled = true;
    }
    public void DisableDamageCollider()
    {
        damageCollider.Col.enabled = false;
    }
}
