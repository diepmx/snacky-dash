Shader "Shader Graphs/SH_FakeUnlit_Texture" {
    Properties {
        [NoScaleOffset] _Texture ("Texture", 2D) = "white" {}
        _Saturation ("Saturation", Float) = 1
        _Smoothness ("Smoothness", Range(0, 1)) = 0
        _ShadowColor ("ShadowColor", Color) = (0,0,0,0)
        _Color ("Color", Color) = (1,1,1,1)
        _BaseColor ("BaseColor", Color) = (1,1,1,1)
    }

    // === URP-Compatible SubShader ===
    SubShader {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" "RenderPipeline"="UniversalPipeline" }
        Cull Back ZWrite On

        Pass {
            Name "UniversalForward"
            Tags { "LightMode"="UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog

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
                half4 _Color;
                half4 _BaseColor;
                half4 _ShadowColor;
                half _Saturation;
                half _Smoothness;
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
                return c;
            }
            ENDHLSL
        }

        // SRPDefaultUnlit pass
        Pass {
            Name "SRPDefaultUnlit"
            Tags { "LightMode"="SRPDefaultUnlit" }

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
                half4 _Color;
                half4 _BaseColor;
                half4 _ShadowColor;
                half _Saturation;
                half _Smoothness;
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
                return c;
            }
            ENDHLSL
        }

        // DepthOnly
        Pass {
            Name "DepthOnly"
            Tags { "LightMode"="DepthOnly" }
            ColorMask 0
            ZWrite On

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct appdata { float4 vertex : POSITION; };
            struct v2f { float4 pos : SV_POSITION; };

            v2f vert(appdata v) {
                v2f o;
                o.pos = TransformObjectToHClip(v.vertex.xyz);
                return o;
            }
            half4 frag(v2f i) : SV_Target { return 0; }
            ENDHLSL
        }
    }

    // === Built-in fallback ===
    SubShader {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" }
        Cull Back ZWrite On
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                fixed4 color : COLOR;
            };

            struct v2f {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                fixed4 color : COLOR;
            };

            sampler2D _Texture;
            fixed4 _Color;
            fixed4 _BaseColor;
            fixed4 _ShadowColor;
            half _Saturation;

            v2f vert(appdata v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.color = v.color;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target {
                fixed4 c = tex2D(_Texture, i.uv) * _Color * _BaseColor * i.color;
                fixed luma = dot(c.rgb, fixed3(0.299, 0.587, 0.114));
                c.rgb = lerp(luma.xxx, c.rgb, _Saturation);
                c.rgb = lerp(c.rgb, c.rgb * _ShadowColor.rgb, _ShadowColor.a);
                return c;
            }
            ENDCG
        }
    }
    Fallback "Universal Render Pipeline/Unlit"
}
