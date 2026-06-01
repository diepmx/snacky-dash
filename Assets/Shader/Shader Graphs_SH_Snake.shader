Shader "Shader Graphs/SH_Snake" {
    Properties {
        [NoScaleOffset] _Texture ("Texture", 2D) = "white" {}
        _Saturation ("Saturation", Float) = 1
        _Smoothness ("Smoothness", Range(0, 1)) = 0
        _ShadowColor ("ShadowColor", Color) = (0,0,0,0)
        _FlashColor ("FlashColor", Color) = (1,1,1,0)
        _FlashStrength ("FlashStrength", Range(0, 1)) = 0
        _Alpha ("Alpha", Range(0, 1)) = 1
        _Color ("Color", Color) = (1,1,1,1)
        _BaseColor ("BaseColor", Color) = (1,1,1,1)
    }

    // === URP SubShader ===
    SubShader {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" "RenderPipeline"="UniversalPipeline" }
        Cull Back ZWrite On Blend SrcAlpha OneMinusSrcAlpha

        Pass {
            Name "UniversalForward"
            Tags { "LightMode"="UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                half4 color : COLOR;
            };

            struct v2f {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                half4 color : COLOR;
            };

            CBUFFER_START(UnityPerMaterial)
                half _Saturation;
                half _FlashStrength;
                half _Alpha;
                half _Smoothness;
                half4 _FlashColor;
                half4 _ShadowColor;
                half4 _Color;
                half4 _BaseColor;
            CBUFFER_END

            TEXTURE2D(_Texture);
            SAMPLER(sampler_Texture);

            v2f vert(appdata v) {
                v2f o;
                o.pos = TransformObjectToHClip(v.vertex.xyz);
                o.uv = v.uv;
                o.color = v.color;
                return o;
            }

            half4 frag(v2f i) : SV_Target {
                half4 c = SAMPLE_TEXTURE2D(_Texture, sampler_Texture, i.uv) * _Color * _BaseColor * i.color;
                half luma = dot(c.rgb, half3(0.299, 0.587, 0.114));
                c.rgb = lerp(luma.xxx, c.rgb, _Saturation);
                c.rgb = lerp(c.rgb, c.rgb * _ShadowColor.rgb, _ShadowColor.a);
                c.rgb = lerp(c.rgb, _FlashColor.rgb, saturate(_FlashStrength));
                c.a *= _Alpha;
                return c;
            }
            ENDHLSL
        }

        Pass {
            Name "SRPDefaultUnlit"
            Tags { "LightMode"="SRPDefaultUnlit" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct appdata { float4 vertex : POSITION; float2 uv : TEXCOORD0; half4 color : COLOR; };
            struct v2f { float4 pos : SV_POSITION; float2 uv : TEXCOORD0; half4 color : COLOR; };

            CBUFFER_START(UnityPerMaterial)
                half _Saturation; half _FlashStrength; half _Alpha; half _Smoothness;
                half4 _FlashColor; half4 _ShadowColor; half4 _Color; half4 _BaseColor;
            CBUFFER_END

            TEXTURE2D(_Texture); SAMPLER(sampler_Texture);

            v2f vert(appdata v) { v2f o; o.pos = TransformObjectToHClip(v.vertex.xyz); o.uv = v.uv; o.color = v.color; return o; }
            half4 frag(v2f i) : SV_Target {
                half4 c = SAMPLE_TEXTURE2D(_Texture, sampler_Texture, i.uv) * _Color * _BaseColor * i.color;
                half luma = dot(c.rgb, half3(0.299, 0.587, 0.114));
                c.rgb = lerp(luma.xxx, c.rgb, _Saturation);
                c.rgb = lerp(c.rgb, c.rgb * _ShadowColor.rgb, _ShadowColor.a);
                c.rgb = lerp(c.rgb, _FlashColor.rgb, saturate(_FlashStrength));
                c.a *= _Alpha;
                return c;
            }
            ENDHLSL
        }
    }

    // === Built-in fallback ===
    SubShader {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        Cull Back ZWrite On Blend SrcAlpha OneMinusSrcAlpha
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            struct appdata { float4 vertex : POSITION; float2 uv : TEXCOORD0; fixed4 color : COLOR; };
            struct v2f { float4 pos : SV_POSITION; float2 uv : TEXCOORD0; fixed4 color : COLOR; };
            sampler2D _Texture; half _Saturation; half _FlashStrength; half _Alpha;
            fixed4 _FlashColor; fixed4 _ShadowColor; fixed4 _Color; fixed4 _BaseColor;
            v2f vert(appdata v) { v2f o; o.pos = UnityObjectToClipPos(v.vertex); o.uv = v.uv; o.color = v.color; return o; }
            fixed4 frag(v2f i) : SV_Target {
                fixed4 c = tex2D(_Texture, i.uv) * _Color * _BaseColor * i.color;
                fixed luma = dot(c.rgb, fixed3(0.299, 0.587, 0.114));
                c.rgb = lerp(luma.xxx, c.rgb, _Saturation);
                c.rgb = lerp(c.rgb, c.rgb * _ShadowColor.rgb, _ShadowColor.a);
                c.rgb = lerp(c.rgb, _FlashColor.rgb, saturate(_FlashStrength));
                c.a *= _Alpha;
                return c;
            }
            ENDCG
        }
    }
    Fallback "Universal Render Pipeline/Unlit"
}
