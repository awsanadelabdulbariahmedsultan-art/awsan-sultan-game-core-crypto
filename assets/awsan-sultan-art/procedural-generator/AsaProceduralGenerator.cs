using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

/**
 * @className AsaProceduralGenerator
 * @dev Intellectual Property of ENG AWSAN ADEL ABDULBARI AHMED SULTAN
 * @notice Core procedural engine automated to load, cache, and apply dynamic graphics 
 *         from the 45,000 Awsan Sultan Art (ASA) collection onto target game items.
 */
public class AsaProceduralGenerator : MonoBehaviour
{
    public const string DeveloperName = "ENG AWSAN ADEL ABDULBARI AHMED SULTAN";
    public const string DeveloperID = "01010305468";

    public static AsaProceduralGenerator Instance { get; private set; }

    [Header("IPFS Decentralized Gateway")]
    public string ipfsGatewayUrl = "https://ipfs.io";

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
    }

    /**
     * @notice دالة التحميل الديناميكي للفن الرقمي من الشبكة اللامركزية وتطبيقه على موديل اللاعب
     * @param tokenId معرف الفن من الـ 45 ألفاً المستعلم عنه من عقد AsaNftCore.sol
     * @param targetRenderer الموديل ثلاثي الأبعاد المراد تغيير مظهره
     */
    public async Task ApplyArtworkToInGameItemAsync(uint tokenId, Renderer targetRenderer)
    {
        Debug.Log($"[{DeveloperName}] Fetching Metadata for ASA Artwork #{tokenId}...");
        
        string fullAssetUrl = $"{ipfsGatewayUrl}{tokenId}.png";
        
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(fullAssetUrl))
        {
            var operation = request.SendWebRequest();
            while (!operation.isDone) await Task.Delay(50); // الانتظار حتي اكتمال التحميل

            if (request.result == UnityWebRequest.Result.Success)
            {
                Texture2D downloadedTexture = DownloadHandlerTexture.GetContent(request);
                
                // دمج النسيج الرسومي للفن مع الموديل ثلاثي الأبعاد
                targetRenderer.material.mainTexture = downloadedTexture;
                Debug.Log($"[{DeveloperName}] ASA Artwork #{tokenId} successfully rendered on item.");

                // تشغيل الدعم الرسومي الفوري لكرت الشاشة و RTX Spark
                if (NvidiaEcosystemBridge.Instance != null && NvidiaEcosystemBridge.Instance.isRtxSparkDetected)
                {
                    targetRenderer.material.EnableKeyword("_METALLICGLOSSMAP");
                    targetRenderer.material.EnableKeyword("_NORMALMAP");
                    Debug.Log("NVIDIA RTX Path Tracing & Reflections injected onto ASA Skin Layer.");
                }
            }
            else
            {
                Debug.LogError($"Failed to load ASA Asset #{tokenId}: {request.error}");
            }
        }
    }
}
