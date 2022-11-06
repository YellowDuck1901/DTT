using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class Spawner : MonoBehaviour
{

    // Start is called before the first frame update
    public enum TypeOfSpawner { Circle, EdgeOfCamera }

    public TypeOfSpawner typeSpawner;

    [SerializeField]
    GameObject[] listMonter;

    [SerializeField]
    Transform centerPoint;

    [Range(0.1f,10f), SerializeField]
    float minSecondSpawn;

    [Range(0.1f, 10f), SerializeField]
    float MaxSecondSpawn;

    [SerializeField]
    float timeDestroyMoneter;

    [SerializeField]
    int offsetWidth;
   

    float radius;
    float area;
    float anglePoint;
    Vector3 positionPointInCircle;
    Vector3 positionPointInCamera;

    

    void Start()
    {
        Manager_SFX.PlaySound_SFX(soundsGame.backgroundG2);
        radius = getWidthCamera() / 2 + offsetWidth;
        area = Mathf.PI * radius * radius;

        //select spawner type
        if (typeSpawner.Equals(TypeOfSpawner.Circle))
        {
            StartCoroutine(SpawnerMonterIncircle());
        }
        else
        {
            StartCoroutine(SpawnerMonterInEdgeCamera());
        }
    }



    // Update is called once per frame
    void Update()
    {

        anglePoint = Random.Range(0, 360);


        if (typeSpawner.Equals(TypeOfSpawner.Circle))
        {
            positionPointInCircle = CoordinatePointInCircle2D(anglePoint, radius, centerPoint);
            positionPointInCircle.z = 0;
        }
        else
        {
            positionPointInCamera = RandomCoordinatePointInCamera(offsetWidth);
            positionPointInCamera.z = 0;
        }
    }

    static public float getWidthCamera()
    {
        
        float height = 2f * Camera.main.orthographicSize;
        return height * Camera.main.aspect;
    }

    static public float getHeightCamera()
    {
        return  2f * Camera.main.orthographicSize;
    }

    static public Vector3 CoordinatePointInCircle3D(float angle,float radius, Transform centerPoint)
    {
        float x, y, z;
        x = Mathf.Cos(angle) * radius + centerPoint.position.x;
        y = centerPoint.position.y;
        z = Mathf.Sin(angle) * radius + centerPoint.position.z;
        return new Vector3(x, y, z);
    }

    static public Vector3 CoordinatePointInCircle2D(float angle, float radius, Transform centerPoint)
    {
        float x, y, z;
        x = Mathf.Cos(angle) * radius + centerPoint.position.x;
        y = Mathf.Sin(angle) * radius + centerPoint.position.z;
        z = 0f;
        return new Vector3(x, y, z);
    }

    static public Vector3 CoordinateBottomRightCamera2D(int offset)
    {
        Vector3 bottomY = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + offset, 0 - offset, 0));
        //Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));

        return bottomY;
    }

    static public Vector3 CoordinateBottomLeftCamera2D(int offset)
    {
        Vector3 bottomY = Camera.main.ScreenToWorldPoint(new Vector3(0 - offset, 0 - offset, 0));
        //Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        return bottomY;
    }

    static public Vector3 CoordinateTopLeftCamera2D(int offset)
    {
        Vector3 bottomY = Camera.main.ScreenToWorldPoint(new Vector3(0 - offset, Screen.height + offset, 0));
        //Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        return bottomY;
    }

    static public Vector3 CoordinateTopRightCamera2D(int offset)
    {
        Vector3 a = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + offset, Screen.height + offset , 0));
        return a;
    }

    static public Vector3 RandomCoordinatePointInCamera(int offset)
    {

        var bLeft = CoordinateBottomLeftCamera2D(offset) ;
        var bRight = CoordinateBottomRightCamera2D(offset);
        var tLeft = CoordinateTopLeftCamera2D(offset);
        var tRight = CoordinateTopRightCamera2D(offset);
        var randomNumber = Random.Range(0f, 1f);

        switch (Random.Range(1, 5))
        {
            case 1: //bottom edge
                return Vector3.Lerp(bLeft, bRight, randomNumber);
            case 2: //top edge
                return Vector3.Lerp(tLeft, tRight, randomNumber);
            case 3: //right edge
                return Vector3.Lerp(bRight, tRight, randomNumber);
            case 4: //left edge
                return Vector3.Lerp(bLeft, tLeft, randomNumber);
        }

        return new Vector3(0, 0, 0);
    }

    IEnumerator SpawnerMonterIncircle()
    {
        while (true)
        {
            var secondSpawn = Random.Range(minSecondSpawn, MaxSecondSpawn);
            yield return new WaitForSeconds(secondSpawn);

            GameObject gameObject = (GameObject)Instantiate(listMonter[Random.Range(0, listMonter.Length)], positionPointInCircle, Quaternion.identity);
            Destroy(gameObject, timeDestroyMoneter);
        }
    }

    IEnumerator SpawnerMonterInEdgeCamera()
    {
        while (true)
        {
            var secondSpawn = Random.Range(minSecondSpawn, MaxSecondSpawn);
            yield return new WaitForSeconds(secondSpawn);

            GameObject gameObject = (GameObject)Instantiate(listMonter[Random.Range(0, listMonter.Length)], positionPointInCamera, Quaternion.identity);
        }
    }
}
