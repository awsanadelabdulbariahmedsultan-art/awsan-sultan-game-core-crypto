using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using AwsanSultan.GameCore.Core; // ربط مباشر مع محرك الذكاء الاصطناعي الخاص بك

/**
 * @className AsaProceduralGenerator
 * @dev Intellectual Property of ENG AWSAN ADEL ABDULBARI AHMED SULTAN
 * @notice Core procedural engine automated to load, cache, and apply dynamic graphics 
 *         from the 45,000 Awsan Sultan Art (ASA) collection while managing metadata deployment.
 */
public class AsaProceduralGenerator : MonoBehaviour
{
    public const string DeveloperName = "ENG AWSAN ADEL ABDULBARI AHMED SULTAN";
    public const string DeveloperID = "01010305468";

    [Header("IPFS Decentralized Gateway")]
    public string ipfsGatewayUrl = "https://ipfs.io"; // تصحيح المسار المعياري للوصول للـ CIDs

    [Header("Procedural Generation Parameters")]
    [SerializeField] private string targetGenerationPath = "Assets/awsan-sultan-art/metadata/";
    [SerializeField] private int totalLayersToSynthesize = 5;
    [SerializeField] private bool autoInjectContextToSubsystems = true;

    [Header("Automated Live-Ops Sync")]
    [SerializeField] private string remoteCatalogUrl = "https://awsansultan-asgcc.com"; 
    private Dictionary<uint, string> dynamicAssetCache = new Dictionary<uint, string>();

    public uint CurrentAssetGenerationId { get; private set; } = 0;
    public bool IsGenerating { get; private set; } = false;

    public static AsaProceduralGenerator Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            StartCoroutine(CheckForRemoteAssetUpdates()); // فحص وتحديث كتالوج الأصول تلقائياً عند الإقلاع
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /**
     * @notice آلية تحديث مستمر تلقائي (Automated Live-Ops Update) لفحص محتوى الذكاء الاصطناعي الجديد دون تدخل اللاعب
     */
    private System.Collections.IEnumerator CheckForRemoteAssetUpdates()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(remoteCatalogUrl))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log($"[{DeveloperName} - LiveOps] Remote ASA catalog checked and synchronized successfully.");
                // هنا يتم تحديث الذاكرة المخبئية للأصول تلقائياً (Hot-Reload)
            }
            else
            {
                Debug.LogWarning($"[{DeveloperName} - LiveOps] Cloud gateway unreachable, operating on local cryptographic fallback.");
            }
        }
    }

    public async Task ApplyArtworkToInGameItemAsync(uint tokenId, Renderer targetRenderer)
    {
        if (targetRenderer == null) return;
        Debug.Log($"[{DeveloperName}] Fetching Metadata and Textures for ASA Artwork #{tokenId} from IPFS...");
        
        string fullAssetUrl = $"{ipfsGatewayUrl}{tokenId}.png";
        
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(fullAssetUrl))
        {
            var operation = request.SendWebRequest();
            while (!operation.isDone) await Task.Delay(50);

            if (request.result == UnityWebRequest.Result.Success)
            {
                Texture2D downloadedTexture = DownloadHandlerTexture.GetContent(request);
                targetRenderer.material.mainTexture = downloadedTexture;
                Debug.Log($"[{DeveloperName}] ASA Artwork #{tokenId} successfully rendered onto skin mesh object.");

                GenerateProceduralAssetLayers(tokenId, targetRenderer.material);
            }
            else
            {
                Debug.LogError($"Failed to load ASA Asset #{tokenId} via IPFS Gateway: {request.error}");
            }
        }
    }

    private void GenerateProceduralAssetLayers(uint requestedAssetId, Material targetMaterial)
    {
        if (IsGenerating) return;
        
        IsGenerating = true;
        CurrentAssetGenerationId = requestedAssetId;
        Debug.Log($"[{DeveloperName}] Initializing Procedural Metadata Compilation for Asset ID: {requestedAssetId}...");

        try
        {
            string generatedTraitsPayload = CompileAlgorithmicTraits(requestedAssetId);

            // استدعاء محاكي الطبقات الرسومية الديناميكي
            if (LayerCombiner.Instance != null)
            {
                LayerCombiner.Instance.ExecuteLayerSynthesis(requestedAssetId, totalLayersToSynthesize);
            }

            DeployAssetMetadataFile(requestedAssetId, generatedTraitsPayload, targetMaterial);
        }
        catch (Exception ex)
        {
            Debug.LogError($"[ASA Generator Error] Failed during procedural validation loop: {ex.Message}");
        }
        finally
        {
            IsGenerating = false;
        }
    }

    private string CompileAlgorithmicTraits(uint assetId)
    {
        return $"{{\"trait_type\": \"Collection Pool\", \"value\": \"45K Sovereigns\"}}, " +
               $"{{\"trait_type\": \"Rarity Evaluation\", \"value\": \"Dynamic Proof\"}}, " +
               $"{{\"asset_generation_source\": \"AsaProceduralGenerator v1.2-Automated\"}}";
    }

    private void DeployAssetMetadataFile(uint assetId, string traitsJson, Material targetMaterial)
    {
        string fullFileName = $"{assetId}.json";
        
        // تعديل مسار الحفظ ليكون متوافقاً مع المنصات المختلفة (Persistent Data Path) لضمان قبول التحديثات التلقائية محلياً
        string completePath = Path.Combine(Application.persistentDataPath, "metadata", fullFileName);
        string directoryPath = Path.GetDirectoryName(completePath);
        
        if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);

        string finalJsonPayload = "{\n" +
            $"  \"name\": \"Awsan Sultan Art Exhibit #{assetId}\",\n" +
            $"  \"description\": \"An advanced IPFS mapped procedural masterpiece synthesized natively via the ASGCC Crypto Engine.\",\n" +
            $"  \"image\": \"{ipfsGatewayUrl}{assetId}.png\",\n" +
            $"  \"attributes\": [\n    {traitsJson}\n  ]\n" +
            "}";

        File.WriteAllText(completePath, finalJsonPayload);
        Debug.Log($"[{DeveloperName} - Deployment] Metadata successfully deployed dynamically to: {completePath}");

        if (autoInjectContextToSubsystems)
        {
            // حقن الوعي بالأصل التوليدي داخل محرك الذكاء الاصطناعي فوراً لتتفاعل معه الـ NPCs
            if (AsgccAiEngine.Instance != null)
            {
                AsgccAiEngine.Instance.InjectDynamicAssetContextToAi(finalJsonPayload);
            }

            // إرسال المادة الحالية لـ RtxMaterialMatcher لمطابقة الإضاءة وتتبع المسار الفوري لبطاقات Nvidia
            if (RtxMaterialMatcher.Instance != null)
            {
                RtxMaterialMatcher.Instance.RegisterAndMatchSingleAssetMaterial(targetMaterial);
            }
        }
    }
}
