using System;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using LearnGraphQl.Movies.Schema;
using LearnGraphQl.Movies.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LearnGraphQL
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMovieService, MovieService>();
            services.AddSingleton<IActorService, ActorService>();

            services.AddSingleton<MovieType>();
            services.AddSingleton<ActorType>();
            services.AddSingleton<MovieRatingEnum>();
            services.AddSingleton<MoviesQuery>();

            services.AddSingleton<MovieSchema>();

            services.AddGraphQL((options, provider) =>
                {
                    options.EnableMetrics = true;
                    var logger = provider.GetRequiredService<ILogger<Startup>>();
                    options.UnhandledExceptionDelegate = ctx =>
                        logger.LogError("{Error} occurred", ctx.OriginalException.Message);
                }).AddSystemTextJson() // For .NET Core 3+
                .AddErrorInfoProvider(opt => 
                    opt.ExposeExceptionStackTrace = true)
                .AddWebSockets() // Add required services for web socket support
                .AddDataLoader(); // Add required services for DataLoader support
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseWebSockets();

            // use websocket middleware for ChatSchema at default path /graphql
            app.UseGraphQLWebSockets<MovieSchema>("/graphql");

            // use HTTP middleware for ChatSchema at default path /graphql
            app.UseGraphQL<MovieSchema>("/graphql");

            // use graphql-playground middleware at default path /ui/playground
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            // use graphiQL middleware at default path /ui/graphiql
            app.UseGraphiQLServer();

            // use voyager middleware at default path /ui/voyager
            app.UseGraphQLVoyager();

        }
    }
}
