﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    // Vi bruger TMPro for at lave en public TextMesh
using TMPro;

public class PointManager : MonoBehaviour
{
    public int Point = 0;
    // Laver en refference til manager text
    public TextMeshProUGUI PointText;

    public int PointToEnableTarget;

    public GameObject TargetToEnable;

    public void AddPoint(int amount)
    {
        // Tilføjer 1 point til det nuværende amount
        Point += amount;
        // Her sørger vi for at Points: ændre sig. Ved at lave en string beholder vi selve ordets points ellers ville det bare være nummeret.
        PointText.text = "Point: " + Point;
        // Her gør vi så hvis point eller flere som man har brug for TargetToEnable så bliver vores goal activ
        if(Point >= PointToEnableTarget)
        {
            TargetToEnable.SetActive(true);
        }
    }

}
