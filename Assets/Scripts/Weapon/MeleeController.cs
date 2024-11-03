using UnityEngine;

public class MeleeController : MonoBehaviour
{
    [SerializeField] private float radius;         
    [SerializeField] private float speed = 1.0f;      
    
    private Vector3 centerPosition;

    private Animator anim;
    private string currentAnimation;

    private float angle;
    private int posIndex = 2;

    void Start()
    {
        radius = Vector2.Distance(transform.position, transform.parent.position);
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float mousePos = Input.mousePosition.y;

        if (Input.GetMouseButtonDown(0))
        { 
            if (mousePos > 630) anim.SetTrigger("highHit");
            else if (mousePos < 450) Debug.Log("no animation yet");
            else anim.SetTrigger("middleHit");
        }



        if (mousePos > 630) angle = Mathf.PI/8;
        else if (mousePos < 450) angle = -Mathf.PI / 8;
        else angle = 0;

        Quaternion targetRotation = Quaternion.Euler(transform.parent.rotation.x, transform.parent.rotation.y, 
            transform.parent.rotation.z + Mathf.Rad2Deg * angle * transform.parent.parent.localScale.x);

        transform.parent.rotation = Quaternion.Lerp(transform.parent.rotation, targetRotation, speed * Time.deltaTime);
    }

    private void ChangeAnimation(string animation, float crossfade = .2f)
    {
        if (currentAnimation != animation)
        {
            currentAnimation = animation;
            anim.CrossFade(animation, crossfade);
        }
    }
}
