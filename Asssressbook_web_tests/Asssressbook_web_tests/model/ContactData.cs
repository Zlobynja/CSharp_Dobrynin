using System.Collections.Generic;
using System;


namespace Addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>
    {
        private string firstname;
        private string middlename = "";
        private string lastname = "";
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
        public ContactData(string firstname)
        {
            this.firstname = firstname;
        }
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }
        public string CompanyAddress
        {
            get
            {
                return companyaddress;
            }
            set
            {
                companyaddress = value;
            }
        }
        public string HomeTel
        {
            get
            {
                return hometel;
            }
            set
            {
                hometel = value;
            }
        }
        public string MobileTel
        {
            get
            {
                return mobiletel;
            }
            set
            {
                mobiletel = value;
            }
        }
        public string WorkTel
        {
            get
            {
                return worktel;
            }
            set
            {
                worktel = value;
            }
        }
        public string Fax
        {
            get
            {
                return fax;
            }
            set
            {
                fax = value;
            }
        }
        public string Email1
        {
            get
            {
                return email1;
            }
            set
            {
                email1 = value;
            }
        }
        public string Email2
        {
            get
            {
                return email2;
            }
            set
            {
                email2 = value;
            }
        }
        public string Email3
        {
            get
            {
                return email3;
            }
            set
            {
                email3 = value;
            }
        }
        public string Homepage
        {
            get
            {
                return homepage;
            }
            set
            {
                homepage = value;
            }
        }
        public string Bday
        {
            get
            {
                return bday;
            }
            set
            {
                bday = value;
            }
        }
        public string Bmonth
        {
            get
            {
                return bmonth;
            }
            set
            {
                bmonth = value;
            }
        }
        public string Byear
        {
            get
            {
                return byear;
            }
            set
            {
                byear = value;
            }
        }
        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                if (Firstname == other.Firstname)
                {
                    return Lastname == other.Lastname;
                }
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;

        }

        public int GetHashCode()
        {
            return Firstname.GetHashCode();
        }

    }
}