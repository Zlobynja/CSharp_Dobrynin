using System.Collections.Generic;
using System;


namespace Addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string middlename = "";
        private string lastname;
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string companyaddress = "";
        private string hometel = "";
        private string mobiletel = "";
        private string worktel = "";
        private string fax = "";
        private string email1 = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string bday = "";
        private string bmonth = "";
        private string byear = "";
        private string notes = "";




        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Id { get; set; }


        public string Company { get; set; }


        public string CompanyAddress { get; set; }

        public string HomeTel { get; set; }


        public string MobileTel { get; set; }



        public string WorkTel { get; set; }


        public string Fax { get; set; }


        public string Email1 { get; set; }


        public string Email2 { get; set; }


        public string Email3 { get; set; }


        public string Homepage { get; set; }


        public string Bday { get; set; }


        public string Bmonth { get; set; }


        public string Byear { get; set; }


        public string Notes { get; set; }


        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            if (Lastname == other.Lastname)
            {
                return Firstname == other.Firstname;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;

        }

        public override int GetHashCode()
        {
            return Lastname.GetHashCode();
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname == other.Lastname)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            return Lastname.CompareTo(other.Lastname);
        }

        public override string ToString()
        {
            return "Firstname=" + Firstname + " Lastname " + Lastname;
        }
    }
}