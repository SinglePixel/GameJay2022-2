using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerdetect : MonoBehaviour
{
    public Sprite playerIdleRight;

    // public Sprite playerIdleLeft;
    public Sprite playerFallRight;

    // public Sprite playerFallLeft;

    Rigidbody2D rb;
    SpriteRenderer sr;

    private bool fallFlag = false;
    private int moveToward = 0; // 默认朝右

    private bool changeImageFlag = false;

    public Sprite doorClose;
    public Sprite doorOpen;

    private bool doorState = false; // false: 关， true: 开
    private WallSpawner WallSpawner;

    private bool protalFlag = false;
    private float protalTimer = 1f;
    private float protalTime = 0f;

    private bool clearFlag = false;

    public AudioSource audio;
    public AudioSource sounaudio;

    void Start() {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = playerIdleRight;
        //audio = GetComponent<AudioSource>();
        
        WallSpawner = GameObject.Find("WallSpawner").GetComponent<WallSpawner>();
    }

    void Update()
    {
        if (protalFlag)
        {
            protalTime += Time.deltaTime;
            if (protalTime >= protalTimer)
            {
                protalFlag = false;
                protalTime = 0f;
            }
        }

        PlayerSprite();
        PlayerChangeDoor();
    }

    void PlayerSprite()
    {
        if (rb.velocity.magnitude > 1f)
        {
            float angle = Vector2.Angle(rb.velocity, Vector3.down);
            if (angle < 60f)
            {
                //print("玩家下落");
                fallFlag = true;
                changeImageFlag = true;
            }
            if (moveToward == 0 && rb.velocity.x < 0)
            {
                moveToward = 1;
                changeImageFlag = true;
            }
            else if (moveToward == 1 && rb.velocity.x > 0)
            {
                moveToward = 0;
                changeImageFlag = true;
            }
        }
        else if (rb.velocity.magnitude < 1f)
        {
            fallFlag = false;
            changeImageFlag = true;
        }

        if (changeImageFlag)
        {
            if (fallFlag)
            {
                // 下落
                sr.sprite = playerFallRight;
                if (moveToward == 0)
                {
                    // 朝右
                    this.transform.rotation = Quaternion.Euler(0, 0, 0);
                    // sr.sprite = playerFallRight;
                }
                else if (moveToward == 1)
                {
                    // 朝左
                    this.transform.rotation = Quaternion.Euler(0, -180, 0);
                    // sr.sprite = playerFallLeft;
                }
            }
            else
            {
                // 正常
                sr.sprite = playerIdleRight;
                if (moveToward == 0)
                {
                    // 朝右
                    // sr.sprite = playerIdleRight;
                    this.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else if (moveToward == 1)
                {
                    // 朝左
                    this.transform.rotation = Quaternion.Euler(0, -180, 0);
                    // sr.sprite = playerIdleLeft;
                }
            }
            changeImageFlag = false;
        }
    }

    void PlayerChangeDoor()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (doorState)
            {
                doorState = false;
            }
            else
            {
                doorState = true;
            }
            if (WallSpawner.doorList.Count > 0)
            {
                foreach (var x in WallSpawner.doorList)
                {
                    if (doorState)
                    {
                        x.GetComponent<SpriteRenderer>().sprite = doorClose;
                        x.GetComponent<SpriteRenderer>().sortingOrder = 1;
                        x.GetComponent<BoxCollider2D>().isTrigger = false;
                    }
                    else
                    {
                        x.GetComponent<SpriteRenderer>().sprite = doorOpen;
                        x.GetComponent<SpriteRenderer>().sortingOrder = -1;
                        x.GetComponent<BoxCollider2D>().isTrigger = true;
                    }
                }
            }
        }
    }

    //public int group = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (clearFlag) return;

        if (collision.gameObject.GetComponent<Collider2D>().tag == "xji")
        {
            Config.playerDeadCount += 1;
            SceneManager.LoadScene((int)Config.ESceneIndex.StuffScene); // 死亡场景
        }

        if (collision.gameObject.GetComponent<Collider2D>().tag == "gold")
        {
            clearFlag = true;
            if (Config.playProcessIndex == 0)
            {
                Config.playProcessIndex = 1;
            }
            else if (Config.playProcessIndex == 1)
            {
                Config.playProcessIndex = 2;
            }
            else if (Config.playProcessIndex == 2)
            {
                Config.playProcessIndex = 3;
            }
            else if (Config.playProcessIndex == 3)
            {
                Config.playProcessIndex = 4;
                Config.stuffFlag = true;
            }

            // Config.playProcessIndex += 1;
            // audio.Play();
            SceneManager.LoadScene((int)Config.ESceneIndex.PlayScene); // 下一关场景
        }

        if (collision.gameObject.GetComponent<Collider2D>().tag == "protal")
        {
            if (protalFlag)
                return;
            if (WallSpawner.portalList.Count > 0)
            {
                int index = 0;
                int nextIndex = 0;
                for (int i = 0; i < WallSpawner.portalList.Count; i++)
                {
                    if (WallSpawner.portalList[i] == collision.gameObject)
                    {
                        index = i;
                        break;
                    }
                }
                if (index + 1 >= WallSpawner.portalList.Count)
                {
                    nextIndex = 0;
                }
                else
                {
                    nextIndex = index + 1;
                }
                // print(index);
                // print(nextIndex);
                Vector2 targetPosition = WallSpawner.portalList[nextIndex].transform.position;
                this.transform.position = targetPosition;
                protalFlag = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "furniture") {
            //sounaudio.Play();
            if (other.transform.position.y < this.transform.position.y) return;
            if (other.gameObject.name.Contains("Door")) return;
            // print(other.gameObject.tag);
            Vector2 playerSpeedVec = rb.velocity;
            Rigidbody2D otherRb = other.gameObject.GetComponent<Rigidbody2D>();
            Vector2 otherSpeedVec = otherRb.velocity;

            float dis = Mathf.Abs(otherSpeedVec.magnitude);

            float checkPoint = 0f;

            if (Config.playHardIndex == 0)
            {
                checkPoint = 6f;
            }
            if (Config.playHardIndex == 1)
            {
                checkPoint = 4f;
            }
            if (Config.playHardIndex == 2)
            {
                checkPoint = 2f;
            }

            if (dis > checkPoint)
            {
                // 判断玩家死亡
                Config.playerDeadCount += 1;
                SceneManager.LoadScene((int)Config.ESceneIndex.StuffScene); // 死亡场景
            }
        }
    }
}
