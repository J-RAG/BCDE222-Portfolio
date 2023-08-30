namespace PropertyDemo
{
    public class SaleItem
    {
        /*
         * In some cases, property get and set accessors just assign a value to or retrieve a value from a 
         * backing field without including any additional logic. By using auto-implemented properties, you 
         * can simplify your code while having the C# compiler transparently provide the backing field for you.
         */

        /* 
         * If a property has both a get and a set accessor, both must be auto-implemented. You define an 
         * auto-implemented property by using the get and set keywords without providing any implementation. 

         Beginning with C# 11, you use the required keyword to force callers to set the value of a property or 
         field using an object initializer. Required properties don't need to be set as constructor parameters. 
         The compiler ensures all callers initialize those values.
         */
        public required string Name
        { get; set; }

        public decimal Price
        { get; set; }

        /* 
        Object Initializers with the init accessor:
            Making sure no one changes the designed object could be limited by using an init accessor. It helps 
            to restrict the setting of the property value.

        compiler error:
            this.Quantity = _;
        */
        public int Quantity
        { get; init; }
    }
}
