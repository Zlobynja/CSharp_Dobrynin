using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    class RemoveContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void DeleteContactFromGroupTest()
        {
            GroupData groupWithContact = new GroupData("0");
            bool notinGroup = true;
            bool findGroup = false;
            int i = 0; int j = 0;

            app.Contact.IsContactExists();
            app.Groups.IsGroupExists();

            List<GroupData> groupsList = GroupData.GetAll();
            List<ContactData> contacts = ContactData.GetAll();

            int contactsCount = contacts.Count();
            int groupsCount = groupsList.Count;

            while (i < groupsCount && !findGroup)
            {
                while (j < contactsCount && notinGroup)

                {
                    List<ContactData> contactListInGroup = groupsList[i].GetContacts();
                    if (contactListInGroup.Count() != 0)
                    {
                        contacts = contactListInGroup;
                    }
                    else //если у группы нет контактов, то добаляем в группу контакт
                    {
                        app.Contact.AddContactToGrooup(contacts[0], groupsList[i]);

                    }
                    notinGroup = false;
                    findGroup = true;
                    groupWithContact = groupsList[i];
                    j++;
                }

                i++;
            }

            if (findGroup)
            {
                List<ContactData> oldList = contacts;

                app.Contact.RemoveContactFromGroup(contacts[0], groupWithContact);
                oldList.Remove(contacts[0]);

                List<ContactData> newList = groupWithContact.GetContacts();
                oldList.Sort();
                newList.Sort();
                Assert.AreEqual(contacts, newList);
            }
            else
            {
                System.Console.Out.WriteLine("No groups with contacts");
            }



        }
    }
}