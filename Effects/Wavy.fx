sampler uImage0 : register(s0);
sampler uImage1 : register(s1);
float3 uColor;
float3 uSecondaryColor;
float uOpacity;
float uSaturation;
float uRotation;
float uTime;
float4 uSourceRect;
float2 uWorldPosition;
float2 uTargetPosition;
float uDirection;
float3 uLightSource;
float2 uImageSize0;
float2 uImageSize1;
float4 uLegacyArmorSourceRect;
float2 uLegacyArmorSheetSize;

float4 Wavy(float4 sampleColor : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
    float waveIntensity = 0.001f;
    float halvedX;
    float halvedY;

    if (coords.x == 0)
        halvedX = 0;
    else
        halvedX = coords.x / 2;

    if (coords.y == 0)
        halvedY = 0;
    else
        halvedY = coords.y / 2;

    coords.x -= waveIntensity * sin(uTime + halvedY * 50 + halvedX / 75);
    coords.y -= waveIntensity * sin(uTime + halvedY * 50 + halvedX * 75);
    float4 color = tex2D(uImage0, coords);
    return color * sampleColor;
}

technique Technique1
{
    pass WavyPass
    {
        PixelShader = compile ps_2_0 Wavy();
    }
}