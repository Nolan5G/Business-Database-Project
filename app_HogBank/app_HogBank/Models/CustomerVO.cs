using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_HogBank.Models
{
    class CustomerVO
    {
        private int id;
        private int registrationId;
        private string firstName;
        private string lastName;
        private string address;
        private string phoneNumber;
        private string email;
        private string status;
        private string joinDate;

        public CustomerVO(int id, int registrationId, string firstName, string lastName, string address, string phoneNumber, string email, string status, string joinDate)
        {
            this.id = id;
            this.RegistrationId = registrationId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.status = status;
            this.joinDate = joinDate;
        }

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public string Status { get => status; set => status = value; }
        public string JoinDate { get => joinDate; set => joinDate = value; }
        public int RegistrationId { get => registrationId; set => registrationId = value; }
    }
}
