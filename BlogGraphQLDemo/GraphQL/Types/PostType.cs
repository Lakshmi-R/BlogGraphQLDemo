using GraphQL.Types;

namespace BlogGraphQLDemo.GraphQL.Types
{
    public class PostType : ObjectGraphType<Repository.Post>
    {
       public PostType() {
            Field(a => a.Id);
            Field(a => a.Title);
            Field(a => a.Description);
            Field<AuthorType>("author");
        }
    }
}