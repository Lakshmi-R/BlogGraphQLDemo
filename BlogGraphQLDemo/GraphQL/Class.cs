using BlogGraphQLDemo.GraphQL.Mutations;
using BlogGraphQLDemo.GraphQL.Queries;
using GraphQL.Types;

namespace BlogGraphQLDemo.GraphQL
{
    public class BlogSchema : Schema
    {
        //setting up schema for the GRAPHQL
        public BlogSchema(IServiceProvider provider): base(provider) 
        { 
           Query = provider.GetRequiredService<BlogQuery>();
           Mutation = provider.GetRequiredService<BlogMutation>();
        }
    }
}
