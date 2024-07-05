using System.ComponentModel.DataAnnotations;

namespace CrudOperationUsingDatabaseFirstApproach.Models
{
    public class CountryData
    {
        [Key]
        public int id { get; set; }
        public string Country_Name { get; set; }

        public string Country_Capital { get; set; }

        public string Country_Currency { get; set; }

        public string Country_Continent { get; set; }


    }
}
