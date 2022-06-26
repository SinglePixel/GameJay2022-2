using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndProtalController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag=="Player")
        {
            SceneManager.LoadScene((int)Config.ESceneIndex.PlayScene); // 游戏场景
        }
    }
}
