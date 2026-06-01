Shader "Shader Graphs/SH_FX_Particle_Dissolve_Additive"
{
    Properties
    {
        [NoScaleOffset] _Texture           ("Texture",           2D)     = "white" {}
        [NoScaleOffset] _Dissolve_Texture  ("Dissolve Texture",  2D)     = "white" {}
        _Dissolve_Tiling                   ("Dissolve Tiling",   Vector) = (1,1,0,0)
        _Dissolve_Speed                    ("Dissolve Speed",    Vector) = (0,0,0,0)
        _Dissolve_Smoothness               ("Dissolve Smoothness", Float) = 20
        _Color                             ("Color",             Color)  = (1,1,1,1)
    }

    SubShader
    {
        Tags
        {
            "Queue"          = "Transparent"
            "RenderType"     = "Transparent"
            "RenderPipeline" = "UniversalPipeline"
        }

        Cull Off
        ZWrite Off
        Blend SrcAlpha One

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
                float4 _Dissolve_Tiling;
                float4 _Dissolve_Speed;
                float  _Dissolve_Smoothness;
            CBUFFER_END

            TEXTURE2D(_Texture);          SAMPLER(sampler_Texture);
            TEXTURE2D(_Dissolve_Texture); SAMPLER(sampler_Dissolve_Texture);

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
                float4 c = SAMPLE_TEXTURE2D(_Texture, sampler_Texture, IN.uv) * IN.color;
                float colorEnabled = step(0.001, _Color.a);
                c.rgb *= lerp(float3(1,1,1), _Color.rgb, colorEnabled);
                float2 duv = IN.uv * max(_Dissolve_Tiling.xy, 0.0001) + _Time.y * _Dissolve_Speed.xy;
                float noise = SAMPLE_TEXTURE2D(_Dissolve_Texture, sampler_Dissolve_Texture, duv).r;
                c.a *= saturate(noise * max(_Dissolve_Smoothness, 0.001));
                clip(c.a - 0.001);
                return c;
            }
            ENDHLSL
        }
    }

    Fallback "Hidden/Universal Render Pipeline/FallbackError"
}
