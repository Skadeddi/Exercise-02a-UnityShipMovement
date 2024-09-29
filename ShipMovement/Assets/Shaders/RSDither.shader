Shader "CustomEffects/RSDither"
{
    HLSLINCLUDE
    
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
        // The Blit.hlsl file provides the vertex shader (Vert),
        // the input structure (Attributes), and the output structure (Varyings)
        #include "Packages/com.unity.render-pipelines.core/Runtime/Utilities/Blit.hlsl"

        static float map[64] = {0, 32, 8, 40, 2, 34, 10, 42,
                      48, 16, 56, 24, 50, 18, 58, 26,
                      12, 44, 4, 36, 14, 46, 6, 38,
                      60, 28, 52, 20, 62, 30, 54, 22,
                      3, 35, 11, 43, 1, 33, 9, 41,
                      51, 19, 59, 27, 49, 17, 57, 25,
                      15, 47, 7, 39, 13, 45, 5, 37,
                      63, 31, 55, 23, 61, 29, 53, 21};
        float2 ditherOffset;
        float4 setColor;

        float hash12(float2 p)
        {
	        float3 p3  = frac(float3(p.xyx) * .1031);
            p3 += dot(p3, p3.yzx + 33.33);
            return frac((p3.x + p3.y) * p3.z);
        }

        float order(float2 coords)
        {
            ditherOffset = float2(_ScreenParams.xy);
            return map[fmod(coords.x * 640.0f, 8.0f) + (fmod(coords.y * 360, 8.0f) * 8.0f)] / 63.0f;
        }

        float4 Quantize (Varyings input) : SV_Target
        {
            float3 color = SAMPLE_TEXTURE2D(_BlitTexture, sampler_LinearClamp, input.texcoord).rgb;
            setColor = float4(1, 0, 0, 1);
            if((color.r + color.g + color.b) / 3.0f > 0.8f)
            {
                setColor = float4(1, 1, 1, 1);
            }
            else if(color.g > color.r * 0.66f)
            {
                setColor = float4(1, 1, 0.1f, 1);
            }
            color = (color.r * 0.299f + color.g * 0.587f + color.b * 0.114f);
            if(color.r > order(float2(input.texcoord.x, input.texcoord.y)))
            {
                color = setColor;
            }
            else
            {
                color = 0;
            }
            return float4(color.rgb, 1);
        }

        float4 Dither (Varyings input) : SV_Target
        {
            float3 color = SAMPLE_TEXTURE2D(_BlitTexture, sampler_LinearClamp, input.texcoord).rgb;
            return float4(color.rgb, 1);
        }
    
    ENDHLSL
    
    SubShader
    {
        Tags { "RenderType"="Opaque" "RenderPipeline" = "UniversalPipeline"}
        LOD 100
        ZTest Always ZWrite Off Cull Off
        Pass
        {
            Name "Quantize"

            HLSLPROGRAM
            
            #pragma vertex Vert
            #pragma fragment Quantize
            
            ENDHLSL
        }
        
        Pass
        {
            Name "Dither"

            HLSLPROGRAM
            
            #pragma vertex Vert
            #pragma fragment Dither
            
            ENDHLSL
        }
    }
}