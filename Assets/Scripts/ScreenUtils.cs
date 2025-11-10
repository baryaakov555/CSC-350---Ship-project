using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public static class ScreenUtils
{
    static int screenWidth;
    static int screenHeight;

    static float screenLeft;
    static float screenRight;
    static float screenTop;
    static float screenBottom;

    public static float ScreenLeft { get { return screenLeft; } }
    public static float ScreenRight { get { return screenRight; } }
    public static float ScreenTop { get { return screenTop; } }
    public static float ScreenBottom { get { return screenBottom; } }

    public static void Initialize()
    {
        screenWidth = UnityEngine.Device.Screen.width;
        screenHeight = UnityEngine.Device.Screen.height;

        float screenZ = Camera.main.transform.position.z;

        Vector3 lowerleftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 LowerleftCornerWorld = Camera.main.ScreenToWorldPoint(lowerleftCornerScreen);
        Vector3 toprightCornerScreen = new Vector3(screenWidth, screenHeight, screenZ);
        Vector3 toprightCornerWorld = Camera.main.ScreenToWorldPoint(toprightCornerScreen);
        screenLeft = LowerleftCornerWorld.x;
        screenRight = toprightCornerWorld.x;
        screenTop = toprightCornerWorld.y;
        screenBottom = LowerleftCornerWorld.y;
        Debug.Log("============Init " + screenLeft + " " + screenRight + " " + screenTop + " " + screenBottom);
    }
}
