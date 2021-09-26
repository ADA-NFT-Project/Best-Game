using System;
using System.Collections;
using System.Collections.Generic;
using Game.Entity;
using UnityEngine;

[RequireComponent(typeof(UnitEntity))]
public class inputtest : MonoBehaviour
{
    private UnitEntity ue;

    private void Awake()
    {
        ue = GetComponent<UnitEntity>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ue.Skills.UseSkill(0);
        }
    }
}
