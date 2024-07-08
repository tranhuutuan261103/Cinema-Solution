using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Data.Entities
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ProvinceId { get; set; }
        public virtual Province? Province { get; set; }
        public string Address { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
        public virtual ICollection<Auditorium>? Auditoriums { get; set; }
    }
}
