using GraphQL.Types;
using Repository;

namespace BlogGraphQLDemo.GraphQL.Types
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            Field(a => a.Id);
            Field(a => a.Name);
            Field<ListGraphType<PostType>>("posts").Resolve(c => c.Source.Posts);
        }
    }
}
