Shader "Shader Graphs/SH_Tile_FakeUnlit" {
    Properties {
        _Main_Color_1 ("Main_Color_1", Color) = (1,0,0,1)
        _Main_Color_2 ("Main_Color_2", Color) = (0,0.4149446,1,1)
        _Main_Color_3 ("Main_Color_3", Color) = (1,1,1,0)
        _Side_Color ("Side_Color", Color) = (0.8261385,0,1,1)
        _Side_Height_Top ("Side_Height_Top", Float) = 0
        _Side_Height_Bottom ("Side_Height_Bottom", Float) = 1.4
        _Shadow_Color ("Shadow_Color", Color) = (0,0,0,0)
        _Shadow_Edge_1 ("Shadow_Edge_1", Float) = 0.2
        _Shadow_Edge_2 ("Shadow_Edge_2", Float) = 1
        _Shadow_Steps ("Shadow_Steps", Float) = 3
        _Shadow_Strength ("Shadow_Strength", Float) = 1
        [NoScaleOffset] _Overlay_Texture ("Overlay_Texture", 2D) = "white" {}
        _Overlay_Tiling ("Overlay_Tiling", Float) = 1
        _Overlay_Rotation ("Overlay_Rotation", Range(0, 360)) = 0
        _Overlay_Strength ("Overlay_Strength", Float) = 0
        _Overlay_Color ("Overlay_Color", Color) = (1,1,1,0)
    }
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
                float3 normal : NORMAL;
            };

            struct v2f {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
                float3 worldNormal : TEXCOORD2;
            };

            fixed4 _Main_Color_1;
            fixed4 _Main_Color_2;
            fixed4 _Main_Color_3;
            fixed4 _Side_Color;
            fixed4 _Shadow_Color;
            sampler2D _Overlay_Texture;
            half _Overlay_Tiling;
            half _Overlay_Strength;
            fixed4 _Overlay_Color;
            half _Shadow_Strength;
            half _Side_Height_Top;
            half _Side_Height_Bottom;

            v2f vert(appdata v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target {
                half topMask = saturate(i.uv.y);
                fixed4 baseColor = lerp(_Main_Color_1, _Main_Color_2, topMask);
                baseColor = lerp(baseColor, _Main_Color_3, _Main_Color_3.a);
                half sideMask = saturate((i.worldPos.y - _Side_Height_Top) / max(_Side_Height_Bottom - _Side_Height_Top, 0.001));
                fixed4 c = lerp(_Side_Color, baseColor, sideMask);
                fixed4 overlay = tex2D(_Overlay_Texture, i.uv * max(_Overlay_Tiling, 0.001)) * _Overlay_Color;
                c.rgb = lerp(c.rgb, overlay.rgb, saturate(_Overlay_Strength) * overlay.a);
                half shade = saturate(1.0 - abs(i.worldNormal.y));
                c.rgb = lerp(c.rgb, c.rgb * _Shadow_Color.rgb, saturate(_Shadow_Strength) * shade * _Shadow_Color.a);
                c.a = 1;
                return c;
            }
            ENDCG
        }
    }
    Fallback Off
}
