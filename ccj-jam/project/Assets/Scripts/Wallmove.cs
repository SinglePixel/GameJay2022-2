using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallmove : MonoBehaviour
{
    public float moveSpeed = 10;

    private Vector3 baseVector;

    bool jumpFlag = false;

    float speed;

    public float zAngle;

    private Transform moveTarget;

    private int targetObjectIndex = 0;

    public GameObject WallSpawner;

    private Transform Wall;
    private Transform Player;

    private float jumpColdTime = 1f;
    private float jumpColdTimer = 0f;
    private bool canJumpFlag = true;
    public AudioSource audio;

    void Start()
    {
        baseVector = this.transform.position;

        Wall = WallSpawner.transform;

        moveTarget = Wall;

        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // if (!Player) {
        //     Player = WallSpawner.GetComponent<WallSpawner>().Player;
        // }

        // if(Input.GetKeyDown(KeyCode.Space)) {
        //     if (targetObjectIndex == 0) {
        //         targetObjectIndex = 1;
        //     } else if (targetObjectIndex == 1) {
        //         targetObjectIndex = 0;
        //     }
        // }

        // if (targetObjectIndex == 0 && moveTarget == Wall) {
        //     moveTarget = Player;
        // }
        // if (targetObjectIndex == 1 && moveTarget == Player) {
        //     moveTarget = Wall;
        // }

        if (!canJumpFlag) {
            jumpColdTimer += Time.deltaTime;
            if (jumpColdTimer >= jumpColdTime) {
                canJumpFlag = true;
                jumpColdTimer = 0f;
            }
        }

        // float x = Input.GetAxis("Horizontal"); //��ȡˮƽ������
        // float y = Input.GetAxis("Vertical"); //��ȡ��ֱ������
        // transform.Translate(Vector3.right * x * moveSpeed * Time.deltaTime, Space.World); //ˮƽ�ƶ���xΪ�����ң�xΪ������
        // moveTarget.Translate(Vector3.right * x * moveSpeed * Time.deltaTime, Space.World); //ˮƽ�ƶ���xΪ�����ң�xΪ������
        // transform.Translate(Vector3.up * y * moveSpeed * Time.deltaTime, Space.World); //��ֱ�ƶ���yΪ�����ϣ�yΪ������
        moverotate();
        Jump();
    }

    void Jump()
    {
        // print(speed);

        if (!jumpFlag && Input.GetKeyDown(KeyCode.Space) && canJumpFlag)
        {
            audio.Play();
            // print("jump");
            jumpFlag = true;
            canJumpFlag = false;
            speed = 0.05f;
        }

        if (jumpFlag)
        {
            moveTarget.position += new Vector3(0, speed, 0);
            speed -= 1f * Time.deltaTime;
        }

        if (moveTarget.position.y < 0)
        {
            // 持续下落
            jumpFlag = false;
            speed = 0;
        }

    }
    void moverotate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            zAngle -= 50f * Time.deltaTime;
            moveTarget.rotation = Quaternion.Euler(0, 0, zAngle);
            // Player.GetComponent<Rigidbody2D>().velocity += -(Vector2)moveTarget.forward;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            zAngle += 50f * Time.deltaTime;
            moveTarget.rotation = Quaternion.Euler(0, 0, zAngle);
            // Player.GetComponent<Rigidbody2D>().velocity += -(Vector2)moveTarget.forward;
        }
    }
}
