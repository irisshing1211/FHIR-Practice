using Hl7.Fhir.Model;

namespace WebApiService.Model
{
    public class ServicePatient
    {
        /// <summary>
        /// null if create new patient
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// 姓
        /// </summary>
        public string FamilyName { get; set; }
        /// <summary>
        /// 名
        /// </summary>
        public string GivenName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public AdministrativeGender Gender { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IdCard { get; set; }


    }
}
