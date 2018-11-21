using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_HogBank.Models
{
    class EmployeeVO
    {
        private int id;
        private int registrationId;
        private string firstName;
        private string lastName;
        private string address;
        private string status;
        private string type;
        private int hourlyRate;
        private string joinDate;
        private int buildingNumber;
        private bool isBranchManager;
        private bool isTeller;

        public EmployeeVO(int id, int registrationId, string firstName, string lastName, string address, string status, string type, int hourlyRate, string joinDate, int buildingNumber, bool isTeller, bool isBranchManager)
        {
            this.Id = id;
            this.RegistrationId = registrationId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.Status = status;
            this.Type = type;
            this.HourlyRate = hourlyRate;
            this.JoinDate = joinDate;
            this.BuildingNumber = buildingNumber;
            this.IsBranchManager = isBranchManager;
            this.IsTeller = isTeller;
        }

        public int Id { get => id; set => id = value; }
        public int RegistrationId { get => registrationId; set => registrationId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Address { get => address; set => address = value; }
        public string Status { get => status; set => status = value; }
        public string Type { get => type; set => type = value; }
        public int HourlyRate { get => hourlyRate; set => hourlyRate = value; }
        public string JoinDate { get => joinDate; set => joinDate = value; }
        public int BuildingNumber { get => buildingNumber; set => buildingNumber = value; }
        public bool IsBranchManager { get => isBranchManager; set => isBranchManager = value; }
        public bool IsTeller { get => isTeller; set => isTeller = value; }
    }
}
