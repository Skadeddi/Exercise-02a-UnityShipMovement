using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class RSRenderFeature : ScriptableRendererFeature
{
    [SerializeField] private Shader shader;
    private Material material;
    private RSRenderPass RSPass;

    public override void Create()
    {
        if(shader == null)
        {
            return;
        }
        material = CoreUtils.CreateEngineMaterial(shader);
        RSPass = new RSRenderPass(material);

        RSPass.renderPassEvent = RenderPassEvent.AfterRenderingPostProcessing;
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        if (renderingData.cameraData.cameraType == CameraType.Game)
        {
            renderer.EnqueuePass(RSPass);
        }
    }

}
