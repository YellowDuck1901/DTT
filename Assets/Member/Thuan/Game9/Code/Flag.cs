using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField]
    Animator PlayerAnim;

    [SerializeField]
    Animator EnemyAnim;

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag == "Player" ? "Player Win" : "Enemy Win");
        if (gameObject.name.Equals("PlayerFlag") && other.gameObject.name.Equals("Player"))
        {
            EnemyAnim.SetTrigger("Die");
        }
        else if(gameObject.name.Equals("EnemyFlag") && other.gameObject.name.Equals("Enemy"))
        {
            PlayerAnim.SetTrigger("Die");
            //SceneManager.LoadScene("Game10");
        }
    }

    
}
