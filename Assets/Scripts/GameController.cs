using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject link;
    [SerializeField] private GameObject panel;
    private CanvasGroup canvasGroup;
    private Image blackPanel;
    
    private bool playerDead = false;
    bool startFade = false;

    // Start is called before the first frame update
    void Start()
    {
        blackPanel = panel.GetComponent<Image>();
        
        canvasGroup = panel.GetComponent<CanvasGroup>();
        
        Debug.Log("Panel: " + canvasGroup);
        //StartCoroutine(DoFade());
    }

    // Update is called once per frame
    void Update()
    {
        if (link == null && !startFade)
        {
            startFade = true;
            FadeScreen();
        }
    }
    public void FadeScreen() {
        StartCoroutine(DoFade());
    }

    
    IEnumerator DoFade() {
        var currentColor = blackPanel.color;
        
        while(canvasGroup.alpha < 1) {
           canvasGroup.alpha += Time.deltaTime / 2;
           //blackPanel.color = currentColor;
           yield return null;
        }

        StartCoroutine(SceneReload());
        yield return null;
    }

    IEnumerator SceneReload() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        yield return null;
    }
}
