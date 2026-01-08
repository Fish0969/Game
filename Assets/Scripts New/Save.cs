using TMPro;
using UnityEngine;

public class Save : MonoBehaviour
{
    public int KilledenemiesforChallenge;
    public GameObject spawner;
    public TextMeshProUGUI challenge;
    private GeneratingEnemies genEnemies;
    private const string SAVE_KEY = "KilledEnemiesChallenge";
    private static Save instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadProgress();
    }

    void OnEnable()
    {
        // Re-find references when scene loads (they're recreated each scene)
        if (spawner == null) spawner = FindObjectOfType<ParentCounter>()?.gameObject;
        if (spawner) genEnemies = spawner.GetComponent<GeneratingEnemies>();
        
        // Find challenge UI in new scene
        challenge = FindObjectOfType<TextMeshProUGUI>();
    }

    void Update()
    {
        // Only update UI if reference exists in current scene
        if (challenge)
        {
            challenge.text = KilledenemiesforChallenge.ToString();
        }
        
        // Sync with GeneratingEnemies and auto-save
        if (genEnemies)
        {
            KilledenemiesforChallenge = genEnemies.enemiesKilled;
            SaveProgress();
        }
    }

    public void SaveProgress()
    {
        PlayerPrefs.SetInt(SAVE_KEY, KilledenemiesforChallenge);
        PlayerPrefs.Save();
    }

    public void LoadProgress()
    {
        KilledenemiesforChallenge = PlayerPrefs.HasKey(SAVE_KEY) ? PlayerPrefs.GetInt(SAVE_KEY) : 0;
    }

    public void ResetProgress()
    {
        KilledenemiesforChallenge = 0;
        PlayerPrefs.DeleteKey(SAVE_KEY);
        PlayerPrefs.Save();
        Debug.Log("Challenge progress reset");
    }
}