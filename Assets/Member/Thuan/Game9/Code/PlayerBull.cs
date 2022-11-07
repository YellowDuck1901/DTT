using Assets.Member.Thuan.Public;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
public delegate float BullPower();

public class PlayerBull : MonoBehaviour
{
    [SerializeField]
    LoadWinLose wl;

    [SerializeField]
    SelectLevel sl;

    Rigidbody2D m_Rigidbody;
    [Range(1.1f, 10f)]
    public float powerSup;
    BullPower Pull;
    private float ford() => Random.Range(10f, 15f);
    private bool isPower = false, enableHit = true,isDead = false;
    float offset = 1.5f;
    private Animator _animator;
    bool isTriggerWin, isTriggerLose, finish;


    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Rigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) | Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log(" click");
            isPower = true;
        }

    }
    private void FixedUpdate()
    {
        if (isPower)
        {
            m_Rigidbody.AddForce(Vector2.right * ford() * offset * powerSup * Time.fixedDeltaTime, ForceMode2D.Impulse);
            isPower = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SoundManager.instance.Play("Strike");
            _animator = gameObject.GetComponent<Animator>();
            StartCoroutine(Wait());
            //animation play one time
        }
    }

    IEnumerator Wait()
    {
        //animation hit play one time
        if (enableHit && !isDead)
        {
            _animator.Play("Hit", -1, 0f);
        }
        yield return new WaitForSeconds(.1f);
        if (enableHit && !isDead)
            _animator.Play("Run");
    }

    void PlayerWin()
    {
        if (!finish)
        {
            finish = true;
            SoundManager.instance.Play("Win");
            SoundManager.instance.Stop("BackGround Music");
            LoadWinLose.loadWin(wl);
            sl.openSceneWithColdDown();
        }
    }

    void PlayerLose()
    {
        if (!finish)
        {
            finish = true;
            SoundManager.instance.Play("Lose");
            SoundManager.instance.Stop("BackGround Music");
            LoadWinLose.loadLose(wl);
            sl.openSceneWithColdDown();
        }
    }
    void dead()
    {
        isDead = true;
    }
}
