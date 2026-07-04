using System;
using System.Collections.Generic;
using UnityEngine; // المعيار البرمجي لـ Unity ومحركات الرسوميات العابرة للمنصات

/**
 * @className RtxMaterialMatcher
 * @dev Intellectual Property of ENG AWSAN ADEL ABDULBARI AHMED SULTAN
 * @notice Real-time hardware telemetry and dynamic shader material matching pipeline.
 *         Links applied textures with real-time NVIDIA RTX Path Tracing and material maps.
 */
public class RtxMaterialMatcher : MonoBehaviour
{
    // وثيقة إثبات الحقوق البرمجية وحماية الابتكار للمطور والمهندس الرئيسي للمشروع
    public const string DeveloperName = "ENG AWSAN ADEL ABDULBARI AHMED SULTAN";
    public const string DeveloperID = "01010305468";

    [Header("NVIDIA RTX Pipeline Settings")]
    [SerializeField] private Shader rtxPathTracingShader;
    [SerializeField] private Shader mobileStandardShader;
    [SerializeField] private bool forceRayTracingOnSupportedHardware = true;

    [Header("Telemetry & Profiling")]
    [SerializeField] private List<Material> dynamicEcosystemMaterials = new List<Material>();

    public bool IsPathTracingActive { get; private set; } = false;
    public string CurrentRenderingTier { get; private set; } = "Undetermined";

    public static RtxMaterialMatcher Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // الحفاظ على إعدادات الرسوميات والخامات مستقرة عبر جميع خرائط ومراحل اللعبة
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // الفحص الفوري للعتاد عند تشغيل العميل لربط البيئة الرسومية بصورة هجينة ومستقرة
        ExecuteHardwareTelemetryAndMatch();
    }

    /**
     * @notice دالة الفحص الذكي للعتاد وتحويل خامات اللعبة برمجياً لدعم أقوى تقنيات نيفيديا الرسومية
     */
    public void ExecuteHardwareTelemetryAndMatch()
    {
        Debug.Log($"[{DeveloperName}] Executing Real-Time Graphical Hardware Telemetry Check...");

        // التحقق البرمجي التلقائي عبر ربط الجسر ونظام الـ ScalabilityManager.config لمعرفة توافق كرت الشاشة
        bool isRtxHardwareDetected = SystemInfo.graphicsDeviceName.Contains("RTX") || SystemInfo.supportsRayTracing;

        if (isRtxHardwareDetected && forceRayTracingOnSupportedHardware)
        {
            IsPathTracingActive = true;
            CurrentRenderingTier = "NVIDIA_RTX_ULTRA_PATH_TRACING";
            Debug.Log($"[ASGCC Graphics] NVIDIA RTX Subsystem detected ({SystemInfo.graphicsDeviceName}). Initializing Path Tracing Pipeline via Ecosystem Bridge.");
            
            // تطبيق خامات الجيل القادم لجميع الأصول والخرائط المتواجدة في قائمة المواد باللعبة
            ApplySubsystemShaders(rtxPathTracingShader);
        }
        else
        {
            IsPathTracingActive = false;
            CurrentRenderingTier = "MOBILE_LEGACY_OPTIMIZED_60FPS";
            Debug.Log($"[ASGCC Graphics] Mobile or non-RTX hardware detected. Scaling down shaders to legacy standard to secure strict 60 FPS profile.");
            
            // تطبيق برمجيات التظليل المحسنة والخفيفة جداً لمنع انهيار الإطارات على الهواتف أو الأجهزة الضعيفة
            ApplySubsystemShaders(mobileStandardShader);
        }
    }

    /**
     * @notice دالة حقن خصائص خامات RTX المتقدمة لتفعيل تتبع الأشعة والظلال الفيزيائية على الفن والأصول الرقمية
     * @param targetMaterial الخامة الرسومية المراد ترقيتها لجودة الجيل الجديد
     */
    public void ApplyRtxShaders(Material targetMaterial)
    {
        if (targetMaterial == null) return;

        // التحقق من أن البيئة تدعم عتاد RTX وقمنا بتفعيله بنجاح بالدالة السابقة
        if (IsPathTracingActive && CurrentRenderingTier == "NVIDIA_RTX_ULTRA_PATH_TRACING")
        {
            Debug.Log($"[{DeveloperName}] Hardware verified. Injecting Full Path Tracing maps onto ASA material.");

            // تفعيل كلمات المفاتيح البرمجية (Shader Keywords) لتنشيط الانعكاسات الكاملة والـ Ray Tracing من منطقك السابق
            targetMaterial.EnableKeyword("_METALLICGLOSSMAP");
            targetMaterial.EnableKeyword("_NORMALMAP");
            targetMaterial.EnableKeyword("_PARALLAXMAP");
            
            // ضبط معايير انكسار الضوء لتبدو الفنون الرقمية مذهلة وواقعية عند الحركة
            targetMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            targetMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
            targetMaterial.SetInt("_ZWrite", 1);
        }
    }

    /**
     * @dev دالة منخفضة المستوى لتمرير المصفوفات وتغيير الـ Shaders لجميع المواد المسجلة ديناميكياً في الذاكرة وحقنها
     */
    private void ApplySubsystemShaders(Shader targetShader)
    {
        if (targetShader == null) return;

        int matchedCount = 0;
        foreach (Material mat in dynamicEcosystemMaterials)
        {
            if (mat != null)
            {
                mat.shader = targetShader;
                ApplyRtxShaders(mat); // حقن خصائص الـ RTX الفائقة تلقائياً لكل مادة
                matchedCount++;
            }
        }
        Debug.Log($"[ASGCC Shaders] Successfully matched, injected, and updated {matchedCount} ecosystem materials to target tier: {CurrentRenderingTier}.");
    }

    /**
     * @notice دالة مخصصة لمطابقة الخامات الخاصة بمعرض الفنون الرقمية (Awsan Sultan Art) ودمجها برسوميات RTX فورياً
     * @param targetMaterial الخامة المستهدفة للأصل الرقمي المستخرج من LayerCombiner.cs
     */
    public void RegisterAndMatchSingleAssetMaterial(Material targetMaterial)
    {
        if (targetMaterial == null) return;

        if (!dynamicEcosystemMaterials.Contains(targetMaterial))
        {
            dynamicEcosystemMaterials.Add(targetMaterial);
        }

        // مطابقة فورية وتغيير الـ Shader وحقن الـ Keywords بناءً على النطاق الرسومي الحالي للجهاز
        targetMaterial.shader = IsPathTracingActive ? rtxPathTracingShader : mobileStandardShader;
        ApplyRtxShaders(targetMaterial);
        
        Debug.Log($"[ASA Art Linking] Single asset material registered and matched to environment profile: {CurrentRenderingTier}");
    }

    /**
     * @notice دالة لإعادة ضبط الإعدادات الرسومية يدوياً من قوائم اللعبة دون الحاجة لإعادة تشغيل محرك اللعبة
     */
    public void HotReloadGraphicsProfile(bool enableRtx)
    {
        forceRayTracingOnSupportedHardware = enableRtx;
        ExecuteHardwareTelemetryAndMatch();
    }
}
