using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum LoadSceneMode
{

}

public class ScreenOverlayManager : MonoBehaviour
{
    [SerializeField]
    Animator canvasAnimator;


    private ScreenOverlayManager() { }
    private static ScreenOverlayManager instance;

    public static ScreenOverlayManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScreenOverlayManager>();
            }

            return instance;
        }
        private set { }
    }

    // Start is called before the first frame update
    void Start()
    {
        //ScreenOverlayManager[] mgrs = FindObjectOfType<ScreenOverlayManager>();
        //foreach (ScreenOverlayManager mgr in mgrs)
        //{
        //    if (mgr != Instance)
        //    {
        //        Destroy(mgr.gameObject);
        //    }
        //}

        DontDestroyOnLoad(transform.root);

        var encounterMgr = FindObjectOfType<RandomEncounterController>();
        //encounterMgr.onEnterEncounter.AddListener(OnEnterCombat);
        //encounterMgr.onExitEncounter.AddListener(OnExitCombat);

        //SceneManager.sceneLoaded += OnEnterNewScene;
    }

    void OnEnterNewScene(Scene newScene, LoadSceneMode mode)
    {
        canvasAnimator.Play("FadeFromBlack");
    }


    void OnEnterCombat()
    {
        canvasAnimator.Play("FadeToBlack");
    }

    void OnExitCombat()
    {
        canvasAnimator.Play("FadeToBlack");
    }


}
