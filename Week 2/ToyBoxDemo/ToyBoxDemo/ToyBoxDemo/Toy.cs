namespace ToyBoxDemo
{
    public class Toy
    {
        private readonly string _name;
        private readonly string _color;
        private readonly decimal _cost;

        public Toy(string newName, string newColor, decimal newCost)
        {
            _name = newName;
            _color = newColor;
            _cost = newCost;
        }

        // Expression-bodied members
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
        // Note: it is different from Lambda expressions
        // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions
        public string GetName() => _name;

        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-override-the-tostring-method
        // String interpolation using $
        // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
        public override string ToString() => $"a {_color} colored {_name} worth ${_cost}";
    }
}
