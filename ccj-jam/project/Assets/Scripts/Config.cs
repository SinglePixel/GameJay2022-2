using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config
{
    public static int playProcessIndex = 0; // 0 第一关，1 第二关，2 第三关，3 第四关

    public static bool stuffFlag = false;

    public static int playHardIndex = 1; // 0 简单, 1 普通, 2 困难

    public static int playerDeadCount = 0;

    public enum ESceneIndex {
        StartMenu = 0,
        PlayScene = 1,
        StuffScene = 2,
    }
}
