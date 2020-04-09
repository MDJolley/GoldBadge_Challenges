using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    public class BadgeRepo
    {
        protected readonly Dictionary<int, List<string>> _Badges = new Dictionary<int, List<string>>();

        public bool AddNewBadge(Badge badge)
        {
            int startingCount = _Badges.Count;
            _Badges.Add(badge.ID, badge.Doors);
            bool success = startingCount < _Badges.Count ? true : false;
            return success;
        }

        public bool RemoveBadge(int id)
        {
            int startingCount = _Badges.Count;
            _Badges.Remove(id);
            bool success = startingCount > _Badges.Count ? true : false;
            return success;
        }

        public List<string> GetDoorsByID(int id) => _Badges[id]; 

        public bool RemoveDoor(int id, string door)
        {
            _Badges[id].Remove(door);
            bool success = _Badges[id].Contains(door) ? false : true;
            return success;
        }

        public bool AddDoorToBadge(int id, string door)
        {
            _Badges[id].Add(door);
            bool success = _Badges[id].Contains(door) ? true : false;
            return success;
        }

        public List<Badge> GetBadges()
        {
            List<Badge> allBadges = new List<Badge>();
            foreach (var badge in _Badges)
            {
                allBadges.Add(new Badge(badge.Key, badge.Value));
            }
            return allBadges;
        }


    }
}
