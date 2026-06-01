Shader "Shader Graphs/SH_FakeUnlit_Texture"
{
    Properties
    {
        [NoScaleOffset] _Texture     ("Texture",     2D)          = "white" {}
        _Saturation                  ("Saturation",  Float)       = 1
        _Smoothness                  ("Smoothness",  Range(0, 1)) = 0
        _ShadowColor                 ("ShadowColor", Color)       = (0,0,0,0)
        _Color                       ("Color",       Color)       = (1,1,1,1)
        _BaseColor                   ("BaseColor",   Color)       = (1,1,1,1)
    }

    SubShader
    {
        Tags
        {
            "RenderType"    = "Opaque"
            "Queue"         = "Geometry"
            "RenderPipeline" = "UniversalPipeline"
        }

        Cull Back
        ZWrite On
        ZTest LEqual

        Pass
        {
            Name "Unlit"

            HLSLPROGRAM
            #pragma target 2.0
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            CBUFFER_START(UnityPerMaterial)
                float4 _Color;
                float4 _BaseColor;
                float4 _ShadowColor;
                float  _Saturation;
                float  _Smoothness;
            CBUFFER_END

            TEXTURE2D(_Texture);
            SAMPLER(sampler_Texture);

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv         : TEXCOORD0;
                float4 color      : COLOR;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float2 uv         : TEXCOORD0;
                float4 color      : COLOR;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                UNITY_SETUP_INSTANCE_ID(IN);
                UNITY_TRANSFER_INSTANCE_ID(IN, OUT);
                OUT.positionCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.uv         = IN.uv;
                OUT.color      = IN.color;
                return OUT;
            }

            float4 frag(Varyings IN) : SV_Target
            {
                UNITY_SETUP_INSTANCE_ID(IN);
                float4 c    = SAMPLE_TEXTURE2D(_Texture, sampler_Texture, IN.uv)
                              * _Color * _BaseColor * IN.color;
                float luma  = dot(c.rgb, float3(0.299, 0.587, 0.114));
                c.rgb       = lerp(luma.xxx, c.rgb, _Saturation);
                c.rgb       = lerp(c.rgb, c.rgb * _ShadowColor.rgb, _ShadowColor.a);
                c.a         = 1.0;
                return c;
            }
            ENDHLSL
        }

        Pass
        {
            Name "DepthOnly"
            Tags { "LightMode" = "DepthOnly" }
            ColorMask R
            ZWrite On

            HLSLPROGRAM
            #pragma target 2.0
            #pragma vertex DepthOnlyVertex
            #pragma fragment DepthOnlyFragment
            #pragma multi_compile_instancing
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/Shaders/UnlitInput.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/Shaders/DepthOnlyPass.hlsl"
            ENDHLSL
        }
    }

    Fallback "Hidden/Universal Render Pipeline/FallbackError"
}
