using Microsoft.ML.OnnxRuntime.Tensors;

public class dataOnnx
{
    public float Id { get; set; }
    public float SquareNorthSouth { get; set; }
    public float Depth { get; set; }
    public float SouthToHead { get; set; }
    public float SquareEastWest { get; set; }
    public float WestToHead { get; set; }
    public float Length { get; set; }
    public float WestToFeet { get; set; }
    public float SouthToFeet { get; set; }
    public float EastWest_E { get; set; }
    public float EastWest_W { get; set; }
    public float AdultSubAdult_A { get; set; }
    public float AdultSubAdult_C { get; set; }
    public float AdultSubAdult_NLL { get; set; }
    public float Wrapping_B { get; set; }
    public float Wrapping_H { get; set; }
    public float Wrapping_S { get; set; }
    public float Wrapping_W { get; set; }
    public float SamplesCollected_U { get; set; }
    public float SamplesCollected_False { get; set; }
    public float SamplesCollected_True { get; set; }
    public float SamplesCollected_Unknown { get; set; }
    public float Area_NE { get; set; }
    public float Area_NNW { get; set; }
    public float Area_NW { get; set; }
    public float Area_SE { get; set; }
    public float Area_SW { get; set; }
    public float AgeAtDeath_A { get; set; }
    public float AgeAtDeath_C { get; set; }
    public float AgeAtDeath_T { get; set; }


    public Tensor<float> AsTensor()
    {
        float[] data = new float[]
        {
            Id, SquareNorthSouth, Depth, SouthToHead, SquareEastWest, WestToHead, Length, WestToFeet, SouthToFeet, EastWest_E, EastWest_W, AdultSubAdult_A, AdultSubAdult_C, AdultSubAdult_NLL,
            Wrapping_B, Wrapping_H, Wrapping_S, Wrapping_W, SamplesCollected_U, SamplesCollected_False, SamplesCollected_True, SamplesCollected_Unknown,
            Area_NE, Area_NNW, Area_NW, Area_SE, Area_SW, AgeAtDeath_A, AgeAtDeath_C, AgeAtDeath_T
        };
        int[] dimensions = new int[] { 1, 30 };
        return new DenseTensor<float>(data, dimensions);
    }
}
