public class Fraction {

    public int Top { get; private set; }
    public int Bottom { get; private set; }

    public Fraction() {
        Top = 1;
        Bottom = 1;
    }

    public Fraction(int wholeNumber) {
        Top = wholeNumber;
        Bottom = wholeNumber;
    }

    public Fraction(int top, int bottom) {
        Top = top;
        Bottom = bottom;
    }

    public string GetFractionString() {
        return $"{Top}/{Bottom}";
    }

    public double GetDecimalValue() {
        return (double) Top / Bottom;
    }
}