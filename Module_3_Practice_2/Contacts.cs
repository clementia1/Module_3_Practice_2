using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Module_3_Practice_2.Models;

namespace Module_3_Practice_2
{
    public class Contacts<T>
        where T : Contact
    {
        private List<Contact> _contactList;
        private int _lastPaginationItem;

        public Contacts()
        {
            _contactList = new List<Contact>();
        }

        public List<Contact> FilterByOperator(string operatorCode)
        {
            var result = _contactList.Where(item => item.PhoneNumber.StartsWith(operatorCode)).ToList();
            return result;
        }

        public List<Contact> Next(int getItemsCount)
        {
            var contactsList = GetContacts(_lastPaginationItem, getItemsCount);
            _lastPaginationItem += getItemsCount;
            return contactsList;
        }

        public List<Contact> Back(int getItemsCount)
        {
            _lastPaginationItem -= _lastPaginationItem < _contactList.Count ? getItemsCount : 0;
            var contactsList = GetContacts(_lastPaginationItem, getItemsCount);
            return contactsList;
        }

        public List<Contact> ToStart(int getItemsCount)
        {
            _lastPaginationItem = 0;
            var contactsList = GetContacts(_lastPaginationItem, getItemsCount);
            return contactsList;
        }

        public List<Contact> ToEnd(int getItemsCount)
        {
            _lastPaginationItem = _contactList.Count - getItemsCount;
            var contactsList = GetContacts(_lastPaginationItem, getItemsCount);
            return contactsList;
        }

        public List<Contact> GetContacts()
        {
            return _contactList;
        }

        public List<Contact> GetContacts(int skipItemsCount, int getItemsCount)
        {
            var result = _contactList.Skip(skipItemsCount).Take(getItemsCount).ToList();
            return result;
        }
    }
}
