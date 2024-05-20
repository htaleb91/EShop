using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace EShop.Entities.Domain
{
    public class Address : BaseEntity
    {
        public string AddressHead { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Distinct { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
    }
}
