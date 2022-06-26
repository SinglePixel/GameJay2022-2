using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FloorSpawner : MonoBehaviour
{
    private List<string> textList = new List<string>();

    private int spawnCount = 22;

    public GameObject textFloorObject;
    public GameObject endProtalObject;

    public GameObject endPlayerGameObject;

    private float movePositionY;

    // Start is called before the first frame update
    void Start()
    {
        if (Config.playProcessIndex == 4)
        {
            EndInit();
        }
        else if (
            Config.playProcessIndex == 0
            || Config.playProcessIndex == 1
            || Config.playProcessIndex == 2
            || Config.playProcessIndex == 3
        )
        {
            Init();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if (Config.playProcessIndex == 4)
        // {
        //     movePositionY += Time.deltaTime;
        //     this.transform.position = new Vector2(0, movePositionY);
        // }
        // else if (
        //     Config.playProcessIndex == 0
        //     || Config.playProcessIndex == 1
        //     || Config.playProcessIndex == 2
        //     || Config.playProcessIndex == 3
        // ) {
        //     if (endPlayerGameObject.transform.position.y < -4f) {
        //         SceneManager.LoadScene((int)Config.ESceneIndex.StuffScene); // 死亡场景
        //     }
        // }

        if (Config.stuffFlag) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                Config.stuffFlag = false;
                Config.playProcessIndex = 0;
                SceneManager.LoadScene((int)Config.ESceneIndex.StartMenu); // 开始场景
            }
        }

        movePositionY += Time.deltaTime;
        this.transform.position = new Vector2(0, movePositionY);

        if (endPlayerGameObject.transform.position.y < -4f) {
            SceneManager.LoadScene((int)Config.ESceneIndex.StuffScene); // 死亡场景
        }

        // if (Input.GetKeyDown(KeyCode.R))
        // {   
        //     Config.playerDeadCount += 1;
        //     SceneManager.LoadScene((int)Config.ESceneIndex.StuffScene);
        // }
    }

    void Init()
    {
        textList.Add("鼠标滚轮可以缩放游戏视角");
        textList.Add("躺了是吧");
        textList.Add("没用的废物！");
        textList.Add("除了泡进大粪，你还有什么追求？");
        textList.Add("你的家具一巴掌把你乎墙上扣都扣不下来。");
        textList.Add("这世界上最遥远的距离，不是天涯海角，而是你与粪坑。");
        textList.Add("一分钟有多长？这要看你是不小心被压扁，还是努力让自己掉进粪坑");

        int index = 0;
        if (Config.playerDeadCount > textList.Count) {
            index = UnityEngine.Random.Range(0,textList.Count);
        } else {
            index = Config.playerDeadCount - 1;
            if (index < 0) index = 0;
        }
       
        Vector2 spawnPosition = new Vector2(
            this.transform.position.x,
            this.transform.position.y - 1
        );
        GameObject obj = Instantiate(textFloorObject, Vector2.zero, Quaternion.identity);
        obj.transform.position = spawnPosition;
        obj.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = textList[index];
        obj.transform.SetParent(this.transform);

        // Vector2 textSpawnPosition = new Vector2(
        //     this.transform.position.x,
        //     this.transform.position.y + 3
        // );
        // GameObject textObj = Instantiate(textFloorObject, Vector2.zero, Quaternion.identity);
        // textObj.transform.position = textSpawnPosition;
        // textObj.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "鼠标滚轮可以缩放游戏视角";
        // textObj.transform.GetComponent<BoxCollider2D>().isTrigger = true;

        int randomXLeft = UnityEngine.Random.Range(-8,-5);
        int randomXRight = UnityEngine.Random.Range(5,8);

        int randomX = 0;

        int random = UnityEngine.Random.Range(1,10);
        if (random > 5) {
            randomX = randomXLeft;
        } else {
            randomX = randomXRight;
        }

        float randomY = UnityEngine.Random.Range(3,6);

        Vector2 spawnProtalPosition = new Vector2(randomX, randomY);

        Instantiate(endProtalObject, spawnProtalPosition, Quaternion.identity);

    }

    void EndInit()
    {

        // 不愿意透露姓名的打工人K
        // 从外星赶来协助人类的某羊
        // 全能监工精神资本家策美罗比
        // 狗策划
        // 被打工人唾弃的狗策划
        // 被精神资本家在梦里暴揍一顿的狗策划

        // 感谢：
        // 奋力抵达粪坑的比尔
        // AND YOU

        // textList.Add("策划: 角色A");
        // textList.Add("美术: 角色B");
        // textList.Add("程序: 角色C");
        // textList.Add("程序: 角色D");
        // textList.Add("测试对话长度测试对话长度测试对话长度");

        textList.Add("STUFF LIST");
        textList.Add("");
        textList.Add("策划");
        textList.Add("被精神资本家在梦里暴揍一顿的狗策划Echo");
        textList.Add("");
        textList.Add("美术");
        textList.Add("全能监工精神资本家策美罗比");
        textList.Add("");
        textList.Add("程序A");
        textList.Add("从外星赶来协助人类的某羊");
        textList.Add("");
        textList.Add("程序B");
        textList.Add("不愿意透露姓名的打工人K");
        textList.Add("");
        textList.Add("PS:");
        textList.Add("狗策划");
        textList.Add("被打工人唾弃的狗策划");
        textList.Add("被精神资本家在梦里暴揍一顿的狗策划");
        textList.Add("");
        textList.Add("感谢：");
        textList.Add("奋力抵达粪坑的比尔");
        textList.Add("AND YOU");

        for (int i = 0; i < spawnCount; i++)
        {
            Vector2 spawnPosition = new Vector2(
                this.transform.position.x,
                this.transform.position.y - 2 * i
            );
            GameObject obj = Instantiate(textFloorObject, Vector2.zero, Quaternion.identity);
            obj.transform.position = spawnPosition;
            obj.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = textList[i];
            obj.transform.SetParent(this.transform);
        }
    }
}
