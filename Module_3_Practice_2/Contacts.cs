using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;
using Module_3_Practice_2.Models;
using Module_3_Practice_2.Helpers.Extensions;

namespace Module_3_Practice_2
{
    public class Contacts<T> : IEnumerable<T>
        where T : Contact
    {
        private List<T> _contactList;
        private int _lastPaginationItem;

        public Contacts()
        {
            _contactList = new List<T>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _contactList.GetEnumerator();
        }

        public void Add(T contact)
        {
            _contactList.Add(contact);
        }

        public List<T> FilterByOperator(string operatorCode)
        {
            var result = _contactList.Where(item => item.PhoneNumber.StartsWith(operatorCode)).ToList();
            return result;
        }

        public List<T> Next(int getItemsCount)
        {
            var contactsList = GetContacts(_lastPaginationItem, getItemsCount);
            _lastPaginationItem += getItemsCount;
            return contactsList;
        }

        public List<T> Back(int getItemsCount)
        {
            _lastPaginationItem -= _lastPaginationItem < _contactList.Count ? getItemsCount : 0;
            var contactsList = GetContacts(_lastPaginationItem, getItemsCount);
            return contactsList;
        }

        public List<T> ToStart(int getItemsCount)
        {
            _lastPaginationItem = 0;
            var contactsList = GetContacts(_lastPaginationItem, getItemsCount);
            return contactsList;
        }

        public List<T> ToEnd(int getItemsCount)
        {
            _lastPaginationItem = _contactList.Count - getItemsCount;
            var contactsList = GetContacts(_lastPaginationItem, getItemsCount);
            return contactsList;
        }

        public List<T> GetThisMonthBirthdays()
        {
            var result = _contactList.Where(item => item.BirthDay.IsCurrentMonth()).ToList();
            return result;
        }

        public T GetNearestBirthday()
        {
            var firstBirthday = GetThisMonthBirthdays().OrderByDescending(item => item.BirthDay).FirstOrDefault();
            return firstBirthday;
        }

        public List<T> GetContacts()
        {
            return _contactList;
        }

        public List<string> GetPhoneNumbers()
        {
            var result = _contactList.Select(item => item.PhoneNumber).ToList();
            return result;
        }

        public List<T> SortByName(bool descending)
        {
            List<T> result;

            if (descending)
            {
                result = _contactList.OrderBy(item => item.FullName).ToList();
                return result;
            }
            else
            {
                result = _contactList.OrderByDescending(item => item.FullName).ToList();
                return result;
            }
        }

        public List<T> SearchByName(string query)
        {
            var result = _contactList.Where(item => item.FullName.Contains(query)).ToList();
            return result;
        }

        public List<T> SortByCallsDuration()
        {
            var result = _contactList.OrderBy(contact =>
            {
                var totalDuration = contact.Calls.Sum(call => call.Duration.TotalMilliseconds);
                return totalDuration;
            }).ToList();

            return result;
        }

        private List<T> GetContacts(int skipItemsCount, int getItemsCount)
        {
            var result = _contactList.Skip(skipItemsCount).Take(getItemsCount).ToList();
            return result;
        }
    }
}
