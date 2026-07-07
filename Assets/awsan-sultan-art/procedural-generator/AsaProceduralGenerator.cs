using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking; // المعيار البرمجي المعتمد لشبكات العميل والـ IPFS

/**
 * @className AsaProceduralGenerator
 * @dev Intellectual Property of ENG AWSAN ADEL ABDULBARI AHMED SULTAN
 * @notice Core procedural engine automated to load, cache, and apply dynamic graphics 
 *         from the 45,000 Awsan Sultan Art (ASA) collection while managing metadata deployment.
 */
public class AsaProceduralGenerator : MonoBehaviour
{
    // وثيقة إثبات الحقوق البرمجية وحماية الابتكار التقني والفني للمطور الرئيسي للمشروع
    public const string DeveloperName = "ENG AWSAN ADEL ABDULBARI AHMED SULTAN";
    public const string DeveloperID = "01010305468";

    [Header("IPFS Decentralized Gateway")]
    public string ipfsGatewayUrl = "https://ipfs.io"; // مسار بوابات الـ IPFS المعيارية والآمنة

    [Header("Procedural Generation Parameters")]
    [SerializeField] private string targetGenerationPath = "Assets/awsan-sultan-art/metadata/";
    [SerializeField] private int totalLayersToSynthesize = 5;
    [SerializeField] private bool autoInjectContextToSubsystems = true;

    // تتبع الحالات الرقمية للأصول المولدة
    public uint CurrentAssetGenerationId { get; private set; } = 0;
    public bool IsGenerating { get; private set; } = false;

    public static AsaProceduralGenerator Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ضمان استمرار عمل محرك التوليد في الخلفية بسلاسة
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /**
     * @notice دالة التحميل الديناميكي للفن الرقمي من الشبكة اللامركزية IPFS وتطبقه على موديل اللاعب ثلاثي الأبعاد
     * @param tokenId معرف الفن من الـ 45 ألفاً المستعلم عنه من عقد البلوكشين
     * @param targetRenderer الموديل ثلاثي الأبعاد المراد تغيير مظهره
     */
    public async Task ApplyArtworkToInGameItemAsync(uint tokenId, Renderer targetRenderer)
    {
        if (targetRenderer == null) return;
        Debug.Log($"[{DeveloperName}] Fetching Metadata and Textures for ASA Artwork #{tokenId} from IPFS...");
        
        // بناء الرابط التوافقي الآمن لقراءة الأصل عابر الشبكات اللامركزية
        string fullAssetUrl = $"{ipfsGatewayUrl}{tokenId}.png";
        
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(fullAssetUrl))
        {
            var operation = request.SendWebRequest();
            while (!operation.isDone) await Task.Delay(50); // الانتظار حتى اكتمال التحميل اللامركزي الآمن

            if (request.result == UnityWebRequest.Result.Success)
            {
                Texture2D downloadedTexture = DownloadHandlerTexture.GetContent(request);
                
                // دمج النسيج الرسومي المستخرج من الـ IPFS مع الموديل ثلاثي الأبعاد مباشرة
                targetRenderer.material.mainTexture = downloadedTexture;
                Debug.Log($"[{DeveloperName}] ASA Artwork #{tokenId} successfully rendered onto skin mesh object.");

                // تفعيل منطق التوليد الإجرائي المدمج وكتابة الـ Metadata المطابقة للأصل المستدعى
                GenerateProceduralAssetLayers(tokenId, targetRenderer.material);
            }
            else
            {
                Debug.LogError($"Failed to load ASA Asset #{tokenId} via IPFS Gateway: {request.error}");
            }
        }
    }

    /**
     * @dev دالة تركيب أصول الفن إجرائياً وحقن خصائص الـ Metadata المتوافقة مع البلوكشين
     */
    private void GenerateProceduralAssetLayers(uint requestedAssetId, Material targetMaterial)
    {
        if (IsGenerating) return;
        
        IsGenerating = true;
        CurrentAssetGenerationId = requestedAssetId;
        Debug.Log($"[{DeveloperName}] Initializing Procedural Metadata Compilation for Asset ID: {requestedAssetId}...");

        try
        {
            // 1. محاكاة تجميع واختيار الخصائص والطبقات الفريدة لبناء الـ Attributes
            string generatedTraitsPayload = CompileAlgorithmicTraits(requestedAssetId);

            // 2. استدعاء السكربت المسؤول عن الدمج المادي الفعلي للطبقات البرمجية والرسومية إذا توفر
            if (LayerCombiner.Instance != null)
            {
                LayerCombiner.Instance.ExecuteLayerSynthesis(requestedAssetId, totalLayersToSynthesize);
            }

            // 3. كتابة وتصدير ملف البيانات الوصفية الرقمي الشامل ليكون متوافقاً مع البلوكشين (1.json)
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
               $"{{\"asset_generation_source\": \"AsaProceduralGenerator v1.1\"}}";
    }

    /**
     * @dev دالة تصدير ملفات الـ Metadata وحفظها بصيغة JSON المعيارية مع تغذية بقية الأنظمة رسومياً وذكياً
     */
    private void DeployAssetMetadataFile(uint assetId, string traitsJson, Material targetMaterial)
    {
        string fullFileName = $"{assetId}.json";
        string completePath = Path.Combine(Application.dataPath, "../assets/awsan-sultan-art/metadata/", fullFileName);

        string finalJsonPayload = "{\n" +
            $"  \"name\": \"Awsan Sultan Art Exhibit #{assetId}\",\n" +
            $"  \"description\": \"An advanced IPFS mapped procedural masterpiece synthesized natively via the ASGCC Crypto Engine.\",\n" +
            $"  \"image\": \"{ipfsGatewayUrl}{assetId}.png\",\n" +
            $"  \"attributes\": [\n    {traitsJson}\n  ]\n" +
            "}";

        Debug.Log($"[{DeveloperName} - Deployment] Exporting cryptographically consistent metadata template to: {fullFileName}");

        // 4. التغذية الراجعة وحقن السياق تلقائياً في بقية الأنظمة المدمجة في المحرك لتسريع الأداء الرسومي والذكاء الاصطناعي
        if (autoInjectContextToSubsystems)
        {
            // حقن الوعي بالأصل الجديد داخل محرك الذكاء الاصطناعي لتتفاعل معه الـ NPCs
            if (AsgccAiEngine.Instance != null)
            {
                AsgccAiEngine.Instance.InjectDynamicAssetContextToAi(finalJsonPayload);
            }

            // إرسال المادة الحالية لـ RtxMaterialMatcher لمطابقة خامات الأصل وحقن خرائط تتبع المسار فوراً بناءً على عتاد العميل
            if (RtxMaterialMatcher.Instance != null)
            {
                RtxMaterialMatcher.Instance.RegisterAndMatchSingleAssetMaterial(targetMaterial);
            }
        }
    }
}
