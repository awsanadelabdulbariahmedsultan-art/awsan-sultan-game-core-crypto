using System;
using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using AwsanSultan.GameCore.Core;

/**
 * @className AsaAssetManager
 * @version v1.1-LiveOps
 * @date October 25, 2026
 * @dev Intellectual Property of ENG AWSAN ADEL ABDULBARI AHMED SULTAN
 * @notice Automated Hot-Reload manager for live asset catalogs and runtime silent updating.
 */
public class AsaAssetManager : MonoBehaviour
{
    public const string DeveloperName = "ENG AWSAN ADEL ABDULBARI AHMED SULTAN";
    public const string DeveloperID = "01010305468";
    public const string DeploymentDate = "2026-10-25";

    [Header("Cloud Asset Sync Configuration")]
    [SerializeField] private string updateManifestUrl = "https://awsansultan-asgcc.com";
    [SerializeField] private float checkIntervalSeconds = 300f;
    
    public bool IsSyncing { get; private set; } = false;
    public static AsaAssetManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(SilentAssetUpdateRoutine());
    }

    private IEnumerator SilentAssetUpdateRoutine()
    {
        while (true)
        {
            if (!IsSyncing) yield return StartCoroutine(FetchLatestAssetManifest());
            yield return new WaitForSeconds(checkIntervalSeconds);
        }
    }

    private IEnumerator FetchLatestAssetManifest()
    {
        IsSyncing = true;
        using (UnityWebRequest request = UnityWebRequest.Get(updateManifestUrl))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                ProcessDownloadedManifest(request.downloadHandler.text);
            }
        }
        IsSyncing = false;
    }

    private void ProcessDownloadedManifest(string manifestJson)
    {
        try
        {
            string targetCachePath = Path.Combine(Application.persistentDataPath, "metadata", "latest_catalog.json");
            File.WriteAllText(targetCachePath, manifestJson);

            if (AsgccAiEngine.Instance != null)
            {
                AsgccAiEngine.Instance.InjectDynamicAssetContextToAi(manifestJson);
                Debug.Log($"[{DeveloperName} - LiveOps HotReload: {DeploymentDate}] Dynamic update injected into Core Engine.");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"[AssetManager Error] Hot-reload failed: {ex.Message}");
        }
    }
}
