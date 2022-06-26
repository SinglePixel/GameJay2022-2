using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    private int moveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal"); //��ȡˮƽ������
        if (x > 0) {
            this.transform.rotation = Quaternion.Euler(0,0,0);
        } else if (x < 0) {
            this.transform.rotation = Quaternion.Euler(0,-180,0);
        }
        transform.Translate(Vector3.right * x * moveSpeed * Time.deltaTime, Space.World); //ˮƽ�ƶ���xΪ�����ң�xΪ������

        if(Input.GetKeyDown(KeyCode.Space)) {
            // 跳跃
            rb.velocity += new Vector2(0,6f);
        }
    }
}
