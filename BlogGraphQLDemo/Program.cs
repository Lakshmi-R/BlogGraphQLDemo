using BlogGraphQLDemo.GraphQL;
using BlogGraphQLDemo.GraphQL.InputType;
using BlogGraphQLDemo.GraphQL.Mutations;
using BlogGraphQLDemo.GraphQL.Queries;
using BlogGraphQLDemo.GraphQL.Types;
using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BlogDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<BlogQuery>();
builder.Services.AddScoped<BlogMutation>();
builder.Services.AddScoped<PostType>();
builder.Services.AddScoped<PostInputType>();
builder.Services.AddScoped<ISchema, BlogSchema>();

builder.Services
    .AddGraphQL(options =>
    {
        options.EnableMetrics = false;
    })
    .AddSystemTextJson() // <-- THIS REGISTERS IGraphQLTextSerializer
    .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
    .AddGraphTypes(typeof(BlogSchema).Assembly); // auto-registers all GraphQL types

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL();

app.Run();
