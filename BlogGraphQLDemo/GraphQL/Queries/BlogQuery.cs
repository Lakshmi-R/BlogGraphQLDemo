using BlogGraphQLDemo.GraphQL.Types;
using BlogGraphQLDemo.GraphQL.InputType;
using GraphQL.Types;
using Repository;
using GraphQL;

namespace BlogGraphQLDemo.GraphQL.Queries
{
    public class BlogQuery : ObjectGraphType
    {
        public BlogQuery(IPostRepository repository)
        {
            Field<ListGraphType<PostType>>("posts")
               .ResolveAsync(async context => await repository.GetAllPosts());

            Field<PostType>("post")
                .Argument<NonNullGraphType<IntGraphType>>("id")
                .ResolveAsync(async context =>
                {
                    var id = context.GetArgument<int>("id");
                    var posts = await repository.GetPostByIdAsync(id);
                    return posts;
                });
        }
    }
}
