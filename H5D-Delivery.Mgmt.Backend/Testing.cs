namespace H5D_Delivery.Mgmt.Backend
{
    public class Testing
    {
        public static string GetSomething()
        {
            Console.WriteLine("GetSomething called");
            return "this is a string for testing purposes";
        }

        public static void TriggerSomething()
        {
            Console.WriteLine("TriggerSomething called");
        }

        public static TestCustomer GetTestCustomer(int age, string firstname, string lastname)
        {
            Console.WriteLine("GetTestCustomer called");
            return new TestCustomer(age, firstname, lastname);
        }

        public static void SendString(string text)
        {
            Console.WriteLine(text);
        }
    }

    public class TestCustomer
    {
        public int Age { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public TestCustomer(int age, string firstname, string lastname)
        {
            Age = age;
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}