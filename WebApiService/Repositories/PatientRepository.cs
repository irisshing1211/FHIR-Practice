using WebApiService.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Model;

namespace WebApiService.Repositories
{
    public class PatientRepository
    {
        /// <summary>
        ///  return patient id if create success, null if fail
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public string CreatePatient(ServicePatient patient)
        {
            try
            {
                var settings = new FhirClientSettings
                {
                    Timeout = 120000,
                    PreferredFormat = ResourceFormat.Json,
                    VerifyFhirVersion = true,
                    PreferredReturn = Prefer.ReturnMinimal
                };
                var client = new FhirClient("http://localhost:8080/fhir", settings);
                // client.Settings.PreferredFormat = ResourceFormat.Json;

                var create = new Patient
                {
                    Active = true,
                    Gender = patient.Gender,
                    Identifier = new List<Identifier> { new Identifier { Value = patient.IdCard } },
                    Name = new List<HumanName> {
                        new HumanName { Family = patient.FamilyName, Given = patient.GivenName.Split(' ') }
                    }                    
                };

                var createResult = client.Create<Patient>(create);
                return createResult.Id ?? string.Empty;
            }
            catch(FhirOperationException foex)
            {
                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
