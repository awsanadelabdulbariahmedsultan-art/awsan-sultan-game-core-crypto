using System;
using System.Collections.Generic;
using UnityEngine;

/**
 * @className LayerCombiner
 * @dev Intellectual Property of ENG AWSAN ADEL ABDULBARI AHMED SULTAN
 * @notice Procedurally combines weapon/armor bases with the 45,000 unique Awsan Sultan Art skins.
 */
public class LayerCombiner : MonoBehaviour
{
    public const string DeveloperName = "ENG AWSAN ADEL ABDULBARI AHMED SULTAN";
    public const string DeveloperID = "01010305468";

    [Header("Layer Configuration")]
    public Renderer itemRenderer; // الموديل ثلاثي الأبعاد للسلاح أو الدرع المراد تعديله
    
    private Material runtimeMaterial;

    private void Awake()
    {
        if (itemRenderer != null)
        {
            // إنشاء نسخة مادية مخصصة في الوقت الفعلي لتجنب التعديل على الملف الأصلي
            runtimeMaterial = itemRenderer.material;
        }
    }

    /**
     * @notice دالة دمج الفن الرقمي كسكن (Skin) ديناميكي مع الاحتفاظ بخرائط الإضاءة والظلال
     * @param artworkTexture الصورة المحملة للفن من الـ 45 ألفاً
     */
    public void CombineArtworkSkin(Texture2D artworkTexture)
    {
        if (runtimeMaterial == null || artworkTexture == null) return;

        Debug.Log($"[{DeveloperName}] Procedurally injecting ASA Skin onto 3D Mesh Shaders...");

        // تعيين نسيج الفن الرقمي كألبوم أساسي للموديل (Main Texture)
        runtimeMaterial.SetTexture("_MainTex", artworkTexture);

        // تنشيط الخواص المعدنية والانعكاسية المتقدمة لتتوافق مع محركات الرسوميات الحديثة
        runtimeMaterial.SetFloat("_Metallic", 0.85f);
        runtimeMaterial.SetFloat("_Glossiness", 0.75f);

        // استدعاء نظام مطابقة خامات RTX تلقائياً لتطبيق إضاءة إنفيديا
        if (RtxMaterialMatcher.Instance != null)
        {
            RtxMaterialMatcher.Instance.ApplyRtxShaders(runtimeMaterial);
        }
    }
}
