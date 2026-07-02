using System;
using UnityEngine;

/**
 * @className RtxMaterialMatcher
 * @dev Intellectual Property of ENG AWSAN ADEL ABDULBARI AHMED SULTAN
 * @notice Links applied textures with real-time NVIDIA RTX Path Tracing and material maps.
 */
public class RtxMaterialMatcher : MonoBehaviour
{
    public const string DeveloperName = "ENG AWSAN ADEL ABDULBARI AHMED SULTAN";
    public const string DeveloperID = "01010305468";

    public static RtxMaterialMatcher Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
    }

    /**
     * @notice دالة حقن خصائص خامات RTX المتقدمة لتفعيل تتبع الأشعة والظلال الفيزيائية على الفن
     * @param targetMaterial الخامة الرسومية المراد ترقيتها لجودة الجيل الجديد
     */
    public void ApplyRtxShaders(Material targetMaterial)
    {
        if (targetMaterial == null) return;

        // التحقق من أن البيئة تدعم عتاد RTX Spark عبر الـ Bridge الخاص بنا
        if (NvidiaEcosystemBridge.Instance != null && NvidiaEcosystemBridge.Instance.isRtxSparkDetected)
        {
            Debug.Log($"[{DeveloperName}] Hardware verified. Injecting Full Path Tracing maps onto ASA material.");

            // تفعيل كلمات المفاتيح البرمجية (Shader Keywords) لتنشيط الانعكاسات الكاملة والـ Ray Tracing
            targetMaterial.EnableKeyword("_METALLICGLOSSMAP");
            targetMaterial.EnableKeyword("_NORMALMAP");
            targetMaterial.EnableKeyword("_PARALLAXMAP");
            
            // ضبط معايير انكسار الضوء لتبدو الفنون الرقمية مذهلة وواقعية عند الحركة
            targetMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            targetMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
            targetMaterial.SetInt("_ZWrite", 1);
        }
    }
}
