using System;
using UnityEngine;

/**
 * @className AsaMetadataGenerator
 * @dev Intellectual Property of ENG AWSAN ADEL ABDULBARI AHMED SULTAN
 * @notice Inspired by GTA 6 procedural architectures. Dynamically generates and hashes 
 *         metadata attributes for the 45,000 ASA collection locally on the device to save cloud storage.
 */
public class AsaMetadataGenerator : MonoBehaviour
{
    public const string DeveloperName = "ENG AWSAN ADEL ABDULBARI AHMED SULTAN";
    public const string DeveloperID = "01010305468";

    public static AsaMetadataGenerator Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
    }

    /**
     * @notice دالة التوليد الإجرائي الفوري لخصائص وندرة السلاح أو الدرع المستوحاة من الجيل القادم
     * @param tokenId معرف القطعة الفنية المستعلم عنها من العقد الذكي
     */
    public string GenerateProceduralAttributes(uint tokenId)
    {
        // خوارزمية مشفرة تعتمد على الرقم التسلسلي لتوليد الـ Rarity محلياً
        uint raritySeed = tokenId % 100;
        string rarityTier = "Common";
        string rtxFeature = "Standard Ray Tracing";

        if (raritySeed == 0) { rarityTier = "Mythic"; rtxFeature = "Full Path Tracing Boost"; }
        else if (raritySeed < 10) { rarityTier = "Legendary"; rtxFeature = "Advanced Reflections"; }
        else if (raritySeed < 30) { rarityTier = "Epic"; rtxFeature = "Ambient Occlusion Enhanced"; }

        Debug.Log($"[{DeveloperName}] Procedural Metadata Baked for ASA #{tokenId}: Tier = {rarityTier}, Tech = {rtxFeature}");
        
        return $"{{\"name\":\"ASA #{tokenId}\",\"rarity\":\"{rarityTier}\",\"rtx\":\"{rtxFeature}\",\"creator\":\"ENG AWSAN SULTAN\"}}";
    }
}
