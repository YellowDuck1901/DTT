using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEditor.Animations;
using UnityEngine;

delegate bool ChickenAction();
public class Core : MonoBehaviour
{
    ChickenAction _action;
    private Rigidbody2D rb_Chicken;
    [Range(0f, 10f), SerializeField, Tooltip("Speed of the chicken")]
    private float speed;
    [SerializeField, Tooltip("power of the chicken jumb")]
    private float powerJuping;
    private Animator animator;
    private ActionState _actionState;
    [SerializeField]
    private List<Collision2D> land;


    enum ActionState
    {
        Jumping,
        Running
    }
    // Start is called before the first frame update
    void Start()
    {
        rb_Chicken = GetComponent<Rigidbody2D>();
        speed = 5; // speed of chicken
        powerJuping = 5; // power of chicken jump
        _action = new ChickenAction(Run);
        animator = GetComponent<Animator>();
        land = new List<Collision2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0)) // if mouse left click
        {
            _action = Jump;
        }

    }
    private void FixedUpdate()
    {
        if (_action())
        {
            _action = Run;
        }
    }


    //Action

    void Idle()
    {
        rb_Chicken.velocity = Vector2.zero;
    }
    bool Jump()
    {
        Debug.Log($"Pause Jump, land>> {land.Count}");
        if (_actionState != ActionState.Jumping)
        {
            animator.SetBool("Jump", true);
            rb_Chicken.AddForce(Vector2.up * powerJuping, ForceMode2D.Impulse);
        }
        else
        {
            var check = land.Any(x => x.gameObject.tag == "land");
            if (check)
            {
                animator.SetBool("Jump", false);
                return true;
            }
        }
        _actionState = ActionState.Jumping;
        return false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Add {collision.gameObject.tag}");
        land.Add(collision);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log($"Remove {collision.gameObject.tag}");
        land.Remove(collision);
        Debug.Log($"Pause Jump, land>> {land.Count}");
    }

    bool Run()
    {
        //rb_Chicken.position += Vector2.right * speed * Time.deltaTime;
        _actionState = ActionState.Running;
        return false;
    }

}
