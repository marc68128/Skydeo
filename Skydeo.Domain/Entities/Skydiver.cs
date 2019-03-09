namespace Skydeo.Domain.Entities
{
    public class Skydiver
    {
        public Skydiver(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName; 
        }

        public string FirstName { get; }
        public string LastName { get; }
    }
}