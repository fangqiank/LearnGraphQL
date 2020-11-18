using GraphQL.Types;
using LearnGraphQl.Movies.Models;

namespace LearnGraphQl.Movies.Schema
{
    public class ActorType:ObjectGraphType<Actor>
    {
        public ActorType()
        {
            Field(x => x.Id).Description("The id of actor");
            Field(x => x.Name).Description("The actor name");
        }
    }
}
