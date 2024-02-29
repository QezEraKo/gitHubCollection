using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class Scr_Coords_Labeller : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int labelCoordinates = new Vector2Int();

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        DisplayCurrentCoordinates();
    }

    private void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCurrentCoordinates();
            UpdateObjectName();
        }
    }

    private void DisplayCurrentCoordinates()
    {
        labelCoordinates.x = Mathf.RoundToInt(transform.parent.position.x);
        labelCoordinates.y = Mathf.RoundToInt(transform.parent.position.y);

        label.text = $"({labelCoordinates.x}, {labelCoordinates.y})";
    }

    private void UpdateObjectName()
    {
        transform.parent.name = labelCoordinates.ToString();
    }

}
