namespace CSharpFeatures.CSharp10
{
    public readonly struct Measurement
    {
        // A parameterless ctor of struct
        public Measurement()
        {
            Value = double.NaN;
        }

        // property initialization in a struct ctor
        public Measurement(double value)
        {
            Value = value;
        }

        // should be read-only (init)
        public double Value { get; init; }
    }

    public class UseCase
    {
        public void UseCaseMethod()
        {
            Measurement measurement = new(10.5);

            // with statement can be used regarding structure
            Measurement measurementOther = measurement with { Value = 12 };
        }
    }
}
