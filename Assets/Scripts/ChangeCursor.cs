using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    [SerializeField] GameObject aimTarget;
    Camera mainCam;

    private void Awake()
    {
        //Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);
        Cursor.visible = false;
        mainCam = Camera.main;
    }

    private void Update()
    {
        aimTarget.transform.position = mainCam.ScreenToWorldPoint(Input.mousePosition);
        aimTarget.transform.position = new Vector3(aimTarget.transform.position.x, aimTarget.transform.position.y, 0f);
    }
}
