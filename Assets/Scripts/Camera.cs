using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform sky;
    public float factor0 = 1f;

    public Transform fireflys;
    public float factor1 = 1 / 2f;

    public Transform backtrees;
    public float factor2 = 1 / 4f;

    public Transform graves;
    public float factor3 = 1 / 6f;

    public Transform wall;
    public float factor4 = 1 / 8f;

    private float displacement;
    private float iniCamPosFrame;
    private float nextCamPosFrame;


    // Update is called once per frame
    void Update()
    {
        iniCamPosFrame = transform.position.x;
        transform.position = new Vector3(Player.obj.transform.position.x, transform.position.y, transform.position.z);
    }

    private void LateUpdate()
    {
        nextCamPosFrame = transform.position.x;
        sky.position = new Vector3(sky.position.x + (nextCamPosFrame - iniCamPosFrame) * factor0, sky.position.y, sky.position.z);
        fireflys.position = new Vector3(fireflys.position.x + (nextCamPosFrame - iniCamPosFrame) * factor1, fireflys.position.y, fireflys.position.z);
        backtrees.position = new Vector3(backtrees.position.x + (nextCamPosFrame - iniCamPosFrame) * factor2, backtrees.position.y, backtrees.position.z);
        graves.position = new Vector3(graves.position.x + (nextCamPosFrame - iniCamPosFrame) * factor3, graves.position.y, graves.position.z);
        wall.position = new Vector3(wall.position.x + (nextCamPosFrame - iniCamPosFrame) * factor4, wall.position.y, wall.position.z);
    }
}



