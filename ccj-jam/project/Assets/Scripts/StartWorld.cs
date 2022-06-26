using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartWorld : MonoBehaviour
{
    public Animator transition;
    private int a;//�������
    private float b;
    public float transitionTime = 2f;

    public GameObject startButton1;
    public GameObject startButton2;
    public GameObject startButton3;

    public void StartMenu()
    {

        a += 1;
        if (a >= 5)
        {
            //SceneManager.LoadScene((int)Config.ESceneIndex.PlayScene); 
            LoadNextLevel();
        }
        else if (a == 1)
        {
            transform.position = new Vector2(2, 2);
            transform.localScale = new Vector2(0.1f, 0.1f);
            startButton1.SetActive(true);
            startButton2.SetActive(true);
            startButton3.SetActive(true);
        }
        else if (a == 2)
        {
            transform.position = new Vector2(1, 1);
            transform.localScale = new Vector2(3f, 3f);
        }
        else if (a == 3)
        {
            transform.position = new Vector2(3, 3);
            transform.localScale = new Vector2(2f, 2f);
        }
        else if (a == 4)
        {
            transform.position = new Vector2(0, 0);
            transform.localScale = new Vector2(0.2f, 0.2f);
        }

    }

    public void PlayerQuit()
    {
#if UNITY_EDITOR //������ڱ༭��������
        UnityEditor.EditorApplication.isPlaying = false;
#else//�ڴ�������Ļ�����
      Application.Quit();
#endif
    }
    public void LoadNextLevel()
    {
       StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);

    }

    public void ButtonClear(GameObject obj){
        Destroy(obj);
    }
    public void Kaifaitiaozhuan()
    {
        SceneManager.LoadScene((int)Config.ESceneIndex.PlayScene);
    }

    public void ToStuffScene() {
        Config.playProcessIndex = 4;
        Config.stuffFlag = true;
        SceneManager.LoadScene((int)Config.ESceneIndex.StuffScene); // 死亡场景
    }


}
