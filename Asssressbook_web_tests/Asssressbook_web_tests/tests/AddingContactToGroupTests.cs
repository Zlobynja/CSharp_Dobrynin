using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void AddingContactToGroupTest()
        {
            ContactData contact = new ContactData("1", "2");
            GroupData group = null;
            int j = 0;

            app.Contact.IsContactExists();
            app.Groups.IsGroupExists();

            List<GroupData> groupsList = GroupData.GetAll();
            List<ContactData> contacts = ContactData.GetAll();

            int contactsCount = contacts.Count();
            int groupsCount = groupsList.Count;


            bool contactToAddExist = false;

            List<ContactData> oldList = null;
            int i = 0;

            while (i < groupsCount && !contactToAddExist)
            {
                oldList = groupsList[i].GetContacts();
                if (oldList.Count == 0) //в группе нет контактов, добавляем первый из списка
                {
                    contact = ContactData.GetAll().First();
                }
                else if (oldList.Count == contactsCount) // в группу добавлены все контакты,п.э. создаем новый контакт
                {
                    contact = new ContactData("firstname1234", "lastname123");
                    app.Contact.Create(contact);
                }
                else if (oldList.Count < contactsCount) // есть контакт, который можно добавить в группу             
                {
                    contact = ContactData.GetAll().Except(oldList).First();
                }
                contacts[0] = contact;
                group = groupsList[i];
                contactToAddExist = true;
                j = i;

                i++;
            }

            if (contactToAddExist)
            {
                oldList = groupsList[j].GetContacts();
                app.Contact.AddContactToGrooup(contacts[0], groupsList[j]);
                List<ContactData> newList = groupsList[j].GetContacts();
                oldList.Add(contact);
                oldList.Sort();
                newList.Sort();
                Assert.AreEqual(oldList, newList);

            }
            else
            {
                System.Console.Out.WriteLine("No contact to add to group");
            }

        }


    }
}