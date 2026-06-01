Shader "Shader Graphs/SH_FakeUnlit_Texture" {
    Properties {
        [NoScaleOffset] _Texture ("Texture", 2D) = "white" {}
        _Saturation ("Saturation", Float) = 1
        _Smoothness ("Smoothness", Range(0, 1)) = 0
        _ShadowColor ("ShadowColor", Color) = (0,0,0,0)
        _Color ("Color", Color) = (1,1,1,1)
        _BaseColor ("BaseColor", Color) = (1,1,1,1)
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
    Fallback Off
}
