using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV
{
    internal class NhanVien
    {
    private string id;
    private string name;
    private DateTime dateOfBirth;
    private string gender;
    private string address;
    private string phoneNumber;

        public NhanVien(string id, string name, DateTime dateOfBirth,
            string gender, string address, string phoneNumber)
        {
            this.Id = id;
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
    }
}
