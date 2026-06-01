Shader "Shader Graphs/SH_FakeUnlit_Color" {
    Properties {
        _Color ("Color", Color) = (0,0.8915043,1,1)
        _Smoothness ("Smoothness", Range(0, 1)) = 0
        _ShadowColor ("ShadowColor", Color) = (0,0,0,0)
    }
    SubShader {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" }
        Cull Back ZWrite On
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata { float4 vertex : POSITION; fixed4 color : COLOR; };
            struct v2f { float4 pos : SV_POSITION; fixed4 color : COLOR; };

            fixed4 _Color;
            fixed4 _ShadowColor;

            v2f vert(appdata v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.color = v.color;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target {
                fixed4 c = _Color * i.color;
                c.rgb = lerp(c.rgb, c.rgb * _ShadowColor.rgb, _ShadowColor.a);
                return c;
            }
            ENDCG
        }
    }
    Fallback Off
}
