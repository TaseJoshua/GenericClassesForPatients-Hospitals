namespace GenericClassesForPatients.Entity
{
    public class Patient:EntityBase
    {
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public override string ToString() => $"Patient Id: {Id} - Firstname: {FirstName} - Surname: {Surname}";
    }

}
