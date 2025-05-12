using GraphQL.Types;
using Repository;

namespace BlogGraphQLDemo.GraphQL.InputType
{
    public class PostInputType : InputObjectGraphType
    {
        //the structure of the input object that clients will use to create a new post.
        public PostInputType() {

            Name = "PostInput";
            Field<NonNullGraphType<StringGraphType>>("title");
            Field<NonNullGraphType<StringGraphType>>("content");
            Field<NonNullGraphType<IntGraphType>>("authorId");
        }
    }
}
