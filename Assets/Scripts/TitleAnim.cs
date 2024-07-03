using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnim : MonoBehaviour
{
    public Transform[] panels;
    public float jumpPos;
    public float targetPos;

    public float moveSpeed;

    private void FixedUpdate()
    {
        foreach(Transform t in panels)
        {
            t.position += Vector3.left * (moveSpeed * Time.deltaTime);

            if(t.position.x <= jumpPos)
            {
                t.position = new Vector2(targetPos, t.position.y);
            }
        }
    }

}
