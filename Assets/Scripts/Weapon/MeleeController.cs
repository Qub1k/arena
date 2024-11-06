using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeleeController : MonoBehaviour
{
    [SerializeField] private float radius;         
    [SerializeField] private float speed = 1.0f;      
    
    private Vector3 centerPosition;

    private Animator anim;
    private string currentAnimation;

    private float angle;

    void Start()
    {
        radius = Vector2.Distance(transform.position, transform.parent.position);
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float mousePosY = Mouse.current.position.ReadValue().y;


        if (Input.GetMouseButtonDown(0))
        {
            if (mousePosY > 630) anim.SetTrigger("highHit");
            else if (mousePosY < 450) Debug.Log("no animation yet");
            else anim.SetTrigger("middleHit");
        }

        if (mousePosY > 630) angle = Mathf.PI/8;
        else if (mousePosY < 450) angle = -Mathf.PI / 8;
        else angle = 0;

        Quaternion targetRotation = Quaternion.Euler(transform.parent.rotation.x, transform.parent.rotation.y, 
            transform.parent.rotation.z + Mathf.Rad2Deg * angle * transform.parent.parent.localScale.x);

        transform.parent.rotation = Quaternion.Lerp(transform.parent.rotation, targetRotation, speed * Time.deltaTime);
    }
}
