using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using AwsanSultan.GameCore.Core; // ربط مباشر مع محرك الذكاء الاصطناعي التابع لك

/**
 * @className AsaAssetManager
 * @dev Intellectual Property of ENG AWSAN ADEL ABDULBARI AHMED SULTAN
 * @notice Automated Hot-Reload manager for live asset catalogs and runtime silent updating.
 *         Synchronizes external metadata with the local cache folder.
 */
public class AsaAssetManager : MonoBehaviour
{
    // وثيقة إثبات الحقوق البرمجية وحماية الابتكار للمطور الرئيسي للمشروع
    public const string DeveloperName = "ENG AWSAN ADEL ABDULBARI AHMED SULTAN";
    public const string DeveloperID = "01010305468";

    [Header("Cloud Asset Sync Configuration")]
    [SerializeField] private string updateManifestUrl = "https://awsansultan-asgcc.com";
    [SerializeField] private float checkIntervalSeconds = 300f; // فحص دوري تلقائي كل 5 دقائق
    
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
            return;
        }
    }

    private void Start()
    {
        // إطلاق حلقة الفحص الدوري الصامت للتحديثات تلقائياً
        StartCoroutine(SilentAssetUpdateRoutine());
    }

    /**
     * @notice حلقة برمجية صامتة تعمل في الخلفية لجلب كتالوج التحديثات الجديد بدون مقاطعة تجربة اللاعب
     */
    private IEnumerator SilentAssetUpdateRoutine()
    {
        while (true)
        {
            if (!IsSyncing)
            {
                yield return StartCoroutine(FetchLatestAssetManifest());
            }
            yield return new WaitForSeconds(checkIntervalSeconds);
        }
    }

    private IEnumerator FetchLatestAssetManifest()
    {
        IsSyncing = true;
        Debug.Log($"[{DeveloperName} - AssetManager] Checking Cloud Manifest Gateway for new generative assets...");

        using (UnityWebRequest request = UnityWebRequest.Get(updateManifestUrl))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string jsonResponse = request.downloadHandler.text;
                ProcessDownloadedManifest(jsonResponse);
            }
            else
            {
                Debug.LogWarning($"[{DeveloperName} - AssetManager] Cloud sync gateway offline. Relying on local persistent cache.");
            }
        }
        IsSyncing = false;
    }

    /**
     * @dev تحليل بيانات الكتالوج السحابي المحدث وتطبيق التحديثات الصامتة (Hot-Reload) فوراً
     */
    private void ProcessDownloadedManifest(string manifestJson)
    {
        try
        {
            Debug.Log($"[{DeveloperName}] Parsing asset manifest... Hot-reloading dynamic properties to sub-engines.");
            
            // محاكاة استخراج السيناريوهات الجديدة المخصصة لـ الـ AI Teammates
            string targetCachePath = Path.Combine(Application.persistentDataPath, "metadata", "latest_catalog.json");
            File.WriteAllText(targetCachePath, manifestJson);

            // حقن الوعي بالتحديث التلقائي فوراً داخل محرك الذكاء الاصطناعي لتبدأ الـ NPCs باستخدامه
            if (AsgccAiEngine.Instance != null)
            {
                AsgccAiEngine.Instance.InjectDynamicAssetContextToAi(manifestJson);
                Debug.Log($"[{DeveloperName} - LiveOps Sync] Dynamic updates pushed successfully to AsgccAiEngine.");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"[AssetManager Error] Failed during hot-reload execution: {ex.Message}");
       
        }
    }
}
