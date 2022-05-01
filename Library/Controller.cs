using Library.Data;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Controller
    {
        public static List<Room> GetAvailableRooms(dat154_2022_42Context hcx, int beds, int size, DateTime dateStart, DateTime dateEnd)
        {
            if (dateStart.Date.CompareTo(DateTime.Today) < 0 || dateEnd.Date.CompareTo(DateTime.Today) < 0) return new List<Room>();

            hcx.Rooms.Load();
            hcx.Reservations.Load();
            return hcx.Rooms.Local
                .Where(r => r.Beds >= beds && r.Size >= size)
                .Where(r =>
                {
                    bool notConflictingRes = r.Reservations.All(res =>
                    {
                        bool isBefore = res.DateStart.CompareTo(dateStart) < 0 && res.DateEnd.CompareTo(dateStart) < 0;
                        bool isAfter = res.DateStart.CompareTo(dateEnd) > 0 && res.DateEnd.CompareTo(dateEnd) > 0;
                        return isBefore || isAfter;
                    });
                    bool emptyRes = r.Reservations.Count == 0 || r.Reservations == null;
                    return notConflictingRes || emptyRes;
                    //var obj = r.Reservations.FirstOrDefault(res => !res.CheckedOut);
                    //return obj == null;
                }).ToList();
        }
    }
}
