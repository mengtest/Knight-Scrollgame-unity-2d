﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    Transform heroTransform;
    Vector3 trans;
    public float xDis;  //镜头偏移
    public float yDis;

    public void FollowHero(GameObject hero)
    {
        heroTransform = hero.transform;
    }

    // Use this for initialization
    void Start()
    {
        //heroTransform = GameObject.FindWithTag("Hero").transform;
        //xDis = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (heroTransform)
        {
            Vector3 vTrans = heroTransform.position;
            if (heroTransform.gameObject.GetComponent<Character>().xDirection)
            {
                if (Math.Abs(transform.position.x - heroTransform.position.x - xDis) > 0.2)
                {
                    vTrans.x += xDis;
                    //if (vTrans.x < 0)
                    //    vTrans.x = 0;
                    if (Math.Abs(transform.position.x - heroTransform.position.x - xDis) > 2)
                        trans = Vector3.Lerp(transform.position, vTrans, 0.015f);
                    else
                        trans = Vector3.Lerp(transform.position, vTrans, 0.025f);
                    trans.y = transform.position.y;
                    trans.z = transform.position.z;
                    transform.position = trans;
                }
            }
            else
            {
                if (Math.Abs(transform.position.x - heroTransform.position.x + xDis) > 0.2)
                {
                    //避免移出边界
                    vTrans.x -= xDis;   //相机目标位置
                    //if (vTrans.x < 0)
                    //    vTrans.x = 0;
                    //大幅移动相机时更平滑
                    if (Math.Abs(transform.position.x - heroTransform.position.x + xDis) > 2)
                        trans = Vector3.Lerp(transform.position, vTrans, 0.015f);
                    else
                        trans = Vector3.Lerp(transform.position, vTrans, 0.025f);

                    trans.y = transform.position.y;
                    trans.z = transform.position.z;
                    transform.position = trans;

                }
            }
        }
    }
}
