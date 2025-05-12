using BlogGraphQLDemo.GraphQL.InputType;
using BlogGraphQLDemo.GraphQL.Types;
using GraphQL;
using GraphQL.Types;
using Repository;

namespace BlogGraphQLDemo.GraphQL.Mutations
{
    public class BlogMutation : ObjectGraphType
    {
        //This mutation allows clients to create a new post
        public BlogMutation(IPostRepository postRepository)
        {
            Field<PostType>("createPost")
                .Argument<NonNullGraphType<PostInputType>>("post")
                // it can be synchronous as well just use Resolve 
                .ResolveAsync(async context =>
                {
                    var postInput = context.GetArgument<Post>("post");
                    return await postRepository.AddPostAsync(postInput);                   
                });
        }      
    }
}
