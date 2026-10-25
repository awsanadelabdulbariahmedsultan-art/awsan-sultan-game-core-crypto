using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using AwsanSultan.GameCore.Core;

/**
 * @className AsaProceduralGenerator
 * @version v1.2-Automated
 * @date October 25, 2026
 * @dev Intellectual Property of ENG AWSAN ADEL ABDULBARI AHMED SULTAN
 * @notice Core procedural engine automated to load, cache, and apply dynamic graphics 
 *         from the 45,000 Awsan Sultan Art (ASA) collection while managing metadata deployment.
 */
public class AsaProceduralGenerator : MonoBehaviour
{
    public const string DeveloperName = "ENG AWSAN ADEL ABDULBARI AHMED SULTAN";
    public const string DeveloperID = "01010305468";
    public const string DeploymentDate = "2026-10-25";

    [Header("IPFS Decentralized Gateway")]
    public string ipfsGatewayUrl = "https://ipfs.io";

    [Header("Procedural Generation Parameters")]
    [SerializeField] private string targetGenerationPath = "Assets/awsan-sultan-art/metadata/";
    [SerializeField] private int totalLayersToSynthesize = 5;
    [SerializeField] private bool autoInjectContextToSubsystems = true;

    [Header("Automated Live-Ops Sync")]
    [SerializeField] private string remoteCatalogUrl = "https://awsansultan-asgcc.com"; 

    public uint CurrentAssetGenerationId { get; private set; } = 0;
    public bool IsGenerating { get; private set; } = false;

    public static AsaProceduralGenerator Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            StartCoroutine(CheckForRemoteAssetUpdates());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private System.Collections.IEnumerator CheckForRemoteAssetUpdates()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(remoteCatalogUrl))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log($"[{DeveloperName} - LiveOps Sync: {DeploymentDate}] Remote ASA catalog synchronized.");
            }
        }
    }

    public async Task ApplyArtworkToInGameItemAsync(uint tokenId, Renderer targetRenderer)
    {
        if (targetRenderer == null) return;
        
        string fullAssetUrl = $"{ipfsGatewayUrl}{tokenId}.png";
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(fullAssetUrl))
        {
            var operation = request.SendWebRequest();
            while (!operation.isDone) await Task.Delay(50);

            if (request.result == UnityWebRequest.Result.Success)
            {
                Texture2D downloadedTexture = DownloadHandlerTexture.GetContent(request);
                targetRenderer.material.mainTexture = downloadedTexture;
                GenerateProceduralAssetLayers(tokenId, targetRenderer.material);
            }
        }
    }

    private void GenerateProceduralAssetLayers(uint requestedAssetId, Material targetMaterial)
    {
        if (IsGenerating) return;
        IsGenerating = true;
        CurrentAssetGenerationId = requestedAssetId;

        try
        {
            string generatedTraitsPayload = CompileAlgorithmicTraits(requestedAssetId);
            if (LayerCombiner.Instance != null)
            {
                LayerCombiner.Instance.ExecuteLayerSynthesis(requestedAssetId, totalLayersToSynthesize);
            }
            DeployAssetMetadataFile(requestedAssetId, generatedTraitsPayload, targetMaterial);
        }
        finally
        {
            IsGenerating = false;
        }
    }

    private string CompileAlgorithmicTraits(uint assetId)
    {
        return $"{{\"trait_type\": \"Collection Pool\", \"value\": \"45K Sovereigns\"}}, {{\"asset_generation_source\": \"AsaProceduralGenerator v1.2-Automated\"}}";
    }

    private void DeployAssetMetadataFile(uint assetId, string traitsJson, Material targetMaterial)
    {
        string fullFileName = $"{assetId}.json";
        string completePath = Path.Combine(Application.persistentDataPath, "metadata", fullFileName);
        string directoryPath = Path.GetDirectoryName(completePath);
        
        if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);

        string finalJsonPayload = "{\n" +
            $"  \"name\": \"Awsan Sultan Art Exhibit #{assetId}\",\n" +
            $"  \"image\": \"{ipfsGatewayUrl}{assetId}.png\",\n" +
            $"  \"attributes\": [\n    {traitsJson}\n  ]\n" +
            "}";

        File.WriteAllText(completePath, finalJsonPayload);

        if (autoInjectContextToSubsystems)
        {
            if (AsgccAiEngine.Instance != null)
            {
                AsgccAiEngine.Instance.InjectDynamicAssetContextToAi(finalJsonPayload);
            }
            if (RtxMaterialMatcher.Instance != null)
            {
                RtxMaterialMatcher.Instance.RegisterAndMatchSingleAssetMaterial(targetMaterial);
            }
        }
    }
}
