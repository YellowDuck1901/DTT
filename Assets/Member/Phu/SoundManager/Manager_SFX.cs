using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_SFX : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Game1")]
    public AudioClip speakLeftEnemy;
    public AudioClip speakRightEnemy;
    public AudioClip speakRightCharacter;
    public AudioClip speakLeftCharacter;
    public AudioClip winG1;
    public AudioClip loseG1;


    [Header("Game2")]
    public AudioClip fire;
    public AudioClip collisionBullet;
    public AudioClip apperSlime;
    public AudioClip apperBat;
    public AudioClip apperGhoot;
    public AudioClip deadEnemy;
    public AudioClip winG2;
    public AudioClip loseG2;

    [Header("Game3")]
    public AudioClip Fly;
    public AudioClip Ground;
    public AudioClip winG3;
    public AudioClip loseG3;
    public static Manager_SFX instance;

    AudioSource audio;
    static float volumeDefault_SFX;
    static float pitchDefault_SFX;
    static int priorityDefault_SFX;
    // Use this for initialization
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        volumeDefault_SFX = audio.volume;
        pitchDefault_SFX = audio.pitch;
        priorityDefault_SFX = audio.priority;
        instance = this;
    }
    public static void PlaySound_SFX(soundsGame currentSound)
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
        }
    }

    public static void PlaySound_SFX(soundsGame currentSound, float volume, float pitch, int priority = 128)
    {
        var audioSource = instance.GetComponent<AudioSource>();
        audioSource.priority = priority;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        switch (currentSound)
        {
            case soundsGame.speakLeftCharacter:
                {
                    audioSource.clip = instance.speakLeftCharacter;
                    audioSource.Play();
                    resetSettingSFX();
                }
                break;
            case soundsGame.speakRightCharacter:
                {
                    audioSource.clip = instance.speakRightCharacter;
                    audioSource.Play();
                    resetSettingSFX();
                }
                break;
            case soundsGame.speakLeftEnemy:
                {
                    audioSource.clip = instance.speakLeftEnemy;
                    audioSource.Play();
                    resetSettingSFX();
                }
                break;
            case soundsGame.speakRightEnemy:
                {
                    audioSource.clip = instance.speakRightEnemy;
                    audioSource.Play();
                    resetSettingSFX();
                }
                break;
            case soundsGame.winG1:
                {
                    audioSource.clip = instance.winG1;
                    audioSource.Play();
                    resetSettingSFX();
                }
                break;
            case soundsGame.loseG1:
                {
                    audioSource.clip = instance.loseG1;
                    audioSource.Play();
                    resetSettingSFX();
                }
                break;
            case soundsGame.fire:
                {
                    audioSource.clip = instance.fire;
                    audioSource.Play();
                    resetSettingSFX();
                }
                break;
            case soundsGame.collisionBullet:
                {
                    audioSource.clip = instance.collisionBullet;
                    audioSource.Play();
                    resetSettingSFX();
                }
                break;
            case soundsGame.apperSlime:
                {
                    audioSource.clip = instance.apperSlime;
                    audioSource.Play();
                    resetSettingSFX();
                }
                break;
            case soundsGame.apperBat:
                {
                    audioSource.clip = instance.apperBat;
                    audioSource.Play();
                    resetSettingSFX();
                }
                break;
            case soundsGame.apperGhoot:
                {
                    audioSource.clip = instance.apperGhoot;
                    audioSource.Play();
                    resetSettingSFX();
                }
                break;
            case soundsGame.deadEnemy:
                {
                    audioSource.clip = instance.deadEnemy;
                    audioSource.Play();
                    resetSettingSFX();
                }
                break;
            case soundsGame.winG2:
                {
                    audioSource.clip = instance.winG2;
                    audioSource.Play();
                    resetSettingSFX();
                }
                break;
            case soundsGame.loseG2:
                {
                    audioSource.clip = instance.loseG2;
                    audioSource.Play();
                    resetSettingSFX();
                }
                break;
            
            case soundsGame.fly:
                {
                    audioSource.clip = instance.Fly;
                    audioSource.Play();
                    resetSettingSFX();
                }
                break;
            case soundsGame.ground:
                {
                    audioSource.clip = instance.Ground;
                    audioSource.Play();
                    resetSettingSFX();
                }
                break;
            case soundsGame.winG3:
                {
                    audioSource.clip = instance.winG3;
                    audioSource.Play();
                    resetSettingSFX();
                }
                break;
            case soundsGame.loseG3:
                {
                    audioSource.clip = instance.loseG3;
                    audioSource.Play();
                    resetSettingSFX();
                }
                break;
        }

    }

    public static void resetSettingSFX()
    {
        var audioSource = instance.GetComponent<AudioSource>();
        audioSource.priority = priorityDefault_SFX;
        audioSource.volume = volumeDefault_SFX;
        audioSource.pitch = pitchDefault_SFX;
    }

    public static void stopPlay()
    {
        var audioSource = instance.GetComponent<AudioSource>();
        audioSource.Stop();
    }
}
