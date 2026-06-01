Shader "JuicedUp/DarkOverlayStencilWriter"
{
    Properties
    {
        [PerRendererData] _MainTex  ("Sprite Texture",   2D)          = "white" {}
        _Cutoff                     ("Alpha Cutoff",     Range(0,1))  = 0.1
        _StencilRef                 ("Stencil Ref",      Range(0,255)) = 1
        _StencilWriteMask           ("Stencil Write Mask", Range(0,255)) = 255
    }

    SubShader
    {
        Tags
        {
            "Queue"          = "Transparent"
            "IgnoreProjector" = "True"
            "RenderType"     = "Transparent"
            "PreviewType"    = "Plane"
            "RenderPipeline" = "UniversalPipeline"
        }

        Stencil
        {
            Ref       [_StencilRef]
            Comp      Always
            Pass      Replace
            WriteMask [_StencilWriteMask]
        }

        Cull Off
        ZWrite Off
        ColorMask 0

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
                float4 _MainTex_ST;
                float  _Cutoff;
            CBUFFER_END

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv         : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float2 uv         : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                UNITY_SETUP_INSTANCE_ID(IN);
                UNITY_TRANSFER_INSTANCE_ID(IN, OUT);
                OUT.positionCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.uv         = IN.uv * _MainTex_ST.xy + _MainTex_ST.zw;
                return OUT;
            }

            float4 frag(Varyings IN) : SV_Target
            {
                UNITY_SETUP_INSTANCE_ID(IN);
                float a = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv).a;
                clip(a - _Cutoff);
                return float4(0,0,0,0);
            }
            ENDHLSL
        }
    }
}
