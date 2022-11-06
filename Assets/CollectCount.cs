using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectCount : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI collectText;

    [SerializeField]
    private float CollectedRemaining = 10;

    public bool IsCollect = false;

    private float timerfloat;
    private float timer = 0;
    void Start()
    {
        IsCollect = true;
        collectText = gameObject.GetComponent<TextMeshProUGUI>();
        collectText.text = string.Format("{0:00}", CollectedRemaining);
    }

    private void Update()
    {
        if (Time.timeScale == 0) collectText.SetText("");
    }
    // Update is called once per frame
    public void collect()
    {
        if (CollectedRemaining > 0) CollectedRemaining--;
        collectText.text =  string.Format("{0:00}", CollectedRemaining);
    }

    public bool isCollected()
    {
        return (CollectedRemaining == 0);
    }

    public float getCollectRemain()
    {
        return CollectedRemaining;
    }
}
