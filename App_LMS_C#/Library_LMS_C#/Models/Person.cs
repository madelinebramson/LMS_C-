namespace Library_LMS_C_.Models
{
    public class Person
    {
        private static int lastId = 0;
        public int Id
        { 
            get; set; 
        }
        public string Name { get; set; }

        public Person()
        {
            Name = string.Empty;
            //Id = ++lastId;
        }

        public void incrementId()
        {
            Id = ++lastId;
        }
        public override string ToString()
        {
            return $"[{Id}] {Name}";
        }

    }
}
