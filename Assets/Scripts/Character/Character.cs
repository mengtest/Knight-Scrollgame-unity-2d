﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//角色属性基类
public class Character : MonoBehaviour {

    public UnityEvent die;

    public string CharacterName;
    public bool alive;
    public float health;
    public float defaultHealth;
    public bool immune; //免疫伤害
    public float phyAtk;    //物理攻击力
    public float magAtk;    //魔法攻击力
    public float speedX;
    public float speedY;
    public int kind;   //0:hero    101-199:enemy    201-299:weapon
    //public string charactorName;

    public bool xDirection; //角色x轴朝向  true：右
    public bool yDirection; //true:上

    public int state;   //异常状态
    public bool action;  //可行动

    virtual public void BeHit(BulletBase bulletBase) { }   //被击中

    public float halfy =0;


    virtual protected void Awake()
    {
        
    }
    virtual protected void Start () {
        //alive = 1;

        //设置底部偏移位置,由于旋转45度导致角色底部与路面z值不同，通过数学计算调整，0.707 = 1/根2
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer)
        {
            halfy = spriteRenderer.bounds.size.y * 0.5f;
        }
        GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x,
            GetComponent<Transform>().position.y, GetComponent<Transform>().position.z - halfy * 0.707f);

        health = defaultHealth;



    }
    virtual protected void OnEnable()
    {
        //health = defaultHealth;
    }

    virtual protected void Update () {

	}
    virtual protected void FixedUpdate()
    {
        //根据sprite底部y轴位置设定z轴位置，实现遮挡效果

        //gameObject.transform.position = 
        //    new Vector3(transform.position.x, transform.position.y, (transform.position.y-halfy) / 3.0f);
        if (alive && health <= 0)
        {
            alive = false;
            die.Invoke();
        }
        
    }
}