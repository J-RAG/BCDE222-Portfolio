// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/

namespace IndexerDemo
{
    // Generic Class
    class SampleCollection<T>
    {
        private const int MaxSize = 100;

        // Declare an array to store the data elements.
        private T[] _arr = new T[MaxSize];

        /*
        The this keyword is used to define the indexer.
        The value keyword is used to define the value being assigned by the set accessor.
        // Define the indexer to allow client code to use [] notation.
        public T this[int i]
        {
            get { return _arr[i]; }
            set
            {
                _arr[i] = value;
                ++_nextIndex;
            }
        }
        */

        private int _nextIndex = 0;

        // Starting with C# 6, a read-only indexer can be implemented as an expression-bodied member
        public T this[int i] => _arr[i];
        public void Add(T value)
        {
            if (_nextIndex + 1 >= _arr.Length)
                throw new System.IndexOutOfRangeException($"The collection can hold only {_arr.Length} elements.");
            _arr[++_nextIndex] = value;
        }

        // Starting with C# 7.0, both the get and set accessor can be an implemented as expression-bodied members.
        // In this case, both get and set keywords must be used. 
        public T this[int i]
        {
            get => _arr[i];
            set => _arr[i] = value;
        }
    }
}
