using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_04_21_22
{
    interface IFollower
    {
        // Реакция на рассылку
        void Update(INewspaper newspaper);
    }

    interface INewspaper
    {
        void Follow(IFollower follower);
        void Unfollow(IFollower follower);
        void Notify();
    }

    class Newspaper : INewspaper
    {
        List<IFollower> followerList = new List<IFollower>();

        public void Follow(IFollower follower)
        {
            followerList.Add(follower);
            Console.WriteLine("New follower");
        }

        public void Unfollow(IFollower follower)
        {
            followerList.Remove(follower);
            Console.WriteLine("Unfollow");
        }

        public void Notify()
        {
            foreach (var i in followerList)
            {
                i.Update(this);
            }
        }
    }

    class Observer : IFollower
    {
        public void Update(INewspaper newspaper)
        {
            Console.WriteLine($"{this.GetType().Name} Reacted to {newspaper.GetType().Name} notify");
        }
    }
}
