Shader "WetSpecular"
{
	Properties 
	{
_DiffuseIntensity("_DiffuseIntensity", Range(0,1) ) = 0.5
_DiffuseColor("_DiffuseColor", Color) = (1,1,1,1)
_WetIntensity("_WetIntensity", Range(0,1) ) = 0.5
_SpecularIntensity("_SpecularIntensity", Range(0,1) ) = 0.5
_SpecularColor("_SpecularColor", Color) = (1,1,1,1)
_SpecularPower("_SpecularPower", Range(0,1) ) = 0.5
_DiffuseTexture("_DiffuseTexture", 2D) = "black" {}
_WetMap("_WetMap", 2D) = "black" {}

	}
	
	SubShader 
	{
		Tags
		{
"Queue"="Geometry"
"IgnoreProjector"="False"
"RenderType"="Opaque"

		}

		
Cull Back
ZWrite On
ZTest LEqual
ColorMask RGBA
Fog{
}


		CGPROGRAM
#pragma surface surf BlinnPhongEditor  vertex:vert
#pragma target 2.0


float _DiffuseIntensity;
float4 _DiffuseColor;
float _WetIntensity;
float _SpecularIntensity;
float4 _SpecularColor;
float _SpecularPower;
sampler2D _DiffuseTexture;
sampler2D _WetMap;

			struct EditorSurfaceOutput {
				half3 Albedo;
				half3 Normal;
				half3 Emission;
				half3 Gloss;
				half Specular;
				half Alpha;
				half4 Custom;
			};
			
			inline half4 LightingBlinnPhongEditor_PrePass (EditorSurfaceOutput s, half4 light)
			{
half3 spec = light.a * s.Gloss;
half4 c;
c.rgb = (s.Albedo * light.rgb + light.rgb * spec);
c.a = s.Alpha;
return c;

			}

			inline half4 LightingBlinnPhongEditor (EditorSurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
			{
				half3 h = normalize (lightDir + viewDir);
				
				half diff = max (0, dot ( lightDir, s.Normal ));
				
				float nh = max (0, dot (s.Normal, h));
				float spec = pow (nh, s.Specular*128.0);
				
				half4 res;
				res.rgb = _LightColor0.rgb * diff;
				res.w = spec * Luminance (_LightColor0.rgb);
				res *= atten * 2.0;

				return LightingBlinnPhongEditor_PrePass( s, res );
			}
			
			struct Input {
				float2 uv_DiffuseTexture;
float2 uv_WetMap;

			};

			void vert (inout appdata_full v, out Input o) {
float4 VertexOutputMaster0_0_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_1_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_2_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_3_NoInput = float4(0,0,0,0);


			}
			

			void surf (Input IN, inout EditorSurfaceOutput o) {
				o.Normal = float3(0.0,0.0,1.0);
				o.Alpha = 1.0;
				o.Albedo = 0.0;
				o.Emission = 0.0;
				o.Gloss = 0.0;
				o.Specular = 0.0;
				o.Custom = 0.0;
				
float4 Tex2D1=tex2D(_DiffuseTexture,(IN.uv_DiffuseTexture.xyxy).xy);
float4 Tex2D0=tex2D(_WetMap,(IN.uv_WetMap.xyxy).xy);
float4 Multiply3=Tex2D0 * _WetIntensity.xxxx;
float4 Subtract0=Tex2D1 - Multiply3;
float4 Multiply1=Subtract0 * _DiffuseColor;
float4 Multiply2=_DiffuseIntensity.xxxx * Multiply1;
float4 Tex2D2=tex2D(_WetMap,(IN.uv_WetMap.xyxy).xy);
float4 Multiply4=_SpecularIntensity.xxxx * Tex2D2;
float4 Multiply0=_SpecularColor * Multiply4;
float4 Master0_1_NoInput = float4(0,0,1,1);
float4 Master0_2_NoInput = float4(0,0,0,0);
float4 Master0_5_NoInput = float4(1,1,1,1);
float4 Master0_7_NoInput = float4(0,0,0,0);
float4 Master0_6_NoInput = float4(1,1,1,1);
o.Albedo = Multiply2;
o.Specular = _SpecularPower.xxxx;
o.Gloss = Multiply0;

				o.Normal = normalize(o.Normal);
			}
		ENDCG
	}
	Fallback ""
}