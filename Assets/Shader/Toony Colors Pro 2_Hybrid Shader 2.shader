Shader "Toony Colors Pro 2/Hybrid Shader 2" {
    Properties {
        [Enum(Front, 2, Back, 1, Both, 0)] _Cull ("Render Face", Float) = 2
        _Cutoff ("Alpha Cutoff", Range(0, 1)) = 0.5
        _BaseColor ("Color", Color) = (1,1,1,1)
        _Color ("Color Alias", Color) = (1,1,1,1)
        _BaseMap ("Albedo", 2D) = "white" {}
        _HColor ("Highlight Color", Color) = (1,1,1,1)
        _SColor ("Shadow Color", Color) = (0.2,0.2,0.2,1)
        _ShadowColorLightAtten ("Main Light affects Shadow Color", Float) = 1
        _RampThreshold ("Threshold", Range(0.01, 1)) = 0.75
        _RampSmoothing ("Smoothing", Range(0, 1)) = 0.1
        _EmissionMap ("Emission Map", 2D) = "white" {}
        _EmissionColor ("Emission Color", Color) = (0,0,0,1)
        _UseRim ("Rim Lighting", Float) = 0
        _RimColor ("Rim Color", Color) = (0.8,0.8,0.8,0.5)
        _RimMin ("Rim Min", Range(0, 2)) = 0.5
        _RimMax ("Rim Max", Range(0, 2)) = 1
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _OutlineWidth ("Outline Width", Range(0, 10)) = 1
    }
    SubShader {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" }
        Cull [_Cull] ZWrite On
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

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

            sampler2D _BaseMap;
            float4 _BaseMap_ST;
            fixed4 _BaseColor;
            fixed4 _Color;
            fixed4 _HColor;
            fixed4 _SColor;
            fixed4 _EmissionColor;
            fixed4 _RimColor;
            half _RampThreshold;
            half _RampSmoothing;
            half _UseRim;
            half _RimMin;
            half _RimMax;

            v2f vert(appdata v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _BaseMap);
                float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                o.viewDir = normalize(_WorldSpaceCameraPos - worldPos);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target {
                fixed4 c = tex2D(_BaseMap, i.uv) * _BaseColor * _Color;
                half ndl = saturate(dot(normalize(i.worldNormal), normalize(_WorldSpaceLightPos0.xyz)));
                half band = smoothstep(_RampThreshold - _RampSmoothing, _RampThreshold + _RampSmoothing, ndl);
                c.rgb *= lerp(_SColor.rgb, _HColor.rgb, band);
                half rim = 1.0 - saturate(dot(normalize(i.worldNormal), normalize(i.viewDir)));
                rim = smoothstep(_RimMin, max(_RimMax, _RimMin + 0.001), rim);
                c.rgb += _RimColor.rgb * rim * _RimColor.a * step(0.5, _UseRim);
                c.rgb += _EmissionColor.rgb * _EmissionColor.a;
                return c;
            }
            ENDCG
        }
    }
    Fallback Off
}
