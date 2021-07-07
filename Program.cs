using GenericClassesForPatients.Data;
using GenericClassesForPatients.Entity;
using GenericClassesForPatients.Repository;
using System;

namespace GenericClassesForPatients
{
    class Program
    {
        static void Main(string[] args)
        {
            var patientRepository = new SqlRepository<Patient>(new StorageAppDbContext(),
                ItemToBeAdded);
            AddPatient(patientRepository);
            GetPatientById(patientRepository);
            AddClinician(patientRepository);
            GetAllItems(patientRepository);
            
            Console.WriteLine("");
            var hospitalRepository = new SqlRepository<Hospital>(new StorageAppDbContext());
            hospitalRepository.ItemAddedEvent += HospitalRepository_ItemAddedEvent;
            AddHospital(hospitalRepository);
            GetAllItems(hospitalRepository);
            
            Console.ReadLine();
        }

        private static void HospitalRepository_ItemAddedEvent(object? sender, Hospital e)
        {
            Console.WriteLine($"Notification => {e.Name} hospital was created");
        }

        private static void ItemToBeAdded(Patient patient)
        {
            Console.WriteLine($"Notification => {patient.FirstName} was created");
        }

        private static void AddClinician(IWriteRepository<Clinician> clinicianRepository)
        {
            var clinicians = new[]
            {
                new Clinician { FirstName = "Tase", Surname = "Akpobome" },
                new Clinician { FirstName = "Sarah", Surname = "Baker" }
            };
            clinicianRepository.AddBatch(clinicians);
        }

        private static void GetAllItems(IReadRepository<IEntity> Repository)
        {
            var items = Repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }


        private static void GetPatientById(IRepository<Patient> patientRepository)
        {
            var patient= patientRepository.GetItemById(2);
            Console.WriteLine($"You selected patient {patient.FirstName}. They have an Id of {patient.Id}");

        }

        private static void AddHospital(IRepository<Hospital> hospitalRepository)
        {
            var hospital1 = new Hospital { Name = "London North West", Location = "North London" };
            var copyHospital = hospital1.CopyTo();
            if (copyHospital is not null)
            {
                copyHospital.Name = "*Copy* " + copyHospital.Name;
                hospitalRepository.Add(copyHospital);
            }
            
            var hospitals = new[]
            {
                hospital1,
                new Hospital { Name = "Liverpool Royal Hospital", Location = "Liverpool" },
                new Hospital { Name = "North West Ambulance", Location = "Speke" }
            };
            hospitalRepository.AddBatch(hospitals);
           
        }

        

        private static void AddPatient(IRepository<Patient> patientRepository)
        {
            var patients = new[]
            {
                new Patient { FirstName = "Lesley", Surname = "Baker" },
                new Patient { FirstName = "Beni", Surname = "Ibeh" },
                new Patient { FirstName = "Ola", Surname = "Nola" }
            };
            patientRepository.AddBatch(patients);
        }
    }
}
