using System;

namespace SteviesModRedux.Common.Utilities.ImplicitConverters
{
    public class IntegerTuple
    {
        public (int, int) Tuple { get; }

        public IntegerTuple(int tuple)
        {
            Tuple = (tuple, 1);
        }

        public IntegerTuple((int, int) tuple)
        {
            Tuple = tuple;
        }
        
        public void Deconstruct(out int item1, out int item2)
        {
            item1 = Tuple.Item1;
            item2 = Tuple.Item2;
        }

        public static implicit operator IntegerTuple(int tuple) => new(tuple);

        public static implicit operator IntegerTuple((int, int) tuple) => new(tuple);

        public static implicit operator (int, int)(IntegerTuple tuple) => tuple.Tuple;
    }
}