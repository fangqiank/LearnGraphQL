using LearnGraphQl.Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnGraphQl.Movies.Services
{
    public class ActorService:IActorService
    {
        private readonly IList<Actor> _actors;

        public ActorService()
        {
            _actors=new List<Actor>
            {
                new Actor
                {
                    Id = 1,
                    Name = "Tom Hanks"
                },

                new Actor
                {
                    Id = 2,
                    Name = "Brad Pitt"
                },

                new Actor
                {
                    Id = 3,
                    Name = "Tom Cruise"
                },

                new Actor
                {
                    Id = 4,
                    Name = "Emma Stone"
                },

                new Actor
                {
                    Id = 5,
                    Name = "Rachel McAdams"
                },

            };
        }

        public Task<Actor> GetByIdAsync(int id)
        {
            return Task.FromResult(_actors.SingleOrDefault(x => x.Id == id));
        }

        public Task<IEnumerable<Actor>> GetAsync()
        {
            return Task.FromResult(_actors.AsEnumerable());
        }
    }
}
