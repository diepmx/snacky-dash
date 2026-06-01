Shader "Custom/URP/UnlitRimWithShadows" {
    Properties {
        [Header(Base)] _BaseMap ("Base Map", 2D) = "white" {}
        _BaseColor ("Base Color", Color) = (1,1,1,1)
        _Color ("Color", Color) = (1,1,1,1)
        _RimColor ("Rim Color", Color) = (0.2,0.8,1,1)
        _RimColorInner ("Rim Color Inner", Color) = (0.2,0,0,1)
        _RimColorOuter ("Rim Color Outer", Color) = (0.8,0.25,0.05,1)
        _RimPower ("Rim Power", Range(0.1, 8)) = 2.5
        _RimIntensity ("Rim Intensity", Range(0, 4)) = 1
        _RimMin ("Rim Min", Range(0, 1)) = 0
        _RimMax ("Rim Max", Range(0, 1)) = 1
        _RimSmoothness ("Rim Smoothness", Range(0.001, 1)) = 0.25
        _RimDirection ("Rim Direction", Vector) = (0,1,0,0)
        _RimDirStrength ("Rim Direction Strength", Range(0, 1)) = 0
        _RimMaskStrength ("Rim Mask Strength", Range(0, 1)) = 1
        _Saturation ("Saturation", Float) = 1
    }

    // === URP SubShader ===
    SubShader {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" "RenderPipeline"="UniversalPipeline" }
        Cull Back ZWrite On

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
                float3 normal : NORMAL;
            };

            struct v2f {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 worldNormal : TEXCOORD1;
                float3 viewDir : TEXCOORD2;
            };

            CBUFFER_START(UnityPerMaterial)
                float4 _BaseMap_ST;
                half4 _BaseColor;
                half4 _Color;
                half4 _RimColor;
                half4 _RimColorInner;
                half4 _RimColorOuter;
                half _RimPower;
                half _RimIntensity;
                half _RimMin;
                half _RimMax;
                half _RimSmoothness;
                half _Saturation;
            CBUFFER_END

            TEXTURE2D(_BaseMap);
            SAMPLER(sampler_BaseMap);

            v2f vert(appdata v) {
                v2f o;
                o.pos = TransformObjectToHClip(v.vertex.xyz);
                o.uv = v.uv * _BaseMap_ST.xy + _BaseMap_ST.zw;
                float3 worldPos = TransformObjectToWorld(v.vertex.xyz);
                o.worldNormal = TransformObjectToWorldNormal(v.normal);
                o.viewDir = normalize(GetCameraPositionWS() - worldPos);
                return o;
            }

            half4 frag(v2f i) : SV_Target {
                half4 c = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, i.uv) * _BaseColor * _Color;
                half luma = dot(c.rgb, half3(0.299, 0.587, 0.114));
                c.rgb = lerp(luma.xxx, c.rgb, _Saturation);
                half rim = 1.0 - saturate(dot(normalize(i.worldNormal), normalize(i.viewDir)));
                rim = pow(saturate(rim), max(_RimPower, 0.001));
                rim = smoothstep(_RimMin, max(_RimMax, _RimMin + 0.001), rim);
                half3 rimColor = lerp(_RimColorInner.rgb, _RimColorOuter.rgb, rim) * _RimColor.rgb;
                c.rgb += rimColor * rim * _RimIntensity;
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

            struct appdata { float4 vertex : POSITION; float2 uv : TEXCOORD0; float3 normal : NORMAL; };
            struct v2f { float4 pos : SV_POSITION; float2 uv : TEXCOORD0; float3 worldNormal : TEXCOORD1; float3 viewDir : TEXCOORD2; };

            CBUFFER_START(UnityPerMaterial)
                float4 _BaseMap_ST; half4 _BaseColor; half4 _Color;
                half4 _RimColor; half4 _RimColorInner; half4 _RimColorOuter;
                half _RimPower; half _RimIntensity; half _RimMin; half _RimMax; half _RimSmoothness; half _Saturation;
            CBUFFER_END
            TEXTURE2D(_BaseMap); SAMPLER(sampler_BaseMap);

            v2f vert(appdata v) {
                v2f o; o.pos = TransformObjectToHClip(v.vertex.xyz);
                o.uv = v.uv * _BaseMap_ST.xy + _BaseMap_ST.zw;
                float3 wp = TransformObjectToWorld(v.vertex.xyz);
                o.worldNormal = TransformObjectToWorldNormal(v.normal);
                o.viewDir = normalize(GetCameraPositionWS() - wp); return o;
            }
            half4 frag(v2f i) : SV_Target {
                half4 c = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, i.uv) * _BaseColor * _Color;
                half luma = dot(c.rgb, half3(0.299, 0.587, 0.114));
                c.rgb = lerp(luma.xxx, c.rgb, _Saturation);
                half rim = 1.0 - saturate(dot(normalize(i.worldNormal), normalize(i.viewDir)));
                rim = pow(saturate(rim), max(_RimPower, 0.001));
                rim = smoothstep(_RimMin, max(_RimMax, _RimMin + 0.001), rim);
                half3 rimColor = lerp(_RimColorInner.rgb, _RimColorOuter.rgb, rim) * _RimColor.rgb;
                c.rgb += rimColor * rim * _RimIntensity; return c;
            }
            ENDHLSL
        }

        Pass {
            Name "DepthOnly"
            Tags { "LightMode"="DepthOnly" }
            ColorMask 0 ZWrite On
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            struct appdata { float4 vertex : POSITION; };
            struct v2f { float4 pos : SV_POSITION; };
            v2f vert(appdata v) { v2f o; o.pos = TransformObjectToHClip(v.vertex.xyz); return o; }
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
            struct appdata { float4 vertex : POSITION; float2 uv : TEXCOORD0; float3 normal : NORMAL; };
            struct v2f { float4 pos : SV_POSITION; float2 uv : TEXCOORD0; float3 worldNormal : TEXCOORD1; float3 viewDir : TEXCOORD2; };
            sampler2D _BaseMap; float4 _BaseMap_ST; fixed4 _BaseColor; fixed4 _Color;
            fixed4 _RimColor; fixed4 _RimColorInner; fixed4 _RimColorOuter;
            half _RimPower; half _RimIntensity; half _RimMin; half _RimMax; half _Saturation;
            v2f vert(appdata v) {
                v2f o; o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _BaseMap);
                float3 wp = mul(unity_ObjectToWorld, v.vertex).xyz;
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                o.viewDir = normalize(_WorldSpaceCameraPos - wp); return o;
            }
            fixed4 frag(v2f i) : SV_Target {
                fixed4 c = tex2D(_BaseMap, i.uv) * _BaseColor * _Color;
                fixed luma = dot(c.rgb, fixed3(0.299, 0.587, 0.114));
                c.rgb = lerp(luma.xxx, c.rgb, _Saturation);
                half rim = 1.0 - saturate(dot(normalize(i.worldNormal), normalize(i.viewDir)));
                rim = pow(saturate(rim), max(_RimPower, 0.001));
                rim = smoothstep(_RimMin, max(_RimMax, _RimMin + 0.001), rim);
                fixed3 rimColor = lerp(_RimColorInner.rgb, _RimColorOuter.rgb, rim) * _RimColor.rgb;
                c.rgb += rimColor * rim * _RimIntensity; return c;
            }
            ENDCG
        }
    }
    Fallback "Universal Render Pipeline/Unlit"
}
