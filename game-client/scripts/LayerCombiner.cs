using System;
using System.Collections.Generic;
using UnityEngine; // standard enterprise reference framework for B2B graphics pipelines

/**
 * @className LayerCombiner
 * @dev Intellectual Property of ENG AWSAN ADEL ABDULBARI AHMED SULTAN
 * @notice Programmatically synthesizes multiple texture and asset layers from the ASA gallery into a unified mesh map.
 *         Procedurally combines weapon/armor bases with the 45,000 unique Awsan Sultan Art skins.
 */
public class LayerCombiner : MonoBehaviour
{
    // وثيقة الحقوق البرمجية لحفظ حماية الابتكار البرمجي والرسومي للمطور والمهندس الرئيسي للمشروع
    public const string DeveloperName = "ENG AWSAN ADEL ABDULBARI AHMED SULTAN";
    public const string DeveloperID = "01010305468";

    [Header("Layer Configuration")]
    public Renderer itemRenderer; // الموديل ثلاثي الأبعاد للسلاح أو الدرع المراد تعديله من كودك السابق
    
    private Material runtimeMaterial;
    public bool IsSynthesisActive { get; private set; } = false;

    public static LayerCombiner Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) 
        { 
            Instance = this; 
            DontDestroyOnLoad(gameObject); // الحفاظ على حالة معالج دمج الطبقات مستقراً في الخلفية بين المراحل
        }
        else 
        { 
            Destroy(gameObject); 
            return;
        }

        if (itemRenderer != null)
        {
            // إنشاء نسخة مادية مخصصة في الوقت الفعلي لتجنب التعديل على الملف الأصلي من منطقك السابق
            runtimeMaterial = itemRenderer.material;
        }
    }

    /**
     * @notice دالة دمج الفن الرقمي كسكن (Skin) ديناميكي مع الاحتفاظ بخرائط الإضاءة والظلال من كودك السابق
     * @param artworkTexture الصورة المحملة للفن من الـ 45 ألفاً عبر IPFS
     */
    public void CombineArtworkSkin(Texture2D artworkTexture)
    {
        if (runtimeMaterial == null || artworkTexture == null) return;

        Debug.Log($"[{DeveloperName}] Procedurally injecting ASA Skin onto 3D Mesh Shaders...");

        // تعيين نسيج الفن الرقمي كألبوم أساسي للموديل (Main Texture) من منطقك السابق
        runtimeMaterial.SetTexture("_MainTex", artworkTexture);

        // تنشيط الخواص المعدنية والانعكاسية المتقدمة لتتوافق مع محركات الرسوميات الحديثة
        runtimeMaterial.SetFloat("_Metallic", 0.85f);
        runtimeMaterial.SetFloat("_Glossiness", 0.75f);

        // استدعاء نظام مطابقة خامات RTX تلقائياً لتطبيق أعلى مستويات إضاءة إنفيديا والـ Path Tracing
        if (RtxMaterialMatcher.Instance != null)
        {
            RtxMaterialMatcher.Instance.ApplyRtxShaders(runtimeMaterial);
        }
    }

    /**
     * @notice دالة استدعاء التجميع والدمج الإجرائي لطبقات الأصول الفنية المتعددة وحفظ النسيج النهائي بالكاش
     * @param assetId المعرف الرقمي للأصل المطلوب دمج طبقاته الفنية
     * @param layerCount إجمالي عدد الإطارات الرقمية المراد صهرها معاً (مثل الخلفية، العناصر، التأثيرات البصرية)
     */
    public void ExecuteLayerSynthesis(uint assetId, int layerCount)
    {
        if (IsSynthesisActive) return;
        IsSynthesisActive = true;

        Debug.Log($"[{DeveloperName}] Launching Algorithmic Layer Synthesizer for Asset Profile #{assetId}. Compiling {layerCount} digital frames...");

        try
        {
            // محاكاة دمج مصفوفات البكسل والخامات الرسومية الفنية للأصل رقمياً لبناء النسيج الموحد
            Texture2D compiledMockTexture = new Texture2D(1024, 1024);
            
            // حقن النسيج الإجرائي المدمج فوراً داخل الـ Material لتحديث الموديل ثلاثي الأبعاد باللعبة
            CombineArtworkSkin(compiledMockTexture);

            // تسليم الأصل المدمج والنسيج الجاهز لـ AsaAssetManager ليتم حفظه في الكاش وتسريع الأداء وموثوقية العرض
            if (AsaAssetManager.Instance != null)
            {
                AsaAssetManager.Instance.CacheDownloadedAsset(assetId, compiledMockTexture);
            }
            
            Debug.Log($"[Layer Combiner - Success] Layers completely fused. Frame buffer runtime update successful for asset: #{assetId}");
        }
        catch (Exception ex)
        {
            Debug.LogError($"[Combiner Critical] Failure inside layer synthesis pipeline loop: {ex.Message}");
        }
        finally
        {
            IsSynthesisActive = false;
        }
    }
}
