using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSelect : MonoBehaviour
{
    public GameObject stageNameGameObject;
    public GameObject stageHardGameObject;

    public GameObject unitUI;

    private GameObject spawnGameObject;

    // Start is called before the first frame update
    void Start()
    {
        spawnGameObject = stageHardGameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeStageName(int num) {
        for (int i = 0 ; i < stageNameGameObject.transform.childCount; i ++) {
            stageNameGameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        if (num > 0) {
            if (Config.playProcessIndex + 1 > 3) {
                Config.playProcessIndex = 0;
            } else {
                Config.playProcessIndex += 1;
            }
        } else if (num < 0) {
            if (Config.playProcessIndex - 1 < 0) {
                Config.playProcessIndex = 3;
            } else {
                Config.playProcessIndex -= 1;
            }
        }
        stageNameGameObject.transform.GetChild(Config.playProcessIndex).gameObject.SetActive(true);
    }

    public void changeStageHard(int num) {
        for (int i = 0 ; i < spawnGameObject.transform.childCount; i ++) {
            spawnGameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        if (num > 0) {
            if (Config.playHardIndex + 1 > 2) {
                Config.playHardIndex = 0;
            } else {
                Config.playHardIndex += 1;
            }
        } else if (num < 0) {
            if (Config.playHardIndex - 1 < 0) {
                Config.playHardIndex = 2;
            } else {
                Config.playHardIndex -= 1;
            }
        }
        spawnGameObject.transform.GetChild(Config.playHardIndex).gameObject.SetActive(true);
    }
}
