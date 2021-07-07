namespace GenericClassesForPatients.Entity
{
    public class Clinician : Patient
    {
        public override string ToString() => base.ToString() + " - (Clinician)";
    }

}
