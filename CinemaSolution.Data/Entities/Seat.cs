using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Data.Entities
{
    public class Seat
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Number { get; set; }
        public int ScreeningId { get; set; }
        public virtual Screening? Screening { get; set; }
        public int SeatTypeId { get; set; }
        public virtual SeatType? SeatType { get; set; }
        public int SeatStatusId { get; set; }
        public virtual SeatStatus? SeatStatus { get; set; }
        public int? PersonTypeId { get; set; }
        public virtual PersonType? PersonType { get; set; }
        public int? TicketId { get; set; }
        public virtual Ticket? Ticket { get; set; }
    }
}
