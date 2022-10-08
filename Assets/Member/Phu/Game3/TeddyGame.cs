using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject honney;
    GameObject target = null;
    List<GameObject> l = new List<GameObject>();
    float v;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            var p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var g = GameObject.Instantiate(honney, p, Quaternion.identity);
            l.Add(g);
            print("right click");
        }

        if (target) move();
    }

    Vector2 getPos(GameObject g) { return new Vector2(g.transform.position.x, g.transform.position.y); }

    void updateTarget()
    {
        target = null;
        foreach(var h in l)
        {
          if(target == null)
            {
                target = h;
                continue;
            }

        if(Vector2.Distance(getPos(target),getPos(gameObject))
            > Vector2.Distance(getPos(h), getPos(gameObject))) { target = h; }
        }
    }

    void move()
    {
        var dir = (getPos(target) - getPos(gameObject)).normalized;
        dir = dir * v * Time.deltaTime;
        gameObject.transform.position = new Vector3(dir.x, dir.y, 0);

    }


}
