using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLookAtCursor : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 direction;

    [SerializeField]
    private float offSetAngle;
    public Vector3 Direction
    {
        get
        {
            //Some other code
            return direction;
        }
    }

    // Update is called once per frame
    void Update()
    {

        direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        direction.z = 0;  //2d phong ho loi
        direction = direction.normalized; // keep direction and set value of coordinate in range 0-1

        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + offSetAngle, Vector3.forward);

        var z = transform.eulerAngles.z;
        if (z >= 90 && z <= 180 || z >= 180 && z <= 270)
            transform.eulerAngles = new Vector3(-180, 0, -transform.eulerAngles.z);
    }
}
