using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallSpawner : MonoBehaviour
{
    // 地图基础点
    private Vector2 basePosition = Vector2.zero;

    // private const int xCount = 5;
    // private const int yCount = 20;

    private int xCount = 0;
    private int yCount = 0;

    // 墙壁Prefab1 // 1
    public GameObject WallPrefab;

    // 墙壁Prefab2 // 2
    public GameObject WallPrefab2;

    // 陷阱Prefab // 3
    public GameObject TrapPrefab;

    // BedPrefab // 床 (2x1) // 4
    public GameObject BedPrefab;

    // WardrobePrefab // 衣柜 (2x3) // 5
    public GameObject WardrobePrefab;

    // SofaPrefab // 沙发1 (1x1) // 6
    public GameObject SofaPrefab;

    // SofaPrefab // 沙发2 (2x1) // 7
    public GameObject SofaPrefab2;

    // AlbumPrefab // 相框 (1x1) // 8
    public GameObject AlbumPrefab;

    // DoorPrefab // 门 (1x1) // 9
    public GameObject DoorPrefab;

    // TablePrefab // 桌子 (1x1) // 10
    public GameObject TablePrefab;

    // StairPrefab // 楼梯 (1x1) // 11
    public GameObject StairPrefab;

    // ChickenLegPrefab // 鸡腿 (1x1) // 12
    public GameObject ChickenLegPrefab;

    // PortalPrefab // 传送门 (2x2) // 13
    public GameObject PortalPrefab;

    // 出生点Prefab  // 100
    public GameObject StartPrefab;

    // 终点Prefab // 粪池 // 99
    public GameObject EndPrefab;

    // TestPrefab // 玩家
    public GameObject TestPrefab;

    // public GameObject WallPrefab;

    [HideInInspector]
    public Transform Player;

    [HideInInspector]
    public List<GameObject> doorList;

    [HideInInspector]
    public List<GameObject> portalList;

    public List<GameObject> backGroundList;

    public List<GameObject> imageList;

    private int[,] map;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene((int)Config.ESceneIndex.PlayScene);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene((int)Config.ESceneIndex.StartMenu);
        }


        // if (Input.GetKeyDown(KeyCode.U))
        // {
        //     Config.playProcessIndex = 0;
        //     SceneManager.LoadScene((int)Config.ESceneIndex.PlayScene);
        // }
        // if (Input.GetKeyDown(KeyCode.I))
        // {
        //     Config.playProcessIndex = 1;
        //     SceneManager.LoadScene((int)Config.ESceneIndex.PlayScene);
        // }
        // if (Input.GetKeyDown(KeyCode.O))
        // {
        //     Config.playProcessIndex = 2;
        //     SceneManager.LoadScene((int)Config.ESceneIndex.PlayScene);
        // }
        // if (Input.GetKeyDown(KeyCode.P))
        // {
        //     Config.playProcessIndex = 3;
        //     SceneManager.LoadScene((int)Config.ESceneIndex.PlayScene);
        // }
        // if (Input.GetKeyDown(KeyCode.Y))
        // {
        //     Config.playProcessIndex = 99;
        //     SceneManager.LoadScene((int)Config.ESceneIndex.PlayScene);
        // }
    }

    private void Init()
    {
        doorList = new List<GameObject>();

        Vector2 screenOffSet = Vector2.zero;

        if (Config.playProcessIndex == 0)
        {
            xCount = 10;
            yCount = 20;
            map = new int[,]
            {
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,0,0,0,0,0,0,1,1,12,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,1},
                {1,12,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,1},
                {1,1,1,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,8,0,1,1,1,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,1,1,1,1,1,0,0,0,0,1,1,0,0,0,1},
                {1,0,100,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,1},
                {1,0,0,0,0,0,0,0,9,0,0,0,0,0,1,1,99,99,99,1},
                {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
            };

            screenOffSet = new Vector2(- (float)xCount/ 2f * 2.8f - 5.5f + 2.8f, (float)yCount - 15f + 1.8f);
            Camera.main.orthographicSize = 25f;
        }
        else if (Config.playProcessIndex == 1)
        {
            xCount = 10;
            yCount = 20;
            map = new int[,]
            {
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1},
                {1,12,1,0,0,0,0,13,0,1,1,0,13,0,0,0,0,0,0,1},
                {1,2,2,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,8,0,1,1,0,0,0,0,0,0,7,0,1},
                {1,0,0,0,0,0,2,2,2,1,1,2,2,2,2,2,2,0,0,1},
                {1,0,0,0,0,0,0,0,0,1,12,0,0,0,0,0,0,0,0,1},
                {1,0,0,100,0,0,0,0,0,1,1,0,0,0,9,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,1,1,99,99,99,1,0,0,0,0,1},
                {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
            };
            screenOffSet = new Vector2(- (float)xCount/ 2f * 2.8f - 5.5f + 2.8f, (float)yCount - 15f + 1.8f);
            Camera.main.orthographicSize = 20f;
        }
        else if (Config.playProcessIndex == 2)
        {
            xCount = 20;
            yCount = 20;
            map = new int[,]
            {
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
                {1,0,0,0,0,0,8,12,1,8,0,1,1,1,1,1,1,0,12,1,},
                {1,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,12,1,},
                {1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,1,},
                {1,5,0,0,100,0,0,0,0,0,0,0,7,0,0,0,0,0,0,1,},
                {1,0,0,0,0,0,0,0,9,0,0,2,2,2,2,2,0,0,0,1,},
                {1,2,2,2,2,2,2,2,2,2,2,2,0,0,0,2,2,0,0,2,},
                {1,0,0,0,0,0,0,12,1,12,0,0,0,0,0,0,0,0,0,1,},
                {1,0,0,0,0,0,1,1,1,1,0,0,0,8,0,8,9,0,0,1,},
                {1,0,0,0,0,0,0,0,1,0,0,0,2,2,2,2,2,2,2,1,},
                {1,0,0,0,11,0,0,0,0,0,0,2,0,0,0,0,0,0,0,1,},
                {1,0,0,0,0,0,0,0,9,0,2,2,13,0,12,12,12,12,12,1,},
                {1,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,},
                {1,0,0,0,0,1,0,0,0,12,12,0,0,0,0,0,0,0,0,1,},
                {1,6,0,0,0,1,0,0,7,0,0,0,0,12,0,12,0,0,0,1,},
                {1,0,0,0,0,1,0,0,0,1,0,1,0,1,0,1,0,1,1,1,},
                {1,2,2,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
                {1,0,0,0,0,0,0,4,0,0,0,0,0,0,5,0,9,0,0,1,},
                {1,13,0,0,0,9,0,0,0,0,0,0,0,0,0,0,1,99,99,1,},
                {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
            };

            screenOffSet = new Vector2(- (float)xCount/ 2f * 2.8f - 5.5f + 2.8f + 14.25f, (float)yCount - 15f + 1.8f + 7.5f);
            Camera.main.orthographicSize = 35f;
        }
        else if (Config.playProcessIndex == 3)
        {
            xCount = 20;
            yCount = 20;
            map = new int[,]
            {
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,8,0,0,100,0,1,1,0,0,0,0,8,0,0,0,1},
                {1,0,0,1,1,1,0,0,6,1,1,99,99,99,1,1,1,0,0,1},
                {1,0,0,2,2,2,2,2,2,1,1,2,2,2,2,2,2,0,0,1},
                {1,6,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,6,1},
                {1,0,0,8,0,0,0,0,0,1,1,0,0,0,0,8,0,0,0,1},
                {1,2,2,2,2,2,2,0,0,1,1,0,0,2,2,2,2,2,2,1},
                {1,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1},
                {1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1},
                {1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1},
                {1,0,6,0,0,0,0,0,0,1,1,0,0,0,0,0,0,6,0,1},
                {1,2,2,2,2,2,2,0,0,1,1,0,0,2,2,2,2,2,2,1},
                {1,0,0,0,0,0,1,0,0,1,1,0,0,1,0,0,0,0,0,1},
                {1,0,0,0,0,0,1,0,0,1,1,0,0,1,0,0,0,0,0,1},
                {1,0,0,1,0,0,0,0,0,1,1,0,0,0,0,0,1,0,0,1},
                {1,0,0,1,0,8,9,0,0,1,1,0,0,9,8,0,1,0,0,1},
                {1,0,0,2,2,2,2,2,2,1,1,2,2,2,2,2,2,0,0,1},
                {1,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,1},
                {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
            };

            screenOffSet = new Vector2(- (float)xCount/ 2f * 2.8f - 5.5f + 2.8f + 14.25f, (float)yCount - 15f + 1.8f + 7.5f);
            Camera.main.orthographicSize = 40f;
        }
        // else if (Config.playProcessIndex == 99)
        // {
        //     xCount = 40;
        //     yCount = 40;
        //     map = new int[,]
        //     {
        //         {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        //         {1,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1},
        //         {1,12,0,0,0,0,0,13,0,1,1,0,13,0,0,0,0,0,0,1,1,12,0,0,0,0,0,13,0,1,1,0,13,0,0,0,0,0,0,1},
        //         {1,2,2,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,2,2,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1},
        //         {1,0,0,0,0,0,0,8,0,1,1,0,0,0,0,0,0,7,0,1,1,0,0,0,0,0,0,8,0,1,1,0,0,0,0,0,0,7,0,1},
        //         {1,0,0,0,0,0,2,2,2,1,1,2,2,2,2,2,2,0,0,1,1,0,0,0,0,0,2,2,2,1,1,2,2,2,2,2,2,0,0,1},
        //         {1,0,0,0,0,0,0,0,0,1,12,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,12,0,0,0,0,0,0,0,0,1},
        //         {1,0,0,100,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,0,0,100,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1},
        //         {1,0,0,0,0,0,0,0,0,1,1,99,99,99,1,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,99,99,99,1,0,0,0,0,1},
        //         {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
        //         {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        //         {1,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1},
        //         {1,12,0,0,0,0,0,13,0,1,1,0,13,0,0,0,0,0,0,1,1,12,0,0,0,0,0,13,0,1,1,0,13,0,0,0,0,0,0,1},
        //         {1,2,2,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,2,2,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1},
        //         {1,0,0,0,0,0,0,8,0,1,1,0,0,0,0,0,0,7,0,1,1,0,0,0,0,0,0,8,0,1,1,0,0,0,0,0,0,7,0,1},
        //         {1,0,0,0,0,0,2,2,2,1,1,2,2,2,2,2,2,0,0,1,1,0,0,0,0,0,2,2,2,1,1,2,2,2,2,2,2,0,0,1},
        //         {1,0,0,0,0,0,0,0,0,1,12,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,12,0,0,0,0,0,0,0,0,1},
        //         {1,0,0,100,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,0,0,100,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1},
        //         {1,0,0,0,0,0,0,0,0,1,1,99,99,99,1,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,99,99,99,1,0,0,0,0,1},
        //         {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
        //         {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        //         {1,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1},
        //         {1,12,0,0,0,0,0,13,0,1,1,0,13,0,0,0,0,0,0,1,1,12,0,0,0,0,0,13,0,1,1,0,13,0,0,0,0,0,0,1},
        //         {1,2,2,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,2,2,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1},
        //         {1,0,0,0,0,0,0,8,0,1,1,0,0,0,0,0,0,7,0,1,1,0,0,0,0,0,0,8,0,1,1,0,0,0,0,0,0,7,0,1},
        //         {1,0,0,0,0,0,2,2,2,1,1,2,2,2,2,2,2,0,0,1,1,0,0,0,0,0,2,2,2,1,1,2,2,2,2,2,2,0,0,1},
        //         {1,0,0,0,0,0,0,0,0,1,12,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,12,0,0,0,0,0,0,0,0,1},
        //         {1,0,0,100,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,0,0,100,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1},
        //         {1,0,0,0,0,0,0,0,0,1,1,99,99,99,1,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,99,99,99,1,0,0,0,0,1},
        //         {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
        //         {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        //         {1,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1},
        //         {1,12,0,0,0,0,0,13,0,1,1,0,13,0,0,0,0,0,0,1,1,12,0,0,0,0,0,13,0,1,1,0,13,0,0,0,0,0,0,1},
        //         {1,2,2,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,2,2,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1},
        //         {1,0,0,0,0,0,0,8,0,1,1,0,0,0,0,0,0,7,0,1,1,0,0,0,0,0,0,8,0,1,1,0,0,0,0,0,0,7,0,1},
        //         {1,0,0,0,0,0,2,2,2,1,1,2,2,2,2,2,2,0,0,1,1,0,0,0,0,0,2,2,2,1,1,2,2,2,2,2,2,0,0,1},
        //         {1,0,0,0,0,0,0,0,0,1,12,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,12,0,0,0,0,0,0,0,0,1},
        //         {1,0,0,100,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,0,0,100,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1},
        //         {1,0,0,0,0,0,0,0,0,1,1,99,99,99,1,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,99,99,99,1,0,0,0,0,1},
        //         {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
        //     };

        //     screenOffSet = new Vector2(- (float)xCount/ 2f * 2.8f - 5.5f + 2.8f + 14.25f + 10f, (float)yCount - 15f + 1.8f + 7.5f - 4f);
        // }

        if (Config.playProcessIndex != 99) {
            GameObject backgroundObj = Instantiate(backGroundList[Config.playProcessIndex], backGroundList[Config.playProcessIndex].transform.position, Quaternion.identity);
            backgroundObj.transform.SetParent(this.transform);
            Instantiate(imageList[Config.playProcessIndex], Vector2.zero, Quaternion.identity);
        }

        int xStartCount = yCount;
        if ((xStartCount) % 2 != 0)
        {
            xStartCount -= 1;
        }
        xStartCount /= 2;
        xStartCount = -xStartCount;

        int yStartCount = xCount;
        if ((yStartCount) % 2 != 0)
        {
            yStartCount -= 1;
        }
        yStartCount /= 2;
        yStartCount = -yStartCount;

        Vector2 spawnPosition = new Vector2();

        Vector2 offset = new Vector2(0.5f, 0f);

        for (int i = 0; i < yCount; i++)
        {
            for (int j = 0; j < xCount; j++)
            {
                if (map[j, i] == 0)
                    continue;
                if (map[j, i] == 1)
                { // 1 墙壁1
                    spawnPosition = new Vector2(xStartCount + i * 2.8f, -(yStartCount + j * 2.6f));
                    // spawnPosition += offset;
                    spawnPosition += screenOffSet;
                    GameObject obj = Instantiate(WallPrefab, Vector2.zero, Quaternion.identity);
                    obj.transform.SetParent(this.transform);
                    obj.transform.position = spawnPosition;
                }
                if (map[j, i] == 2)
                { // 2 墙壁2
                    spawnPosition = new Vector2(xStartCount + i * 2.8f, -(yStartCount + j * 2.6f));
                    // spawnPosition += offset;
                    spawnPosition += screenOffSet;
                    GameObject obj = Instantiate(WallPrefab2, Vector2.zero, Quaternion.identity);
                    obj.transform.SetParent(this.transform);
                    obj.transform.position = spawnPosition;
                }
                if (map[j, i] == 3)
                { // 3 陷阱
                    spawnPosition = new Vector2(xStartCount + i * 2.8f, -(yStartCount + j * 2.6f));
                    // spawnPosition += offset;
                    spawnPosition += screenOffSet;
                    GameObject obj = Instantiate(TrapPrefab, Vector2.zero, Quaternion.identity);
                    obj.transform.SetParent(this.transform);
                    obj.transform.position = spawnPosition;
                }
                if (map[j, i] == 4)
                { // 4 床
                    spawnPosition = new Vector2(xStartCount + i * 2.8f, -(yStartCount + j * 2.6f));
                    // spawnPosition += offset;
                    spawnPosition += screenOffSet;
                    GameObject obj = Instantiate(BedPrefab, Vector2.zero, Quaternion.identity);
                    obj.transform.SetParent(this.transform);
                    obj.transform.position = spawnPosition;
                }
                if (map[j, i] == 5)
                { // 5 衣柜
                    spawnPosition = new Vector2(xStartCount + i * 2.8f, -(yStartCount + j * 2.6f));
                    // spawnPosition += offset;
                    spawnPosition += screenOffSet;
                    GameObject obj = Instantiate(WardrobePrefab, Vector2.zero, Quaternion.identity);
                    obj.transform.SetParent(this.transform);
                    obj.transform.position = spawnPosition;
                }
                if (map[j, i] == 6)
                { // 6 沙发1
                    spawnPosition = new Vector2(xStartCount + i * 2.8f, -(yStartCount + j * 2.6f));
                    // spawnPosition += offset;
                    spawnPosition += screenOffSet;
                    GameObject obj = Instantiate(SofaPrefab, Vector2.zero, Quaternion.identity);
                    obj.transform.SetParent(this.transform);
                    obj.transform.position = spawnPosition;
                }
                if (map[j, i] == 7)
                { // 7 沙发2
                    spawnPosition = new Vector2(xStartCount + i * 2.8f, -(yStartCount + j * 2.6f));
                    // spawnPosition += offset;
                    spawnPosition += screenOffSet;
                    GameObject obj = Instantiate(SofaPrefab2, Vector2.zero, Quaternion.identity);
                    obj.transform.SetParent(this.transform);
                    obj.transform.position = spawnPosition;
                }
                if (map[j, i] == 8)
                { // 8 相框
                    spawnPosition = new Vector2(xStartCount + i * 2.8f, -(yStartCount + j * 2.6f));
                    // spawnPosition += offset;
                    spawnPosition += screenOffSet;
                    GameObject obj = Instantiate(AlbumPrefab, Vector2.zero, Quaternion.identity);
                    obj.transform.SetParent(this.transform);
                    obj.transform.position = spawnPosition;
                }
                if (map[j, i] == 9)
                { // 9 门
                    spawnPosition = new Vector2(xStartCount + i * 2.8f, -(yStartCount + j * 2.6f));
                    // spawnPosition += offset;
                    spawnPosition += screenOffSet;
                    spawnPosition += new Vector2(0, 1.5f);
                    GameObject obj = Instantiate(DoorPrefab, Vector2.zero, Quaternion.identity);
                    obj.transform.SetParent(this.transform);
                    obj.transform.position = spawnPosition;
                    doorList.Add(obj);
                }
                if (map[j, i] == 10)
                { // 10 桌子
                    spawnPosition = new Vector2(xStartCount + i * 2.8f, -(yStartCount + j * 2.6f));
                    // spawnPosition += offset;
                    spawnPosition += screenOffSet;
                    GameObject obj = Instantiate(TablePrefab, Vector2.zero, Quaternion.identity);
                    obj.transform.SetParent(this.transform);
                    obj.transform.position = spawnPosition;
                }
                if (map[j, i] == 11)
                { // 11 楼梯
                    spawnPosition = new Vector2(xStartCount + i * 2.8f, -(yStartCount + j * 2.6f));
                    // spawnPosition += offset;
                    spawnPosition += screenOffSet;
                    GameObject obj = Instantiate(StairPrefab, Vector2.zero, Quaternion.identity);
                    obj.transform.SetParent(this.transform);
                    obj.transform.position = spawnPosition;
                }
                if (map[j, i] == 12)
                { // 12 鸡腿
                    spawnPosition = new Vector2(xStartCount + i * 2.8f, -(yStartCount + j * 2.6f));
                    // spawnPosition += offset;
                    spawnPosition += screenOffSet;
                    GameObject obj = Instantiate(
                        ChickenLegPrefab,
                        Vector2.zero,
                        Quaternion.identity
                    );
                    obj.transform.SetParent(this.transform);
                    obj.transform.position = spawnPosition;
                }
                if (map[j, i] == 13)
                { // 13 传送门
                    spawnPosition = new Vector2(xStartCount + i * 2.8f, -(yStartCount + j * 2.6f));
                    // spawnPosition += offset;
                    spawnPosition += screenOffSet;
                    GameObject obj = Instantiate(PortalPrefab, Vector2.zero, Quaternion.identity);
                    obj.transform.SetParent(this.transform);
                    obj.transform.position = spawnPosition;
                    portalList.Add(obj);
                }
                if (map[j, i] == 99)
                { // 99 终点
                    spawnPosition = new Vector2(xStartCount + i * 2.8f, -(yStartCount + j * 2.6f));
                    // spawnPosition += offset;
                    spawnPosition += screenOffSet;
                    GameObject obj = Instantiate(EndPrefab, Vector2.zero, Quaternion.identity);
                    obj.transform.SetParent(this.transform);
                    obj.transform.position = spawnPosition;
                }
                if (map[j, i] == 100)
                { // 100 出生点
                    spawnPosition = new Vector2(xStartCount + i * 2.8f, -(yStartCount + j * 2.6f));
                    // spawnPosition += offset;
                    spawnPosition += screenOffSet;
                    GameObject obj = Instantiate(StartPrefab, Vector2.zero, Quaternion.identity);
                    obj.transform.SetParent(this.transform);
                    obj.transform.position = spawnPosition;
                    GameObject player = Instantiate(TestPrefab, spawnPosition, Quaternion.identity);
                    Player = player.transform;
                }
            }
        }
    }
}
