using System.Collections.Generic;

namespace ToyBoxDemo
{
    public class Box
    {
        // private List<Toy> _allMyToys = new List<Toy>();
        private readonly List<Toy> _allMyToys = new();
        private int _toyCount = 0;

        public void AddToy(string newName, string newColor, decimal newCost)
        {
            var aNewToy = new Toy(newName, newColor, newCost);
            _allMyToys.Add(aNewToy);
            _toyCount++;
        }

        public int GetToyCount() => _toyCount;

        public void SortByName()
        {
            _allMyToys.Sort((x, y) => x.GetName().CompareTo(y.GetName()));
        }

        public override string ToString()
        {
            var result = $"A box containing {_toyCount} toys";
            foreach (Toy aToy in _allMyToys)
            {
                result += "\n" + aToy;
            }
            return result;
        }
    }
}