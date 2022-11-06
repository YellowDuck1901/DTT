using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnerBox : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject box;

    [SerializeField]
    CinemachineVirtualCamera cam;

    [SerializeField]
    Vector3 offsetIntital;

    float heightRow;
    Vector3 SizeBox;

    //[SerializeField]
    //float numberBoxIntital = 6;

    [SerializeField]
    GameObject collecter;

    private CollectCount collecterScript;

    [SerializeField]
    LoadWinLose wl;

    void Start()
    {
        collecterScript = collecter.GetComponent<CollectCount>();
        Manager_SBG.PlaySound(soundsGame.backgroundG3);
        //text.SetText(numberBoxIntital+"");
        SizeBox = box.GetComponent<SpriteRenderer>().bounds.size;
        StartCoroutine(SpawnBox());
    }

    // Update is called once per frame
    IEnumerator SpawnBox()
    {
        for(float i = collecterScript.getCollectRemain(); i > 0; )
        {
            heightRow += SizeBox.y;
            Vector3 positionIntial = new Vector3(offsetIntital.x, offsetIntital.y + heightRow, offsetIntital.z);
            offsetIntital.y += offsetIntital.y;
            GameObject obj = Instantiate(box, positionIntial, Quaternion.identity);
            obj.SetActive(true);
            obj.GetComponent<Box>().TurnOnMove(new Vector3 (Mathf.Abs(offsetIntital.x),obj.transform.position.y,obj.transform.position.z));
            //camera
            //cam.transform.position += new Vector3(cam.transform.position.x, cam.transform.position.y+ heightRow, cam.transform.position.z);
            cam.GetComponent<MoveCamera>().TurnOnMove(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + SizeBox.y, Camera.main.transform.position.z));
            i--;
            collecterScript.collect();
            yield return new WaitForSeconds(3);
        }
        yield return new WaitForSeconds(3);
        Manager_SFX.PlaySound_SFX(soundsGame.winG1);
        LoadWinLose.loadWin(wl);

        //win here
    }

}
