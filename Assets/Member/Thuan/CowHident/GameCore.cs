using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
delegate void OnCowHidentEvent();
public class GameCore : MonoBehaviour
{
    [SerializeField]
    private AudioSource AudioSource;
    [SerializeField]
    private AudioClip Cowsound;

    private OnCowHidentEvent eventStart;
    private OnCowHidentEvent eventCheckClick;
    private OnCowHidentEvent eventEnd;

    private const float TimePlaySound = 1.5f;
    private const float TimeFadeIn = 1.5f;
    // Start is called before the first frame update
    private void Start()
    {
        //event start of game
        eventStart = GameObjectHide;
        eventStart += RandomPosition;

        //event check click ever gamer click on the screen
        eventCheckClick = GamePlay;

        //event end of game
        eventEnd = FadeIn;
        //event start of game
        eventStart();
    }

    /// <summary>
    /// game object hide from screen
    /// </summary>
    private void GameObjectHide()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0f);
    }

    /// <summary>
    /// Game object random position in screen with offset of GameObject
    /// </summary>
    public void RandomPosition()
    {
        //get width of screen
        float width = Camera.main.orthographicSize * Screen.width / Screen.height;
        //get height of screen
        float height = Camera.main.orthographicSize;

        //get width gameObject
        var _objectWidth = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        //get height gameObject
        var _objectHeight = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;

        //get min x of screen
        var minX = -width / 2 + _objectWidth / 2;
        //get max x of screen
        var maxX = width / 2 - _objectWidth / 2;
        //get min y of screen
        var minY = -height / 2 + _objectHeight / 2;
        //get max y of screen
        var maxY = height / 2 - _objectHeight / 2;
        Camera cam = Camera.main;
        //random position in screen
        transform.position = new Vector3(Random.Range(minX, maxX) - _objectWidth, Random.Range(minY, maxY) - _objectHeight, transform.position.z);
        //game object hide
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0f);
    }

    /// <summary>
    /// Fade in game object in time
    /// </summary>
    private void FadeIn()
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeIn(TimeFadeIn));
    }

    /// <summary>
    /// Fade in game object in a time with coroutine
    /// </summary>
    /// <param name="time">time to object fadeIn</param>
    /// <returns></returns>
    private IEnumerator FadeIn(float time)
    {
        float rate = 1.0f / time;
        float progress = 0.0f;
        while (progress < 1.0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Mathf.Lerp(0, 1, progress));
            progress += rate * Time.deltaTime;
            yield return null;
        }
    }

    private void Update()
    {
        //Gamer click on the screen
        if (Input.GetMouseButtonDown(0))
        {
            eventCheckClick();
        }

    }

    /// <summary>
    /// Summary game core check position of mouse click and position of game object and play sound follow range of ~0 to 1
    /// </summary>
    private void GamePlay()
    {
        //get position of mouse click on screen
        var posion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //get position of game object
        var cowP = transform.position;
        var volumn = DistanceToSoundValue(posion, cowP);
        //get distance between mouse click and game object and play sound follow range of ~0 to 1
        playSoundOnDistance(volumn, TimePlaySound);
    }

    /// <summary>
    /// Math value mapping between distance and sound value
    /// </summary>
    /// <param name="position">position of mouse click on the screen</param>
    /// <param name="cowP">position of game object</param>
    /// <returns>Volume follow distance Range(~0,1)</returns>
    private float DistanceToSoundValue(Vector2 position, Vector2 cowP)
    {
        float volume = 1 + Mathf.Sqrt(Mathf.Pow((position.y - cowP.y), 2) + Mathf.Pow((position.x - cowP.x), 2));
        Debug.Log("volume distance: " + volume);

        return (1 / Mathf.Abs(volume));
    }



    /// <summary>
    /// Play sound with volume follow distance
    /// </summary>
    /// <param name="volume"></param>
    /// <param name="time"></param>
    private void playSoundOnDistance(float volume, float time)
    {
        Debug.Log("volume: " + volume);
        AudioSource.volume = volume;
        AudioSource.clip = Cowsound;
        AudioSource.Play();
        StartCoroutine(StopSound(time));
    }

    /// <summary>
    /// stop sound in a time
    /// </summary>
    /// <param name="time">time set to stop sound</param>
    /// <returns></returns>
    private IEnumerator StopSound(float time)
    {
        while (true)
        {
                Debug.Log($"Audio time {AudioSource.time}");
            if (AudioSource.time >= time)
            {
                Debug.Log("Stop");
                AudioSource.Stop();
                yield break;
            }

            yield return new WaitForSeconds(time);
        }
    }

    private void OnMouseDown()
    {
        //when Gamer found game object
        eventEnd();
    }

}
