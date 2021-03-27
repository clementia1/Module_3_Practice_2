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

        public IReadOnlyCollection<T> FilterByOperator(string operatorCode)
        {
            var result = _contactList.Where(item => item.PhoneNumber.StartsWith(operatorCode));
            return (IReadOnlyCollection<T>)result;
        }

        public IReadOnlyCollection<T> Next(int getItemsCount)
        {
            var contactsList = GetContacts(_lastPaginationItem, getItemsCount);
            _lastPaginationItem += getItemsCount;
            return contactsList;
        }

        public IReadOnlyCollection<T> Back(int getItemsCount)
        {
            _lastPaginationItem -= _lastPaginationItem < _contactList.Count ? getItemsCount : 0;
            var contactsList = GetContacts(_lastPaginationItem, getItemsCount);
            return contactsList;
        }

        public IReadOnlyCollection<T> ToStart(int getItemsCount)
        {
            _lastPaginationItem = 0;
            var contactsList = GetContacts(_lastPaginationItem, getItemsCount);
            return contactsList;
        }

        public IReadOnlyCollection<T> ToEnd(int getItemsCount)
        {
            _lastPaginationItem = _contactList.Count - getItemsCount;
            var contactsList = GetContacts(_lastPaginationItem, getItemsCount);
            return contactsList;
        }

        public IReadOnlyCollection<T> GetThisMonthBirthdays()
        {
            var result = _contactList.Where(item => item.BirthDay.IsCurrentMonth());
            return (IReadOnlyCollection<T>)result;
        }

        public T GetNearestBirthday()
        {
            var firstBirthday = GetThisMonthBirthdays().OrderByDescending(item => item.BirthDay).FirstOrDefault();
            return firstBirthday;
        }

        public IReadOnlyCollection<T> GetContacts()
        {
            return _contactList;
        }

        public IReadOnlyCollection<string> GetPhoneNumbers()
        {
            var result = _contactList.Select(item => item.PhoneNumber);
            return (IReadOnlyCollection<string>)result;
        }

        public IReadOnlyCollection<T> SortByName(bool descending)
        {
            IReadOnlyCollection<T> result;

            if (descending)
            {
                result = (IReadOnlyCollection<T>)_contactList.OrderBy(item => item.FullName);
                return result;
            }
            else
            {
                result = (IReadOnlyCollection<T>)_contactList.OrderByDescending(item => item.FullName);
                return result;
            }
        }

        public IReadOnlyCollection<T> SearchByName(string query)
        {
            var result = _contactList.Where(item => item.FullName.Contains(query));
            return (IReadOnlyCollection<T>)result;
        }

        public IReadOnlyCollection<T> SortByCallsDuration()
        {
            var result = _contactList.OrderBy(contact =>
            {
                var totalDuration = contact.Calls.Sum(call => call.Duration.TotalMilliseconds);
                return totalDuration;
            });

            return (IReadOnlyCollection<T>)result;
        }

        private IReadOnlyCollection<T> GetContacts(int skipItemsCount, int getItemsCount)
        {
            var result = _contactList.Skip(skipItemsCount).Take(getItemsCount);
            return (IReadOnlyCollection<T>)result;
        }
    }
}
