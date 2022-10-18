using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum soundsGame
{
    speakLeftEnemy,
    speakRightEnemy,
    speakRightCharacter,
    speakLeftCharacter,
    winG1,
    loseG1,
    backgroundG1,
    fire,
    collisionBullet,
    apperSlime,
    apperBat,
    apperGhoot,
    deadEnemy,
    winG2,
    loseG2,
    backgroundG2,
    fly,
    ground,
    winG3,
    loseG3,
    backgroundG3
}


public class G3_Sound : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Game1")]
    public AudioClip speakLeftEnemy;
    public AudioClip speakRightEnemy;
    public AudioClip speakRightCharacter;
    public AudioClip speakLeftCharacter;
    public AudioClip winG1;
    public AudioClip loseG1;
    public AudioClip backgroundG1;

    [Header("Game2")]
    public AudioClip fire;
    public AudioClip collisionBullet;
    public AudioClip apperSlime;
    public AudioClip apperBat;
    public AudioClip apperGhoot;
    public AudioClip deadEnemy;
    public AudioClip winG2;
    public AudioClip loseG2;
    public AudioClip backgroundG2;

    [Header("Game3")]
    public AudioClip Fly;
    public AudioClip Ground;
    public AudioClip winG3;
    public AudioClip loseG3;
    public AudioClip backgroundG3;
    public static G3_Sound instance;

        // Use this for initialization
        void Start()
        {
            instance = this;
        }
        public static void PlaySound(soundsGame currentSound)
        {
            switch (currentSound)
            {
                case soundsGame.speakLeftCharacter:
                    {
                        instance.GetComponent<AudioSource>().PlayOneShot(instance.speakLeftCharacter);
                    }
                    break;
                case soundsGame.speakRightCharacter:
                    {
                        instance.GetComponent<AudioSource>().PlayOneShot(instance.speakRightCharacter);
                    }
                    break;
                case soundsGame.speakLeftEnemy:
                    {
                        instance.GetComponent<AudioSource>().PlayOneShot(instance.speakLeftEnemy);
                    }
                    break;
                case soundsGame.speakRightEnemy:
                    {
                        instance.GetComponent<AudioSource>().PlayOneShot(instance.speakRightEnemy);
                    }
                    break;
                case soundsGame.winG1:
                    {
                        instance.GetComponent<AudioSource>().PlayOneShot(instance.winG1);
                    }
                    break;
                case soundsGame.loseG1:
                    {
                        instance.GetComponent<AudioSource>().PlayOneShot(instance.loseG1);
                    }
                    break;
                case soundsGame.backgroundG1:
                    {
                        var a = instance.GetComponent<AudioSource>();
                        a.clip = instance.backgroundG2;
                        a.loop = true;
                        //a.volume = 0.5f;
                        a.Play();
                }
                    break;
            case soundsGame.fire:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.fire);
                }
                break;
            case soundsGame.collisionBullet:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.collisionBullet);
                }
                break;
            case soundsGame.apperSlime:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.apperSlime);
                }
                break;
            case soundsGame.apperBat:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.apperBat);
                }
                break;
            case soundsGame.apperGhoot:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.apperGhoot);
                }
                break;
            case soundsGame.deadEnemy:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.deadEnemy);
                }
                break;
            case soundsGame.winG2:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.winG2);
                }
                break;
            case soundsGame.loseG2:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.loseG2);
                }
                break;
            case soundsGame.backgroundG2:
                {
                    var a = instance.GetComponent<AudioSource>();
                    a.clip = instance.backgroundG2;
                    a.loop = true;
                    //a.volume = 0.5f;
                    a.Play();
                }
                break;
            case soundsGame.fly:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.Fly);
                }
                break;
            case soundsGame.ground:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.Ground);
                }
                break;
            case soundsGame.winG3:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.winG3);
                }
                break;
            case soundsGame.loseG3:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.loseG3);
                }
                break;
            case soundsGame.backgroundG3:
                {
                    var a = instance.GetComponent<AudioSource>();
                    a.clip = instance.backgroundG3;
                    a.loop = true;
                    a.volume = 0.2f;
                    a.Play();
                }
                break;
        }
        }
    }
