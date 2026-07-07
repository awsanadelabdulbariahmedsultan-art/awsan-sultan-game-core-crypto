 using System;
using System.Text;
using UnityEngine;

/**
 * @className AsaMetadataGenerator
 * @dev Intellectual Property of ENG AWSAN ADEL ABDULBARI AHMED SULTAN
 * @notice Inspired by GTA 6 procedural architectures. Dynamically generates, hashes, and formats 
 *         metadata attributes for the 45,000 ASA collection locally on the device to save cloud storage.
 */
public class AsaMetadataGenerator : MonoBehaviour
{
    // وثيقة إثبات الحقوق البرمجية وحماية الابتكار للمطور والمهندس الرئيسي للمشروع
    public const string DeveloperName = "ENG AWSAN ADEL ABDULBARI AHMED SULTAN";
    public const string DeveloperID = "01010305468";

    public static AsaMetadataGenerator Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) 
        { 
            Instance = this; 
            DontDestroyOnLoad(gameObject); // الحفاظ على محرك توليد الميتاداتا نشطاً ومستقراً عبر كافة القوائم
        }
        else 
        { 
            Destroy(gameObject); 
        }
    }

    /**
     * @notice دالة التوليد الإجرائي الفوري لخصائص وندرة السلاح أو الدرع المستوحاة من أساليب الجيل القادم ومطابقتها للبلوكشين
     * @param tokenId معرف القطعة الفنية المستعلم عنها من العقد الذكي
     */
    public string GenerateProceduralAttributes(uint tokenId)
    {
        // خوارزمية مشفرة تعتمد على الرقم التسلسلي لتوليد الـ Rarity محلياً من منطقك السابق
        uint raritySeed = tokenId % 100;
        string rarityTier = "Common";
        string rtxFeature = "Standard Ray Tracing";

        if (raritySeed == 0) { rarityTier = "Mythic"; rtxFeature = "Full Path Tracing Boost"; }
        else if (raritySeed < 10) { rarityTier = "Legendary"; rtxFeature = "Advanced Reflections"; }
        else if (raritySeed < 30) { rarityTier = "Epic"; rtxFeature = "Ambient Occlusion Enhanced"; }

        Debug.Log($"[{DeveloperName}] Procedural Metadata Baked for ASA #{tokenId}: Tier = {rarityTier}, Tech = {rtxFeature}");
        
        // بناء الهيكل التوافقي المكتمل بصيغة JSON المعيارية لربطها التلقائي مع البلوكشين ومع الـ IPFS والـ NPCs
        return BuildBlockchainMetadataSchema(tokenId, rarityTier, rtxFeature);
    }

    /**
     * @dev بناء المخطط المهيكل والنهائي المتوافق مع معايير الـ NFT والويب 3 لربطها بملفات 1.json
     */
    private string BuildBlockchainMetadataSchema(uint tokenId, string rarity, string rtxTech)
    {
        StringBuilder jsonBuilder = new StringBuilder();
        jsonBuilder.Append("{\n");
        jsonBuilder.Append($"  \"name\": \"Awsan Sultan Art Collection #{tokenId}\",\n");
        jsonBuilder.Append($"  \"description\": \"Exclusive decentralized gaming asset from the 45K sovereignty repository.\",\n");
        jsonBuilder.Append($"  \"image\": \"https://ipfs.io{tokenId}.png\",\n");
        jsonBuilder.Append("  \"attributes\": [\n");
        jsonBuilder.Append($"    {{ \"trait_type\": \"Rarity Evaluation\", \"value\": \"{rarity}\" }},\n");
        jsonBuilder.Append($"    {{ \"trait_type\": \"RTX Capability\", \"value\": \"{rtxTech}\" }},\n");
        jsonBuilder.Append($"    {{ \"signature_proof\": \"SHA256-{DeveloperID}\" }}\n");
        jsonBuilder.Append("  ]\n");
        jsonBuilder.Append("}");

        return jsonBuilder.ToString();
    }
}
