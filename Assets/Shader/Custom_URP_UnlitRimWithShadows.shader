Shader "Custom/URP/UnlitRimWithShadows"
{
    Properties
    {
        [Header(Base)]
        _BaseMap         ("Base Map",          2D)          = "white" {}
        _BaseColor       ("Base Color",        Color)       = (1,1,1,1)
        _Color           ("Color",             Color)       = (1,1,1,1)
        _RimColor        ("Rim Color",         Color)       = (0.2,0.8,1,1)
        _RimColorInner   ("Rim Color Inner",   Color)       = (0.2,0,0,1)
        _RimColorOuter   ("Rim Color Outer",   Color)       = (0.8,0.25,0.05,1)
        _RimPower        ("Rim Power",         Range(0.1,8))= 2.5
        _RimIntensity    ("Rim Intensity",     Range(0,4))  = 1
        _RimMin          ("Rim Min",           Range(0,1))  = 0
        _RimMax          ("Rim Max",           Range(0,1))  = 1
        _RimSmoothness   ("Rim Smoothness",    Range(0.001,1)) = 0.25
        _RimDirection    ("Rim Direction",     Vector)      = (0,1,0,0)
        _RimDirStrength  ("Rim Dir Strength",  Range(0,1))  = 0
        _RimMaskStrength ("Rim Mask Strength", Range(0,1))  = 1
        _Saturation      ("Saturation",        Float)       = 1
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
                float4 _BaseMap_ST;
                float4 _BaseColor;
                float4 _Color;
                float4 _RimColor;
                float4 _RimColorInner;
                float4 _RimColorOuter;
                float4 _RimDirection;
                float  _RimPower;
                float  _RimIntensity;
                float  _RimMin;
                float  _RimMax;
                float  _RimSmoothness;
                float  _RimDirStrength;
                float  _RimMaskStrength;
                float  _Saturation;
            CBUFFER_END

            TEXTURE2D(_BaseMap);
            SAMPLER(sampler_BaseMap);

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv         : TEXCOORD0;
                float3 normalOS   : NORMAL;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float2 uv         : TEXCOORD0;
                float3 normalWS   : TEXCOORD1;
                float3 viewDirWS  : TEXCOORD2;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                UNITY_SETUP_INSTANCE_ID(IN);
                UNITY_TRANSFER_INSTANCE_ID(IN, OUT);
                float3 posWS    = TransformObjectToWorld(IN.positionOS.xyz);
                OUT.positionCS  = TransformWorldToHClip(posWS);
                OUT.uv          = IN.uv * _BaseMap_ST.xy + _BaseMap_ST.zw;
                OUT.normalWS    = TransformObjectToWorldNormal(IN.normalOS);
                OUT.viewDirWS   = normalize(GetCameraPositionWS() - posWS);
                return OUT;
            }

            float4 frag(Varyings IN) : SV_Target
            {
                UNITY_SETUP_INSTANCE_ID(IN);
                float4 c        = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, IN.uv)
                                  * _BaseColor * _Color;
                float luma      = dot(c.rgb, float3(0.299, 0.587, 0.114));
                c.rgb           = lerp(luma.xxx, c.rgb, _Saturation);

                float3 N        = normalize(IN.normalWS);
                float3 V        = normalize(IN.viewDirWS);
                float  rim      = 1.0 - saturate(dot(N, V));
                rim             = pow(saturate(rim), max(_RimPower, 0.001));
                rim             = smoothstep(_RimMin, max(_RimMax, _RimMin + 0.001), rim);
                float3 rimCol   = lerp(_RimColorInner.rgb, _RimColorOuter.rgb, rim) * _RimColor.rgb;
                c.rgb          += rimCol * rim * _RimIntensity;
                c.a             = 1.0;
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
