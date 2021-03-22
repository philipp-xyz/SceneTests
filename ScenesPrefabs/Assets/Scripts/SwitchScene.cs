using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchScene : MonoBehaviour {

    public int buildIndexNext;
    
    public GameObject loadingScreen;
    public Slider slider;
    public TextMeshProUGUI progressText;

    private GameObject[] sceneManagers;
    void Start() {
        DontDestroyOnLoad(this); //Zerstört das Objekt nicht beim Szenenwechsel
        sceneManagers = GameObject.FindGameObjectsWithTag("SceneManager");
    }
    
    void Update() {
        //Startet Coroutine zum Scenenwechseln per Tastendruck
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            StartCoroutine(LoadAsync(buildIndexNext));
        }
        
        if (sceneManagers.Length > 1) {
            Destroy(sceneManagers[1]);
        }
    }

    IEnumerator LoadAsync(int buildIndexNext) {
        
        //lädt szene asynchron mit build index
        AsyncOperation operation = SceneManager.LoadSceneAsync(buildIndexNext);
        
        loadingScreen.SetActive(true); //Setzt Ladebildschirm aktive

        //Progressbar Ladebildschirm
        while (!operation.isDone) {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;
            progressText.text = progress * 100f + "%";
            
            yield return null;
        }
        
        //wenn laden fertig ist setzt ladebidlschirm inaktiv
        if (operation.isDone) {
            loadingScreen.SetActive(false);
        }
    }

}
