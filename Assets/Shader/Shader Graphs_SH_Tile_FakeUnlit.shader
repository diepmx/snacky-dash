Shader "Shader Graphs/SH_Tile_FakeUnlit"
{
    Properties
    {
        _Main_Color_1    ("Main_Color_1",    Color)          = (1,0,0,1)
        _Main_Color_2    ("Main_Color_2",    Color)          = (0,0.4149446,1,1)
        _Main_Color_3    ("Main_Color_3",    Color)          = (1,1,1,0)
        _Side_Color      ("Side_Color",      Color)          = (0.8261385,0,1,1)
        _Side_Height_Top ("Side_Height_Top", Float)          = 0
        _Side_Height_Bottom ("Side_Height_Bottom", Float)    = 1.4
        _Normal_Blend    ("Normal_Blend",    Range(0,1))     = 0.5
        _Shadow_Color    ("Shadow_Color",    Color)          = (0,0,0,0)
        _Shadow_Edge_1   ("Shadow_Edge_1",   Float)          = 0.2
        _Shadow_Edge_2   ("Shadow_Edge_2",   Float)          = 1
        _Shadow_Steps    ("Shadow_Steps",    Float)          = 3
        _Shadow_Strength ("Shadow_Strength", Float)          = 1
        [NoScaleOffset] _Overlay_Texture ("Overlay_Texture", 2D) = "white" {}
        _Overlay_Tiling  ("Overlay_Tiling",  Float)          = 1
        _Overlay_Rotation ("Overlay_Rotation", Range(0,360)) = 0
        _Overlay_Strength ("Overlay_Strength", Float)        = 0
        _Overlay_Color   ("Overlay_Color",   Color)          = (1,1,1,0)
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
                float4 _Main_Color_1;
                float4 _Main_Color_2;
                float4 _Main_Color_3;
                float4 _Side_Color;
                float4 _Shadow_Color;
                float4 _Overlay_Color;
                float  _Overlay_Tiling;
                float  _Overlay_Strength;
                float  _Shadow_Strength;
                float  _Side_Height_Top;
                float  _Side_Height_Bottom;
                float  _Normal_Blend;
                float  _Shadow_Edge_1;
                float  _Shadow_Edge_2;
                float  _Shadow_Steps;
                float  _Overlay_Rotation;
            CBUFFER_END

            TEXTURE2D(_Overlay_Texture);
            SAMPLER(sampler_Overlay_Texture);

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
                float3 positionWS : TEXCOORD1;
                float3 normalWS   : TEXCOORD2;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                UNITY_SETUP_INSTANCE_ID(IN);
                UNITY_TRANSFER_INSTANCE_ID(IN, OUT);
                OUT.positionCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.uv         = IN.uv;
                OUT.positionWS = TransformObjectToWorld(IN.positionOS.xyz);
                OUT.normalWS   = TransformObjectToWorldNormal(IN.normalOS);
                return OUT;
            }

            float4 frag(Varyings IN) : SV_Target
            {
                UNITY_SETUP_INSTANCE_ID(IN);
                float topMask  = saturate(IN.uv.y);
                float4 base    = lerp(_Main_Color_1, _Main_Color_2, topMask);
                base           = lerp(base, _Main_Color_3, _Main_Color_3.a);
                
                float sideMaskPos = saturate((IN.positionWS.y - _Side_Height_Top) / max(_Side_Height_Bottom - _Side_Height_Top, 0.001));
                float sideMaskNorm = saturate(IN.normalWS.y);
                float sideMask = lerp(sideMaskPos, sideMaskNorm, _Normal_Blend);
                
                float4 c       = lerp(_Side_Color, base, sideMask);
                float4 overlay = SAMPLE_TEXTURE2D(_Overlay_Texture, sampler_Overlay_Texture,
                                   IN.uv * max(_Overlay_Tiling, 0.001)) * _Overlay_Color;
                c.rgb          = lerp(c.rgb, overlay.rgb, saturate(_Overlay_Strength) * overlay.a);
                float shade    = saturate(1.0 - abs(IN.normalWS.y));
                c.rgb          = lerp(c.rgb, c.rgb * _Shadow_Color.rgb,
                                   saturate(_Shadow_Strength) * shade * _Shadow_Color.a);
                c.a            = 1.0;
                return float4(c.rgb, 1.0);
            }
            ENDHLSL
        }

        Pass
        {
            Name "DepthOnly"
            Tags { "LightMode" = "DepthOnly" }
            ColorMask R
            ZWrite On
            ZTest LEqual
            Cull Back

            HLSLPROGRAM
            #pragma target 2.0
            #pragma vertex DepthVert
            #pragma fragment DepthFrag
            #pragma multi_compile_instancing
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            struct DepthAttribs  { float4 positionOS : POSITION; UNITY_VERTEX_INPUT_INSTANCE_ID };
            struct DepthVaryings { float4 positionCS : SV_POSITION; UNITY_VERTEX_INPUT_INSTANCE_ID };
            DepthVaryings DepthVert(DepthAttribs IN) {
                DepthVaryings OUT;
                UNITY_SETUP_INSTANCE_ID(IN); UNITY_TRANSFER_INSTANCE_ID(IN, OUT);
                OUT.positionCS = TransformObjectToHClip(IN.positionOS.xyz);
                return OUT;
            }
            float DepthFrag(DepthVaryings IN) : SV_Target { return 0; }
            ENDHLSL
        }
    }

    Fallback "Hidden/Universal Render Pipeline/FallbackError"
}
